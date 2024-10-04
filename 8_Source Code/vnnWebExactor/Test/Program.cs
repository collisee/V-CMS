using System;
using System.Collections.Generic;
using DAL;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using VNN_WEBEXTRACTOR;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetContentFromRolo.Utils utils = new GetContentFromRolo.Utils();
            //utils.LogPath = "C:\\TEMP\\";
            //XmlDocument xmlDocument = utils.GetXmlFromUrl("http://news.rolo.vn/news/topnewsapi?action=get_news&catid=1&num=50", "qwertyu");
            //XmlNode root = xmlDocument.DocumentElement;

            //DataTable dataTable = new GetContentFromRolo.NewsDB().Xml2DataSet(xmlDocument);
            //if (dataTable != null)
            //{
            //    foreach (DataRow dataRow in dataTable.Rows)
            //    {
            //        foreach (DataColumn column in dataTable.Columns)
            //        {
            //            Console.WriteLine(column.ColumnName + "-->" + dataRow[column.ColumnName].ToString());
            //        }

            //    }
            //}
            //new GetContentFromRolo.Main().GetContentFromRolo();
            new Extractor().doAutoExtract();
                          
        }

        public DataTable XmlNodeListToDataTable(XmlNodeList xmlNodeList, string[] columns)
	    {
	        //Creating the DataTable.
	        using (DataTable dataTable = new DataTable("DataTable"))
	        {
	            //Adding data Table columns based on the columns parameter
	            foreach (string column in columns)
	            {
	                dataTable.Columns.Add(column);
	            }
	            //Adding rows with values.
	            DataRow dataRow;
	            foreach (XmlNode node in xmlNodeList)
	            {
	                dataRow = dataTable.NewRow();
	                foreach (string column in columns)
	                {
	                    dataRow[column] = node.SelectSingleNode(column).InnerText;
                }
	                dataTable.Rows.Add(dataRow);
	            }
	            return dataTable;
	        }
	    }
    }
}
