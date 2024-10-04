using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace VietNamNet.AddOn.VCard.Core.Common
{
     class CsvParser
    {
        public  DataTable Parse(string data, bool headers)
        {
            return Parse(new StringReader(data), headers);
        }

        public DataTable Parse(string data)
        {
            return Parse(new StringReader(data));
        }

        public  DataTable Parse(TextReader stream)
        {
            return Parse(stream, false);
        }

        public DataTable Parse(TextReader stream, bool headers)
        {
            DataTable table = new DataTable();
            CsvStream csv = new CsvStream(stream);
            string[] row = csv.GetNextRow();
            if (row == null)
                return null;
            if (headers)
            {
                foreach (string header in row)
                {
                    if (header != null && header.Length > 0 && !table.Columns.Contains(header))
                        table.Columns.Add(header, typeof(string));
                    else
                        table.Columns.Add(GetNextColumnHeader(table), typeof(string));
                }
                row = csv.GetNextRow();
            }
            while (row != null)
            {
                while (row.Length > table.Columns.Count)
                    table.Columns.Add(GetNextColumnHeader(table), typeof(string));
                table.Rows.Add(row);
                row = csv.GetNextRow();
            }
            return table;
        }

        private static string GetNextColumnHeader(DataTable table)
        {
            int c = 1;
            while (true)
            {
                string h = "Column" + c++;
                if (!table.Columns.Contains(h))
                    return h;
            }
        }
    }
}