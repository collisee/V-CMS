using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.ComponentModel;
using Telerik.Web.UI;
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;
using SubSonic;

namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class SurveyPublishList : BaseUserControls
    {
        #region Members
        private int _surveyId;
        public int SurveyId
        {
            get {
                _surveyId = int.Parse(txtSurveyId.Text); return _surveyId;
            }
            set { txtSurveyId.Text = value .ToString() ;  _surveyId = int.Parse(txtSurveyId.Text);}
               
        }
        private int _surveyPublishId;
        public int SurveyPublishId
        {
            get
            {
                _surveyPublishId = int.Parse(txtSurveyPublishId.Text); return _surveyPublishId;
            }
            set { txtSurveyPublishId.Text = value.ToString(); _surveyPublishId = int.Parse(txtSurveyPublishId.Text); }

        }

        private SurveyPublishCollection _surveyCol;
        public SurveyPublishCollection SurveyCol
        {
            set { _surveyCol = value; }
        }

        private SurveyModule.DAL.Survey  _survey;
        public SurveyModule.DAL.Survey SurveyU
        {
            get { return _survey; }
            set { _survey = value; }
        }

        public enum eDisplayType
        {
            Category,
            Article 
        };
        private eDisplayType _displayType;
        public eDisplayType DisplayType
        {
            get { return _displayType; }
            set { _displayType = value; }
        }

        #endregion

        #region Properties

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
            }
        }
        protected void OnFilterChanged(object sender, EventArgs e)
        {
            //PopularCategories(0);
        }
        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            //PopularCategories(e.NewPageIndex);
        }
        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Expire":
                        SurveyPublish sp = new SurveyPublish(int.Parse(e.CommandArgument.ToString()));
                        sp.ExpireDate = DateTime.Now;
                        
                        sp.Save();
                        SetupEnvironment();
                        break;
                    case "Config":
                        txtSurveyPublishId.Text = e.CommandArgument.ToString() ;
                        //txtSelectedCategory.Text = (string)e.CommandArgument;
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
            }
        } 
        public void Bind()
        { 
            SetupEnvironment();
        }
        #endregion

        #region Private Members

        private void SetupEnvironment()
        {
            if (_survey != null)
            {
                txtSurveyId.Text = _survey.SurveyId.ToString( );
            }
            else if (SurveyId != 0 && Utilities.IsNullOrEmpty(SurveyId))
            {
                _survey = new SurveyModule.DAL.Survey(SurveyId); 
            }

            if (_displayType == eDisplayType.Article)
            {
                SubSonic.StoredProcedure sproc = SPs.ArticleListBySurvey(SurveyId); 
                DataTable dt = sproc.GetDataSet().Tables[0];
                grdView.DataSource = dt.DefaultView;
            }
            else if (_displayType == eDisplayType.Category)
            {
                 
                SubSonic.StoredProcedure sproc = SPs.CatListBySurvey(SurveyId);
                DataTable dt = sproc.GetDataSet().Tables[0];
                grdView.DataSource = dt.DefaultView;
            } 
           
           
            grdView.DataBind();

        }
        #endregion

    }
}