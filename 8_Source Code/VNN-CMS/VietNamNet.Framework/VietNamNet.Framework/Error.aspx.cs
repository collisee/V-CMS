using System;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.Framework
{
    public partial class Error : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strMsg = Request.Params[Constants.ParameterName.MESSAGE];
                string message = Utilities.GetConfigKey(strMsg);
                lblMsg.Text = Nulls.IsNullOrEmpty(message)
                                  ? HttpUtility.HtmlEncode(strMsg)
                                  : HttpUtility.HtmlEncode(message);
            }
        }
    }
}