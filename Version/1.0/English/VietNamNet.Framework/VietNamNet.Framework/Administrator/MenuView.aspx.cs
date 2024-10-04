using System;
using System.Web;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System.Presentation;
using Telerik.Web.UI;

namespace VietNamNet.Framework.Administrator
{
    public partial class MenuView : BasePage
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
                BindDataToMenu();

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
                radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isAddNewer;
                //show hide TreeView Context menu
                radTreeViewMenu.ContextMenus[0].Items[0].Visible = isAddNewer; //Them menu con
                radTreeViewMenu.ContextMenus[0].Items[1].Visible = isViewer; //Xem thong tin menu
                radTreeViewMenu.ContextMenus[0].Items[2].Visible = isUpdater; //Sua thong tin menu
                radTreeViewMenu.ContextMenus[0].Items[4].Visible = isAddNewer; //Copy menu
                radTreeViewMenu.ContextMenus[0].Items[5].Visible = isUpdater; //Doi ten menu
                radTreeViewMenu.ContextMenus[0].Items[6].Visible = isDeleter; //Xoa menu
            }
        }

        private void Initialize()
        {
            moduleAlias = "System.Configuration";
            viewAlias = "System.Configuration.View";
            addNewAlias = "System.Configuration.AddNew";
            updateAlias = "System.Configuration.Update";
            deleteAlias = "System.Configuration.Delete";
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.MenuEdit);
                    break;
                case Constants.CommandNames.Optimize:
                    //Optimize
                    MenuHelper helper = new MenuHelper(new Menu());
                    helper.OptimizeMenu();
                    break;
                default:
                    break;
            }
        }

        private void BindDataToMenu()
        {
            MenuHelper helper = new MenuHelper(new Menu());
            radTreeViewMenu.DataSource = helper.ListAll();
            radTreeViewMenu.DataBind();
        }

        protected void radTreeViewMenu_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
        {
            string url = HttpUtility.UrlEncode(Request.Url.PathAndQuery);
            switch (e.MenuItem.Value)
            {
                case "AddNew":
                    string strAddNew = string.Format("{0}?{1}={2}&{3}={4}", SystemConstants.FormNames.Administrator.MenuEdit,
                                                     Constants.ParameterName.PARENT_ID, e.Node.Value,
                                                     Constants.ParameterName.GOBACK, url);
                    Response.Redirect(strAddNew);
                    break;
                case "View":
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.MenuDisplay, e.Node.Value);
                    break;
                case "Edit":
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.MenuEdit, e.Node.Value);
                    break;
                case "Copy":
                    string strCopy = string.Format("{0}?{1}={2}&{3}={4}", SystemConstants.FormNames.Administrator.MenuEdit,
                                                   Constants.ParameterName.COPY_ID, e.Node.Value,
                                                   Constants.ParameterName.GOBACK, url);
                    Response.Redirect(strCopy);
                    break;
                case "Delete":
                    //Update db
                    MenuHelper helper = new MenuHelper(new Menu());
                    helper.ValueObject.Id = Utilities.ParseInt(e.Node.Value);
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Delete menu
                    e.Node.Remove();
                    break;
            }
        }

        protected void radTreeViewMenu_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
        {
            //Rename
            e.Node.Text = e.Text;

            //Update db
            MenuHelper helper = new MenuHelper(new Menu());
            helper.ValueObject.Id = Utilities.ParseInt(e.Node.Value);
            helper.Load();

            if (helper.ValueObject != null)
            {
                helper.ValueObject.Name = e.Text;
                helper.ValueObject.DisplayName = e.Text;
                helper.ValueObject.Last_Modified_At = DateTime.Now;
                helper.ValueObject.Last_Modified_By = UserId;
                helper.DoSave();
            }
        }

        private void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode,
                                        RadTreeNode destNode)
        {
            if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
            {
                return;
            }

            int sourceId = Utilities.ParseInt(sourceNode.Value);
            int destId = Utilities.ParseInt(destNode.Value);

            //load object
            MenuHelper sourceHelper = new MenuHelper(new Menu());
            sourceHelper.ValueObject.Id = sourceId;
            sourceHelper.Load();
            MenuHelper destHelper = new MenuHelper(new Menu());
            destHelper.ValueObject.Id = destId;
            destHelper.Load();

            if (sourceHelper.ValueObject == null || destHelper.ValueObject == null)
            {
                return;
            }

            //perform action
            sourceNode.Owner.Nodes.Remove(sourceNode);
            switch (dropPosition)
            {
                case RadTreeViewDropPosition.Over:
                    // child
                    if (!sourceNode.IsAncestorOf(destNode))
                    {
                        destNode.Nodes.Insert(0, sourceNode);
                        //get new PId and Order
                        sourceHelper.ValueObject.PId = destHelper.ValueObject.Id;
                        sourceHelper.ValueObject.Ord = 1;
                    }
                    break;

                case RadTreeViewDropPosition.Above:
                    // sibling - above                    
                    destNode.InsertBefore(sourceNode);
                    //get new PId and Order
                    sourceHelper.ValueObject.PId = destHelper.ValueObject.PId;
                    sourceHelper.ValueObject.Ord = destHelper.ValueObject.Ord;
                    break;

                case RadTreeViewDropPosition.Below:
                    // sibling - below
                    destNode.InsertAfter(sourceNode);
                    //get new PId and Order
                    sourceHelper.ValueObject.PId = destHelper.ValueObject.PId;
                    sourceHelper.ValueObject.Ord = destHelper.ValueObject.Ord + 1;
                    break;
            }

            //update source
            sourceHelper.ValueObject.Last_Modified_At = DateTime.Now;
            sourceHelper.ValueObject.Last_Modified_By = UserId;
            sourceHelper.UpdateMenuPIdAndOrder();
        }

        protected void radTreeViewMenu_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {
            RadTreeNode sourceNode = e.SourceDragNode;
            RadTreeNode destNode = e.DestDragNode;
            RadTreeViewDropPosition dropPosition = e.DropPosition;

            if (destNode != null) //drag&drop is performedd
            {
                PerformDragAndDrop(dropPosition, sourceNode, destNode);
                destNode.Expanded = true;
                sourceNode.TreeView.ClearSelectedNodes();
            }
        }
    }
}