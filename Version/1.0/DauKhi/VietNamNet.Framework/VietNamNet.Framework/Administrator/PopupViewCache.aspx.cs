using System;
using System.Web;
using System.Web.Caching;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.Framework.Administrator
{
    public partial class PopupViewCache : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isViewer)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                string key = Request.Params[Constants.ParameterName.KEY];
                string value = string.Empty;
                Cache cache;
                HttpContext current = HttpContext.Current;
                if (current != null)
                {
                    cache = current.Cache;
                }
                else
                {
                    cache = HttpRuntime.Cache;
                }
                object obj = cache.Get(key);
                value = Convertor.ToString(obj);
                if (!Utilities.StringCompare(obj.GetType().FullName, "System.String"))
                {
                    value = HttpUtility.HtmlEncode(value);
                }
                lblKey.Text = key;
                lblLength.Text = Utilities.DisplayNumberFormat(value.Length);
                lblValue.Text = value.Replace("\r\n", "<br />");
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.CacheManage";
            viewAlias = "System.CacheManage.View";
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
    }
}