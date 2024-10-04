using System;
using System.Web;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS
{
    public partial class CategoryTreeView : BasePage
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
                BindDataToCategory();

                //show hide AddNew button
                radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
                radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isAddNewer;
                //show hide TreeView Context menu
                radTreeViewCategory.ContextMenus[0].Items[0].Visible = isAddNewer; //Them menu con
                radTreeViewCategory.ContextMenus[0].Items[1].Visible = isViewer; //Xem thong tin menu
                radTreeViewCategory.ContextMenus[0].Items[2].Visible = isUpdater; //Sua thong tin menu
                radTreeViewCategory.ContextMenus[0].Items[4].Visible = isAddNewer; //Copy menu
                radTreeViewCategory.ContextMenus[0].Items[5].Visible = isUpdater; //Doi ten menu
                radTreeViewCategory.ContextMenus[0].Items[6].Visible = isDeleter; //Xoa menu
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.CMS.Category";
            viewAlias = "VietNamNet.CMS.Category.View";
            addNewAlias = "VietNamNet.CMS.Category.AddNew";
            updateAlias = "VietNamNet.CMS.Category.Update";
            deleteAlias = "VietNamNet.CMS.Category.Delete";
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryEdit);
                    break;
                case Constants.CommandNames.Optimize:
                    //Optimize
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.OptimizeCategory();
                    break;
                default:
                    break;
            }
        }

        private void BindDataToCategory()
        {
            CategoryHelper helper = new CategoryHelper(new Category());
            radTreeViewCategory.DataSource = helper.ListAll();
            radTreeViewCategory.DataBind();
        }

        protected void radTreeViewCategory_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
        {
            string url = HttpUtility.UrlEncode(Request.Url.PathAndQuery);
            switch (e.MenuItem.Value)
            {
                case "AddNew":
                    string strAddNew = string.Format("{0}?{1}={2}&{3}={4}", CMSConstants.FormNames.CMS.CategoryEdit,
                                                     Constants.ParameterName.PARENT_ID, e.Node.Value,
                                                     Constants.ParameterName.GOBACK, url);
                    Response.Redirect(strAddNew);
                    break;
                case "View":
                    Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryDisplay, e.Node.Value);
                    break;
                case "Edit":
                    Utilities.Redirect(CMSConstants.FormNames.CMS.CategoryEdit, e.Node.Value);
                    break;
                case "Copy":
                    string strCopy = string.Format("{0}?{1}={2}&{3}={4}", CMSConstants.FormNames.CMS.CategoryEdit,
                                                   Constants.ParameterName.COPY_ID, e.Node.Value,
                                                   Constants.ParameterName.GOBACK, url);
                    Response.Redirect(strCopy);
                    break;
                case "Delete":
                    //Update db
                    CategoryHelper helper = new CategoryHelper(new Category());
                    helper.ValueObject.Id = Utilities.ParseInt(e.Node.Value);
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Delete menu
                    e.Node.Remove();
                    break;
            }
        }

        protected void radTreeViewCategory_NodeEdit(object sender, RadTreeNodeEditEventArgs e)
        {
            //Rename
            e.Node.Text = e.Text;

            //Update db
            CategoryHelper helper = new CategoryHelper(new Category());
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
            CategoryHelper sourceHelper = new CategoryHelper(new Category());
            sourceHelper.ValueObject.Id = sourceId;
            sourceHelper.Load();
            CategoryHelper destHelper = new CategoryHelper(new Category());
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
            sourceHelper.UpdateCategoryPIdAndOrder();
        }

        protected void radTreeViewCategory_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
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