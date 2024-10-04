using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Royalty
{
    public partial class _Default : BasePageView
    {
        #region  "Controls"

        #endregion

        #region "Event Handlers"

        protected void Page_Load(object sender, EventArgs e)
        { 
            Initialize();
            //// test only
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_ID] = 10;
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_LOGINNAME] = "dnson";
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
            //Session[VietNamNet.Framework.Common.Constants.Session.USER_STATUS] = "Hoạt động";


            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                SetupEnvironment();
            }
        }

        private void Initialize()
        {
        }

        #region "Royaltys - event handlers"

        protected void OnFilterChanged(object sender, EventArgs e)
        {
            PopularRoyaltys(0);
        }

        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        { 
            PopularRoyaltys(e.NewPageIndex);
        }

        protected void GrdViewPageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {
            PopularRoyaltys(0);
        }

        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {
            try{
                switch (e.CommandName)
                {
                    case "Delete":
                        //RoyaltysHelper vHelper = new RoyaltysHelper(new Royalty());
                        //vHelper.ValueObject.ContactId = Convert.ToInt32(((TextBox) e.Item.FindControl("txtContactId") ). Text );
                        //vHelper.Load();
                        //vHelper.Delete();  
                        //PopularRoyaltys(grdView.CurrentPageIndex);
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + e.CommandArgument;
            }
        }

        protected void GrdViewItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (IsEditable(Utilities.ParseInt(((Label)e.Item.FindControl("lblOwner")).Text)))
            //{
            //    if (e.Item.FindControl("allowEdit") != null)
            //    {
            //        ((Panel) e.Item.FindControl("allowEdit")).Visible = true;
            //    }
            //}
            
                
        }
        #endregion


        #region "Groups - event handlers"

        protected void rptGroup_PreRender(object sender, EventArgs e)
        {
            //RadGrid rptGroup = (RadGrid) PanelBar.Items[2].Items[0].FindControl("rptGroup");

            //if (rptGroup.EditIndexes.Count > 0 || rptGroup.MasterTableView.IsItemInserted)
            //{
            //    GridColumn col1 = rptGroup.MasterTableView.GetColumn("EditCommandColumn") as GridColumn;
            //    col1.Visible = true;
            //}
            //else
            //{
            //    GridColumn col2 = rptGroup.MasterTableView.GetColumn("EditCommandColumn") as GridColumn;
            //    col2.Visible = false;
            //}
        }
 

        protected void RptGroupItemCommand(object source, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
               case "Update":
                    //RoyaltysGroupsHelper gHelper = new RoyaltysGroupsHelper(new RoyaltysGroups());
                    //gHelper.ValueObject.GroupId = Utilities.ParseInt(((RadTextBox)e.Item.FindControl("txtGroupId")).Text == "" ? 0 : Utilities.ParseInt(((RadTextBox)e.Item.FindControl("txtGroupId")).Text));
                    //gHelper.ValueObject.GroupName = ((RadTextBox)e.Item.FindControl("txtGroupName")).Text;
                    //gHelper.ValueObject.Description = ((RadTextBox)e.Item.FindControl("txtDescription")).Text;
                    //gHelper.ValueObject.Owner = this.UserId;
                    //gHelper.ValueObject.Created_At = DateTime.Now;
                    //gHelper.ValueObject.Created_By = this.UserId;
                    //gHelper.ValueObject.Last_Modified_At = DateTime.Now ;
                    //gHelper.ValueObject.Last_Modified_By = this.UserId;
                    //gHelper.ValueObject.Last_Modified_By = this.UserId;
                    //gHelper.DoSave(); 

                    e.Item.Edit = false;
                    PopularGroup();
                    PopularRoyaltys(0);
                    break;         
                case "Cancel":
                    e.Item.Edit = false;
                    PopularGroup();
                    PopularRoyaltys(0);
                    break;
            }
        }

        protected void CmdAddNewRecordClick(object sender, EventArgs e)
        {
            //RadGrid rptGroup = (RadGrid)PanelBar.Items[2].Items[0].FindControl("rptGroup");
            //rptGroup.MasterTableView.IsItemInserted = true;
            //PopularGroup();
        }

        protected void CmdResetClick(object sender, EventArgs e)
        {
            //RadPanelItem pItem = new RadPanelItem();
            //pItem = PanelBar.Items[0].Items[0];
            //((RadTextBox) pItem.FindControl("txtFilterName")).Text = "";
            //((RadTextBox) pItem.FindControl("txtFilterOrgName")).Text = "";
            //((RadTextBox) pItem.FindControl("txtFilterTitle")).Text = "";
            //((RadTextBox) pItem.FindControl("txtFilterEmail")).Text = "";

            //pItem = PanelBar.Items[1].Items[0];
            //((CheckBox) pItem.FindControl("chkScopePrivate")).Checked = true;
            //((CheckBox) pItem.FindControl("chkScopePublic")).Checked = true;

            //((CheckBox) PanelBar.Items[2].Items[0].FindControl("chkAll")).Checked = true;
                

            //OnFilterChanged(sender, e);
        }

        #endregion

        #endregion

        #region "Private Methods"

        private void SetupEnvironment()
        {
            //grdView.PageSize = 10;
            PopularGroup();
            PopularRoyaltys(0);
        }

        private void PopularGroup()
        {
            //RoyaltysGroupsHelper gHelper = new RoyaltysGroupsHelper(new RoyaltysGroups());
            //gHelper.ValueObject.Owner = UserId;
            //DataTable dt = gHelper.ListAllByUser();

            //Repeater rpt = (Repeater)PanelBar.Items[2].Items[0].FindControl("rptGroup");

            //rpt.DataSource = dt;
            //rpt.DataBind();

            //RadGrid rptGroup = (RadGrid) PanelBar.Items[2].Items[0].FindControl("rptGroup");

            //rpt.DataSource = dt;
            //rpt.DataBind(); 
            //if (dt.Rows.Count == 0)
            //    ((LinkButton)PanelBar.Items[2].Items[0].FindControl("cmdAddNewRecord")).Visible = true;

            //rptGroup.DataSource = dt;
           // rptGroup.DataBind();
        }

        private void PopularRoyaltys(int pageIndex )
        {
          
            //RoyaltysHelper vHelper = new RoyaltysHelper(new Royaltys());
            //vHelper.ValueObject.Owner = this.UserId;
            //DataTable dt = vHelper.ListAllByUser();

            String sFilter = FilterBuilder();

            //// Display to grid. 
            //dt.DefaultView.RowFilter = sFilter;
            //grdView.CurrentPageIndex = pageIndex;

            //grdView.DataSource = dt.DefaultView;
            //grdView.DataBind();
        }

        private String FilterBuilder()
        {
            //StringBuilder sbG = new StringBuilder();
            //RadGrid rpt = (RadGrid)PanelBar.Items[2].Items[0].FindControl("rptGroup"); 
            //if (((CheckBox)PanelBar.Items[2].Items[0].FindControl("chkAll")).Checked == false)  
            //    foreach (GridDataItem i in rpt.Items)
            //        if (((CheckBox)i.FindControl("chkGroup")).Checked)
            //        {
            //            sbG.Append(((HiddenField)i.FindControl("txtGroupID")).Value + ";");
            //        }
 

            //// Setup Filter
            //StringBuilder sFilter = new StringBuilder();
            //sFilter.Append(" 1=1 ");
            //RadPanelItem pItem = new RadPanelItem();
            //pItem = PanelBar.Items[1].Items[0];
            //if (((CheckBox)pItem.FindControl("chkScopePrivate")).Checked &&
            //    ((CheckBox)pItem.FindControl("chkScopePublic")).Checked) sFilter.Append(" and 1=1");
            //else if (((CheckBox)pItem.FindControl("chkScopePrivate")).Checked) sFilter.Append(" and Scope=0 ");
            //else if (((CheckBox)pItem.FindControl("chkScopePublic")).Checked) sFilter.Append(" and Scope=1 ");
            //else sFilter.Append(" and 1=0 ");

            //// Filter by Group
            //    if (sbG.ToString().Trim().Length > 0)
            //        sFilter.Append(" and ';" + sbG.ToString() + "' like '%;'+ GroupID +';%' ");
                

            //pItem = PanelBar.Items[0].Items[0];
            //if (((RadTextBox)pItem.FindControl("txtFilterName")).Text.Trim().Length > 0)
            //    sFilter.Append(" and Fullname like '%" + ((RadTextBox)pItem.FindControl("txtFilterName")).Text.Trim() + "%' ");
            //if (((RadTextBox)pItem.FindControl("txtFilterOrgName")).Text.Trim().Length > 0)
            //    sFilter.Append(" and OrgName like '%" + ((RadTextBox)pItem.FindControl("txtFilterOrgName")).Text.Trim() + "%' ");
            //if (((RadTextBox)pItem.FindControl("txtFilterTitle")).Text.Trim().Length > 0)
            //    sFilter.Append(" and OrgTitle like '%" + ((RadTextBox)pItem.FindControl("txtFilterTitle")).Text.Trim() + "%' ");
            //if (((RadTextBox)pItem.FindControl("txtFilterEmail")).Text.Trim().Length > 0)
            //    sFilter.Append(" and (OrgEmail1 like '%" + ((RadTextBox)pItem.FindControl("txtFilterEmail")).Text.Trim() +
            //                   "%' ").Append(" or OrgEmail2 like '%" + ((RadTextBox)pItem.FindControl("txtFilterEmail")).Text.Trim() + "%' ) ");
             


            //return sFilter.ToString();
            return "";
        }

        #endregion

        #region "Public Methods"
        public Boolean IsEditable(int owner)
        {
            if (owner.Equals(this.UserId))
            {
                return true;
            }
            // Nếu có quyền quản trị return true;

            return false;
        }
        #endregion

    }
}