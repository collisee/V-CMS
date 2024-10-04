using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.DBAccess;
using VietNamNet.Framework.System.ValueObject;
using VietNamNet.Framework.System;
using VietNamNet.Framework.System.Presentation;

namespace VietNamNet.Framework.Administrator
{
    public partial class UserDisplay : BasePage
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
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0)
                {
                    UserHelper helper = new UserHelper(new User());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    BindData(helper.ValueObject);
                    AuditTrail1.Get(helper.ValueObject);

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;

                    //check save success
                    if (Utilities.ParseInt(Request.Params[Constants.ParameterName.SAVE_SUCCESS]) == 1)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = Utilities.GetConfigKey(SystemConstants.Message.SaveSuccess);
                    }
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }
            }
            else
            {
                lblMessage.Visible = false;
            }

            //show hide AddNew button
            radToolBarDefault.Items[0].Visible = radToolBarDefault.Items[0].Enabled = isAddNewer;
            radToolBarDefault.Items[1].Visible = radToolBarDefault.Items[1].Enabled = isUpdater;
            radToolBarDefault.Items[2].Visible = radToolBarDefault.Items[2].Enabled = isDeleter;
        }

        private void Initialize()
        {
            moduleAlias = "System.Administrator";
            viewAlias = "System.Administrator.View";
            addNewAlias = "System.Administrator.AddNew";
            updateAlias = "System.Administrator.Update";
            deleteAlias = "System.Administrator.Delete";
        }

        private void BindData(User o)
        {
            lblStatus.Text = o.Status;
            lblLoginName.Text = o.LoginName;
            lblFullName.Text = o.FullName;
            lblEmail.Text = o.Email;
            lblAvatar.Text = o.Avatar;
            hidAvatar.Value = o.Avatar;
            lblBirthday.Text = Utilities.FormatDisplayDateOnly(o.Birthday);
            lblSex.Text = o.Sex;
            lblAddress.Text = o.Address;
            lblPhone.Text = o.Phone;
            lblMobile.Text = o.Mobile;
            lblYahoo.Text = o.Yahoo;
            lblSkype.Text = o.Skype;
            lblFacebook.Text = o.Facebook;
            lblDetail.Text = o.Detail;
            //radGridMemberOf.DataSource = o.MemberOf;
            //radGridMemberOf.DataBind();
            ViewState[SystemConstants.ViewState.SystemData.MemberOf] = o.MemberOf;
        }

        protected void radToolBarDefault_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            switch (((RadToolBarButton) e.Item).CommandName)
            {
                case Constants.CommandNames.AddNew:
                    Utilities.Redirect(SystemConstants.FormNames.Administrator.UserEdit);
                    break;
                case Constants.CommandNames.Edit:
                    if (Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.DOC_ID]))
                    {
                        Utilities.ItemDoesntExist();
                    }
                    else
                    {
                        Utilities.Redirect(SystemConstants.FormNames.Administrator.UserEdit,
                                             Request.Params[Constants.ParameterName.DOC_ID]);
                    }
                    break;
                case Constants.CommandNames.Delete:
                    int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);

                    UserHelper helper = new UserHelper(new User());
                    helper.ValueObject.Id = docId;
                    helper.ValueObject.Last_Modified_At = DateTime.Now;
                    helper.ValueObject.Last_Modified_By = UserId;
                    helper.Delete();

                    //Go to View
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.UserView);
                    break;
                case Constants.CommandNames.GoBacktoView:
                    Utilities.GoBackToView(SystemConstants.FormNames.Administrator.UserView);
                    break;
                default:
                    break;
            }
        }

        protected void radGridMemberOf_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtMemberOf = (ViewState[SystemConstants.ViewState.SystemData.MemberOf] != null)
                                    ? (DataTable)ViewState[SystemConstants.ViewState.SystemData.MemberOf]
                                    : GroupMemberDAO.GetTemplateTable();
            radGridMemberOf.DataSource = dtMemberOf.Select("SaveStatus <> 'DELETE'");
        }
    }
}