using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Caching;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using Telerik.Web.UI;

namespace VietNamNet.Framework.Administrator
{
    public partial class CacheManager : BasePage
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
                //BindData();

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isDeleter;
                //show hide Delete button
                radGridDefault.Columns[radGridDefault.Columns.Count - 1].Visible = isDeleter;
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.CacheManage";
            viewAlias = "System.CacheManage.View";
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.Clear:
                    //Clear Cache
                    ClearCache();
                    //BindData();
                    radGridDefault.Rebind();
                    break;
                default:
                    break;
            }
        }

        private void ClearCache()
        {
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
            ArrayList list = new ArrayList();
            IDictionaryEnumerator enumerator = cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Key.ToString());
            }
            foreach (object obj2 in list)
            {
                cache.Remove(obj2.ToString());
            }
        }

        private DataTable GetCache()
        {
            DataTable dt = GetCacheTableTemplate();
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

            foreach (DictionaryEntry entry in cache)
            {
                DataRow dr = dt.NewRow();
                dr["Key"] = entry.Key.ToString();
                if (cache[entry.Key.ToString()] != null)
                {
                    object obj2 = cache[entry.Key.ToString()];
                    dr["ObjectType"] = obj2.GetType().FullName;
                }
                else
                {
                    dr["ObjectType"] = "NULL";
                }
                if (Nulls.IsNullOrEmpty(Convertor.ToString(entry.Value)))
                {
                    dr["Code"] = 0;
                    dr["Length"] = 0;
                    dr["Note"] = "Data could not be serialized to Xml.";
                }
                else
                {
                    dr["Code"] = 1;
                    dr["Length"] = entry.Value.ToString().Length;
                    dr["Note"] = "Double Click to View Data.";
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        private DataTable GetCacheTableTemplate()
        {
            DataTable dt = new DataTable("CacheManager");
            dt.Columns.Add("Key");
            dt.Columns.Add("Code", typeof (int));
            dt.Columns.Add("Length", typeof (int));
            dt.Columns.Add("ObjectType");
            dt.Columns.Add("Note");
            return dt;
        }

        private void BindData()
        {
            radGridDefault.DataSource = GetCache();
            radGridDefault.DataBind();
        }

        protected void radGridDefault_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            radGridDefault.DataSource = GetCache();
        }

        protected void radGridDefault_DeleteCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Key"].ToString();
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
                cache.Remove(key);

                //BindData();
                radGridDefault.Rebind();
            }
        }
    }
}