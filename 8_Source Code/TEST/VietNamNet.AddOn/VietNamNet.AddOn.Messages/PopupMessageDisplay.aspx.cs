using System;
using System.Web;
using VietNamNet.AddOn.Messages.Common;
using VietNamNet.AddOn.Messages.Common.ValueObject;
using VietNamNet.AddOn.Messages.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Messages
{
    public partial class PopupMessageDisplay : BasePage
    {
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                //Load Data
                int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
                if (docId > 0)
                {
                    MessageDeliveryHelper helper = new MessageDeliveryHelper(new MessageDelivery());
                    helper.ValueObject.Id = docId;
                    helper.LoadEncode();

                    if (helper.ValueObject == null)
                    {
                        Utilities.ItemDoesntExist();
                    }

                    //check security
                    if (!isSystem && helper.ValueObject.ToUserId != UserId)
                    {
                        Utilities.NoRightToAccess();
                    }

                    BindData(helper.ValueObject);

                    if (Utilities.StringCompare(HttpUtility.HtmlDecode(helper.ValueObject.Status), MessagesConstants.MessageStatus.UnRead))
                    {
                        helper.ValueObject.Status = MessagesConstants.MessageStatus.Read;
                        helper.ValueObject.Last_Modified_At = DateTime.Now;
                        helper.ValueObject.Last_Modified_By = UserId;
                        helper.DoSave();
                    }

                    //Store view states
                    ViewState[Constants.ParameterName.DOC_ID] = helper.ValueObject.Id;
                }
                else
                {
                    Utilities.ItemDoesntExist();
                }
            }
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Messages";
            viewAlias = "VietNamNet.AddOn.Messages.View";
            addNewAlias = "VietNamNet.AddOn.Messages.AddNew";
            updateAlias = "VietNamNet.AddOn.Messages.Update";
            deleteAlias = "VietNamNet.AddOn.Messages.Delete";
            systemAlias = "VietNamNet.AddOn.Messages.System";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }

        private void BindData(MessageDelivery o)
        {
            hidUserId.Value = o.FromUserId.ToString();
            lblUserName.Text = o.UserName;
            lblDateTime.Text = Utilities.FormatDisplayDateTime(o.Created_At);
            lblSubject.Text = o.Subject;
            hidSubject.Value = HttpUtility.UrlEncode(string.Format("RE: {0}", o.Subject));
            lblDetail.Text = o.Detail.Replace("\r\n", "<br />");
        }
    }
}