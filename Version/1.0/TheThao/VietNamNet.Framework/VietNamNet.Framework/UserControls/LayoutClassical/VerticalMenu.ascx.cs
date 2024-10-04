using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.UserControls.LayoutClassical
{
    public partial class VerticalMenu : UserControl
    {
        private bool findNode(RadTreeNode node)
        {
            if (Utilities.StringCompare(Request.Url.AbsolutePath, node.NavigateUrl.Replace("~", string.Empty)))
            {
                node.Selected = true;
                node.Expanded = true;
                return true;
            }
            else if (node.Nodes != null)
            {
                foreach (RadTreeNode nodeChild in node.Nodes)
                {
                    if (findNode(nodeChild))
                    {
                        node.Expanded = true;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool showNode(RadTreeNode node)
        {
            bool flag = !Nulls.IsNullOrEmpty(node.NavigateUrl);
            if (Utilities.StringCompare(node.NavigateUrl.Replace("~", string.Empty), Constants.FormNames.ChangePassword.Replace("~", string.Empty))
               && Session[Constants.Session.USER_PASSWORD] != null)
            {
                flag = (bool)Session[Constants.Session.USER_PASSWORD];
            }
            if (node.Nodes != null && node.Nodes.Count > 0)
            {
                foreach (RadTreeNode sub in node.Nodes)
                {
                    flag |= showNode(sub);
                }
            }

            node.Visible = flag;
            return flag;
        }

        private DataTable ProcessMenu(DataTable menus)
        {
            for (int i = 0; i < menus.Rows.Count; i++)
            {
                DataRow dr = menus.Rows[i];
                int pid = Utilities.ParseInt(dr[SystemConstants.Entities.Menu.FieldName.PId]);
                bool flag = false;
                //find parent id
                if (pid > 0)
                {
                    for (int j = 0; j < menus.Rows.Count; j++)
                    {
                        if (i != j)
                        {
                            DataRow drParent = menus.Rows[j];
                            int parentId = Utilities.ParseInt(drParent[SystemConstants.Entities.Menu.FieldName.Id]);
                            if (parentId == pid)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }

                if (!flag && pid > 0)
                {
                    dr[SystemConstants.Entities.Menu.FieldName.PId] = DBNull.Value;
                }
            }
            return menus;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int UserId = Utilities.StringCompare(Utilities.GetConfigKey(Constants.ConfigKey.Security),
                                                 Constants.Security.ON.ToString())
                             ? Utilities.ParseInt(Session[Constants.Session.USER_ID])
                             : -1;

            if (Session[Constants.Session.MENU] == null && UserId != 0)
            {
                MenuHelper helper = new MenuHelper(new Menu());
                helper.ValueObject.UserId = UserId;
                Session[Constants.Session.MENU] = ProcessMenu(helper.GetMenuByUserId());
            }

            if (UserId == 0)
            {
                Session[Constants.Session.MENU] = null;
            }

            radMenu.DataSource = Session[Constants.Session.MENU];
            radMenu.DataBind();

            //copyright
            RadTreeNode system = new RadTreeNode("Tr&#7907; gi&#250;p", string.Empty);
            RadTreeNode help = new RadTreeNode("Th&#244;ng tin tr&#7907; gi&#250;p", string.Empty);
            help.NavigateUrl = Constants.FormNames.Help;
            help.ImageUrl = "~/Images/SmallIcon/51.png";
            help.Target = "_blank";
            RadTreeNode info = new RadTreeNode("Th&#244;ng tin h&#7879; th&#7889;ng", string.Empty);
            info.NavigateUrl = Constants.FormNames.SystemInfo;
            info.ImageUrl = "~/Images/SmallIcon/77.png";
            info.Target = "_blank";
            RadTreeNode copy =
                new RadTreeNode("&copy; 2010 " + Utilities.GetConfigKey(Constants.ConfigKey.CopyrightName), string.Empty);
            copy.NavigateUrl = Utilities.GetConfigKey(Constants.ConfigKey.CopyrightLink);
            copy.ImageUrl = "~/Images/SmallIcon/9.png";
            copy.Target = "_blank";
            RadTreeNode power =
                new RadTreeNode("Cung c&#7845;p b&#7903;i " + Utilities.GetConfigKey(Constants.ConfigKey.PoweredName),
                                string.Empty);
            power.NavigateUrl = Utilities.GetConfigKey(Constants.ConfigKey.PoweredLink);
            power.ImageUrl = "~/Images/SmallIcon/49.png";
            power.Target = "_blank";
            system.Nodes.Add(help);
            system.Nodes.Add(info);
            //system.Nodes.Add(power);
            system.Nodes.Add(copy);

            radMenu.Nodes.Add(system);

            //radMenu.ExpandAllNodes();

            //focus
            foreach (RadTreeNode node in radMenu.Nodes)
            {
                if (findNode(node)) break;
            }

            //hide empty node
            foreach (RadTreeNode node in radMenu.Nodes)
            {
                showNode(node);
            }
        }

        protected void radMenu_NodeDataBound(object sender, RadTreeNodeEventArgs e)
        {
            e.Node.Visible = !Utilities.StringCompare(((DataRowView)e.Node.DataItem)["Name"], "Separator");
        }
    }
}