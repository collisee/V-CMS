using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.Framework.System
{
    public class AuditTrail : UserControl
    {
        //Get user lastmodified
        protected int GetCurrentUserId()
        {
            return Utilities.ParseInt(Session[Constants.Session.USER_ID]);
        }

        protected string GetCurrentUserName()
        {
            return Nulls.IsNullOrEmpty(Session[Constants.Session.USER_FULLNAME])
                       ? string.Empty
                       : Session[Constants.Session.USER_FULLNAME].ToString();
        }

        protected string GetUserNameById(int id)
        {
            UserHelper helper = new UserHelper(new User());
            helper.ValueObject.Id = id;
            helper.Load();
            return (helper.ValueObject == null) ? string.Empty : helper.ValueObject.FullName;
        }

        protected void lbtnCreatedBy_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            HiddenField hidCreatedBy = (HiddenField)this.FindControl("hidCreatedBy");
            if (hidCreatedBy != null) Utilities.Redirect(Constants.FormNames.UserInfo, hidCreatedBy.Value);
        }

        protected void lbtnLastModifiedBy_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            HiddenField hidLastModifiedBy = (HiddenField)this.FindControl("hidLastModifiedBy");
            if (hidLastModifiedBy != null) Utilities.Redirect(Constants.FormNames.UserInfo, hidLastModifiedBy.Value);
        }

        public void Get(object obj)
        {
            Label lblCreatedAt = (Label)this.FindControl("lblCreatedAt");
            HiddenField hidCreatedBy = (HiddenField)this.FindControl("hidCreatedBy");
            LinkButton lbtnCreatedBy = (LinkButton)this.FindControl("lbtnCreatedBy");
            Label lblLastModifiedAt = (Label)this.FindControl("lblLastModifiedAt");
            HiddenField hidLastModifiedBy = (HiddenField)this.FindControl("hidLastModifiedBy");
            LinkButton lbtnLastModifiedBy = (LinkButton)this.FindControl("lbtnLastModifiedBy");

            if (lblCreatedAt != null && hidCreatedBy != null && lbtnCreatedBy != null
                && lblLastModifiedAt != null && hidLastModifiedBy != null && lbtnLastModifiedBy != null)
            {
                if (obj == null)
                {
                    lblCreatedAt.Text =
                        Utilities.ParseDateTime(DateTime.Now,
                                                Utilities.GetConfigKey(Constants.ConfigKey.DisplayDateTimeFormat));
                    hidCreatedBy.Value = GetCurrentUserId().ToString();
                    lbtnCreatedBy.Text = GetCurrentUserName();
                    lblLastModifiedAt.Text =
                        Utilities.ParseDateTime(DateTime.Now,
                                                Utilities.GetConfigKey(Constants.ConfigKey.DisplayDateTimeFormat));
                    hidLastModifiedBy.Value = GetCurrentUserId().ToString();
                    lbtnLastModifiedBy.Text = GetCurrentUserName();
                }
                else
                {
                    DateTime dCreated =
                        Convert.ToDateTime(Utilities.GetProperty(obj, SystemConstants.Entities.BaseFieldName.Created_At));
                    int iCreatedId =
                        Utilities.ParseInt(Utilities.GetProperty(obj, SystemConstants.Entities.BaseFieldName.Created_By));
                    DateTime dLastModified =
                        Convert.ToDateTime(
                            Utilities.GetProperty(obj, SystemConstants.Entities.BaseFieldName.Last_Modified_At));
                    int iLastModifiedId =
                        Utilities.ParseInt(
                            Utilities.GetProperty(obj, SystemConstants.Entities.BaseFieldName.Last_Modified_By));

                    lblCreatedAt.Text =
                        Utilities.ParseDateTime(dCreated,
                                                Utilities.GetConfigKey(Constants.ConfigKey.DisplayDateTimeFormat));
                    hidCreatedBy.Value = iCreatedId.ToString();
                    lbtnCreatedBy.Text = GetUserNameById(iCreatedId);
                    lblLastModifiedAt.Text =
                        Utilities.ParseDateTime(dLastModified,
                                                Utilities.GetConfigKey(Constants.ConfigKey.DisplayDateTimeFormat));
                    hidLastModifiedBy.Value = iLastModifiedId.ToString();
                    lbtnLastModifiedBy.Text = GetUserNameById(iLastModifiedId);
                }
            }
        }

        public void Set(object obj)
        {
            Label lblCreatedAt = (Label) this.FindControl("lblCreatedAt");
            HiddenField hidCreatedBy = (HiddenField) this.FindControl("hidCreatedBy");

            //set value for CreateAt and CreateBy
            if (lblCreatedAt != null && hidCreatedBy != null)
            {
                Utilities.SetProperty(obj, SystemConstants.Entities.BaseFieldName.Created_At,
                                      Utilities.ConvertLocaltoGlobalDateTime(lblCreatedAt.Text));
                Utilities.SetProperty(obj, SystemConstants.Entities.BaseFieldName.Created_By,
                                      Utilities.ParseInt(hidCreatedBy.Value));
                Utilities.SetProperty(obj, SystemConstants.Entities.BaseFieldName.Last_Modified_At, DateTime.Now);
                Utilities.SetProperty(obj, SystemConstants.Entities.BaseFieldName.Last_Modified_By, GetCurrentUserId());
            }
        }
    }
}