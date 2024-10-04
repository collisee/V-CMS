using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;

/// <summary>
/// Utils of Petronas.NextG.Framework.DAC
/// </summary>
namespace VietNamNet.AddOn.VCard.Core.Common
{
public class VCardsUtils
{
    public DataTable ReadFromCsvString(string data)
    {
        CsvParser p = new CsvParser();
        return p.Parse(data);
    }
    public DataTable ReadFromCsvString(string data, bool headers)
    {
        CsvParser p = new CsvParser();
        return p.Parse(data, headers);
    }
}
}
