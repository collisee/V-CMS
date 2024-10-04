using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Survey.Components
{
    public class SurveyBasePage : BasePage
    {
        #region Members
        protected bool isSystem = false;
        protected string systemAlias = string.Empty;

        protected bool isPublisher = false;
        protected string publishAlias = string.Empty;

        #endregion

        protected override void PageLoad()
        {
            Initialize();
             base.PageLoad();
        }

        public void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Survey";
            viewAlias = "VietNamNet.AddOn.Survey.View";
            addNewAlias = "VietNamNet.AddOn.Survey.AddNew";
            updateAlias = "VietNamNet.AddOn.Survey.Update";
            deleteAlias = "VietNamNet.AddOn.Survey.Delete";
            publishAlias = "VietNamNet.AddOn.Survey.Publish";
            systemAlias = "VietNamNet.AddOn.Survey.System";
        }

        protected override void GetPolicy()
        {
            base.GetPolicy();

            isPublisher = SystemUtils.GetPolicy(UserId, moduleAlias, publishAlias);
            isSystem = SystemUtils.GetPolicy(UserId, moduleAlias, systemAlias);


            ////test only
            //isViewer = true;
            //isAddNewer = true;
            //isUpdater = true;
            //isDeleter = true;
            //isPublisher = true;

        }

    }
}
