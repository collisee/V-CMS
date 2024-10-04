using System;
using System.Data;
using System.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System.Presentation;
using Telerik.Web.UI;

namespace VietNamNet.Framework.UserControls.LayoutDefault
{
    public partial class SystemMenu : UserControl
    {
        private bool showMenu(RadMenuItem item)
        {
            bool flag = !Nulls.IsNullOrEmpty(item.NavigateUrl);
            if (Utilities.StringCompare(item.NavigateUrl.Replace("~", string.Empty), Constants.FormNames.ChangePassword.Replace("~", string.Empty))
                && Session[Constants.Session.USER_PASSWORD] != null)
            {
                flag = (bool)Session[Constants.Session.USER_PASSWORD];
            }

            if (item.Items != null && item.Items.Count > 0)
            {
                foreach (RadMenuItem sub in item.Items)
                {
                    flag |= showMenu(sub);
                }
            }

            item.Visible = flag | item.IsSeparator;
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
            if (!IsPostBack)
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

                //user infor
                if (UserId > 0)
                {
                    string userName = Nulls.IsNullOrEmpty(Session[Constants.Session.USER_FULLNAME])
                                          ? string.Empty
                                          : Session[Constants.Session.USER_FULLNAME].ToString();
                    foreach (RadMenuItem item in radMenu.Items)
                    {
                        if (Utilities.ParseInt(item.Value) == -1)
                        {
                            item.Text = userName;
                            break;
                        }
                    }
                }
                else
                {
                    RadMenuItem menuLogin = new RadMenuItem("&#272;&#259;ng nh&#7853;p", Constants.FormNames.Login);
                    radMenu.Items.Add(menuLogin);
                    RadMenuItem menuFindPwd = new RadMenuItem("Quên m&#7853;t kh&#7849;u", Constants.FormNames.FindPassword);
                    radMenu.Items.Add(menuFindPwd);
                }
                //copyright
                RadMenuItem system = new RadMenuItem("Tr&#7907; gi&#250;p", string.Empty);
                RadMenuItem help = new RadMenuItem("Th&#244;ng tin tr&#7907; gi&#250;p", Constants.FormNames.Help);
                help.ImageUrl = "~/Images/SmallIcon/51.png";
                help.Target = "_blank";
                RadMenuItem info = new RadMenuItem("Th&#244;ng tin h&#7879; th&#7889;ng", Constants.FormNames.SystemInfo);
                info.ImageUrl = "~/Images/SmallIcon/77.png";
                info.Target = "_blank";
                RadMenuItem copy =
                    new RadMenuItem(
                        "&copy; 2010 " + Utilities.GetConfigKey(Constants.ConfigKey.CopyrightName),
                        Utilities.GetConfigKey(Constants.ConfigKey.CopyrightLink));
                copy.ImageUrl = "~/Images/SmallIcon/9.png";
                copy.Target = "_blank";
                RadMenuItem sep = new RadMenuItem(string.Empty, string.Empty);
                sep.IsSeparator = true;
                RadMenuItem power =
                    new RadMenuItem(
                        "Cung c&#7845;p b&#7903;i " + Utilities.GetConfigKey(Constants.ConfigKey.PoweredName),
                        Utilities.GetConfigKey(Constants.ConfigKey.PoweredLink));
                power.ImageUrl = "~/Images/SmallIcon/49.png";
                power.Target = "_blank";
                system.Items.Add(help);
                system.Items.Add(info);
                system.Items.Add(sep);
                //system.Items.Add(power);
                system.Items.Add(copy);
                radMenu.Items.Add(system);

                //hide empty menu
                foreach (RadMenuItem item in radMenu.Items)
                {
                    showMenu(item);
                }
            }
        }

        protected void radMenu_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            if (Utilities.StringCompare(((DataRowView)e.Item.DataItem)["Name"], "Separator"))
            {
                e.Item.IsSeparator = true;
                e.Item.Text = string.Empty;
            }
        }
    }
}