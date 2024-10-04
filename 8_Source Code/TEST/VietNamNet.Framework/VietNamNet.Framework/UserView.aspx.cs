using System;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework
{
    public partial class UserView : BasePageView
    {
        protected string group = string.Empty;
        protected int groupQuantity = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            group = Request.Params[SystemConstants.ParameterName.GROUPS];
            if (Nulls.IsNullOrEmpty(group))
            {
                group = string.Empty;
                groupQuantity = 0;
            }
            else
            {
                groupQuantity = group.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }

            if (!IsPostBack)
            {
                RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                if (radKeyword != null)
                {
                    RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                    if (txtKw != null)
                    {
                        txtKw.Text = Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.KEYWORD])
                                         ? string.Empty
                                         : Request.Params[Constants.ParameterName.KEYWORD];
                    }
                }

                BindDataToGroup();
                SetDataSelectedGroups(group);

                FunctionforPageLoad();
            }
        }

        private void Initialize()
        {
            ServiceName = SystemConstants.Services.UserManager.Name;
            ActionName = SystemConstants.Services.UserManager.Actions.ViewGetAllUserFilterByGroup;
        }

        private void BindDataToGroup()
        {
            RadToolBarItem radGroup = radToolBarDefault.FindItemByValue("searchGroupComboBoxButton");
            if (radGroup != null)
            {
                RadComboBox cmbGroup = (RadComboBox)radGroup.FindControl("cmbGroup");
                if (cmbGroup != null)
                {
                    GroupHelper helper = new GroupHelper(new Group());
                    cmbGroup.DataSource = helper.ListAll();
                    cmbGroup.DataBind();
                }
            }
        }

        private void SetDataSelectedGroups(string g)
        {
            if (Nulls.IsNullOrEmpty(g)) return;

            g = string.Format(",{0},", g);
            string text = string.Empty;
            RadToolBarItem radGroup = radToolBarDefault.FindItemByValue("searchGroupComboBoxButton");
            if (radGroup != null)
            {
                RadComboBox cmbGroup = (RadComboBox)radGroup.FindControl("cmbGroup");
                if (cmbGroup != null)
                {
                    foreach (RadComboBoxItem item in cmbGroup.Items)
                    {
                        string v = string.Format(",{0},", item.Value);
                        CheckBox chk = (CheckBox)item.FindControl("chk1");
                        if (chk != null && g.IndexOf(v) > -1)
                        {
                            chk.Checked = true;
                            text += item.Text + ",";
                        }
                    }
                    cmbGroup.Text = text.Trim().TrimEnd(',');
                }
            }

        }

        private string GetDataSelectedGroups()
        {
            string checkedText = string.Empty;
            RadToolBarItem radGroup = radToolBarDefault.FindItemByValue("searchGroupComboBoxButton");
            if (radGroup != null)
            {
                RadComboBox cmbGroup = (RadComboBox)radGroup.FindControl("cmbGroup");
                if (cmbGroup != null)
                {
                    foreach (RadComboBoxItem item in cmbGroup.Items)
                    {
                        CheckBox chk = (CheckBox)item.FindControl("chk1");
                        if (chk != null && chk.Checked)
                            checkedText += item.Value + ",";
                    }
                    checkedText = checkedText.Trim().TrimEnd(',');
                }
            }

            return checkedText;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton)e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.UserEdit);
                    break;
                case Constants.CommandNames.Search:
                    string kw = string.Empty;
                    RadToolBarItem radKeyword = radToolBarDefault.FindItemByValue("searchTextBoxButton");
                    if (radKeyword != null)
                    {
                        RadTextBox txtKw = (RadTextBox)radKeyword.FindControl("txtKeyword");
                        if (txtKw != null)
                        {
                            kw = txtKw.Text.Trim();
                        }
                    }
                    string g = GetDataSelectedGroups();
                    string url =
                        Utilities.SetParamForURL(Request.Url.AbsoluteUri, Constants.ParameterName.KEYWORD, kw);
                    url = Utilities.SetParamForURL(url, SystemConstants.ParameterName.GROUPS, g);
                    Response.Redirect(url);
                    break;
                default:
                    break;
            }
        }

        protected override DataTable BindSearchingTable()
        {
            DataTable dtSearch = new DataTable(Constants.Paging.Direction.SearchingTableName);
            dtSearch.Columns.Add(Constants.Paging.Direction.IsSearch, typeof(bool));
            dtSearch.Columns.Add(Constants.Paging.Direction.KeyWords, typeof(string));
            dtSearch.Columns.Add("Group", typeof(string));
            dtSearch.Columns.Add("GroupQuantity", typeof(int));
            DataRow drSearch = dtSearch.NewRow();
            drSearch[Constants.Paging.Direction.IsSearch] =
                Convert.ToBoolean(ViewState[Constants.Paging.Direction.IsSearch]);
            drSearch[Constants.Paging.Direction.KeyWords] =
                Convert.ToString(ViewState[Constants.Paging.Direction.KeyWords]);
            drSearch["Group"] = group;
            drSearch["GroupQuantity"] = groupQuantity;
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }

        protected override void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if ((Utilities.StringCompare(e.CommandName, Constants.CommandNames.RowClick) ||
                 Utilities.StringCompare(e.CommandName, Constants.CommandNames.Edit)) && e.Item is GridDataItem)
            {
                Utilities.Redirect(SystemConstants.FormNames.UserInfo,
                                   e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"].ToString());
            }
        }
    }
}