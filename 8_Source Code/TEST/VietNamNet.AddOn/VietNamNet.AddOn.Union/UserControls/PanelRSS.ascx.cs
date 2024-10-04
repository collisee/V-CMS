using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common.RSS;
using VietNamNet.AddOn.Union.Common;

namespace VietNamNet.AddOn.Union.UserControls
{
  public partial class PanelRSS : UserControl
  {
    [Description("RSS Url")]
    [Browsable(true)]
    [DefaultSettingValue("")]
    public string RSSUrl
    {
      get
      {
        return
          Nulls.IsNullOrEmpty(ViewState[UnionConstants.ViewState.RSSUrl])
            ? string.Empty
            : ViewState[UnionConstants.ViewState.RSSUrl].ToString();
      }
      set { ViewState[UnionConstants.ViewState.RSSUrl] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        RSS rss = GetData(RSSUrl);
        if (rss != null)
        {
          rptRSS.DataSource = rss.Channel.Items;
          rptRSS.DataBind();
        }
      }
    }

    private RSS GetData(string url)
    {
      if (Nulls.IsNullOrEmpty(url)) return null;

      RSS rss;

      HttpWebRequest RSS_Request;
      HttpWebResponse RSS_Response = null;
      try
      {
        RSS_Request = (HttpWebRequest) WebRequest.Create(string.Format(url));
        RSS_Request.UserAgent =
          @"Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.4) Gecko/20070515 Firefox/2.0.0.4";
        RSS_Response = (HttpWebResponse) RSS_Request.GetResponse();
        Stream streamResponse = RSS_Response.GetResponseStream();
        StreamReader streamReader = new StreamReader(streamResponse);
        StringBuilder sb = new StringBuilder();
        Char[] readBuffer = new Char[256];
        int count = streamReader.Read(readBuffer, 0, 256);
        while (count > 0)
        {
          String resultData = new String(readBuffer, 0, count);
          sb.Append(resultData);
          count = streamReader.Read(readBuffer, 0, 256);
        }
        streamReader.Close();
        streamResponse.Close();

        RSS_Response.Close();

        //Convert to RSS Object
        rss = (RSS) Convertor.ToObject(typeof (RSS), sb.ToString());
      }
      catch
      {
        rss = null;
      }

      return rss;
    }
  }
}