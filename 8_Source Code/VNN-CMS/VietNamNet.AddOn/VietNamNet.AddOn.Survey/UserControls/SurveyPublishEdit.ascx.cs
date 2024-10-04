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
using VietNamNet.AddOn.Survey.Components;
using VietNamNet.AddOn.SurveyModule.DAL;
using VietNamNet.Framework.Common;

namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class SurveyPublishEdit : BaseUserControls
    {
        #region Members

        private SurveyModule.DAL.SurveyPublish _surveyPublish;
        
        public SurveyModule.DAL.SurveyPublish SurveyPublish1
        {
            get
            {
                if (txtSurveyPublishId.Text.Trim() != "")
                    _surveyPublish = new SurveyPublish(int.Parse(txtSurveyPublishId.Text.Trim()));
                else
                    _surveyPublish = new SurveyPublish();
                if (txtSurveyId.Text !="") _surveyPublish.SurveyId = int.Parse(txtSurveyId.Text);
                
                if (txtCatId.Text.Trim() != "") _surveyPublish.CategoryId = int.Parse(txtCatId.Text);
                if (txtArticleId.Text.Trim() != "") _surveyPublish.ArticleId  = int.Parse(txtArticleId.Text);
                _surveyPublish.StartDate = txtStartDate.SelectedDate.Value;
                _surveyPublish.ExpireDate = txtExpireDate.SelectedDate.Value;
                _surveyPublish.Security = byte.Parse(radSecurity.SelectedValue);
                _surveyPublish.Status = byte.Parse(txtStatus.Text == "" ?( 0 ).ToString() : txtStatus.Text);
                _surveyPublish.IsActive = true;
                _surveyPublish.CreatedBy = UserId.ToString();
                //_surveyPublish.ModifiedBy = UserId.ToString();

                return _surveyPublish;
            }
            set { _surveyPublish = value; }
        }

        #endregion

        #region Properties

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (! Page.IsPostBack )
            {
                SetupEnvironment();
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
            txtStartDate.MinDate = Utilities.GetMinDate();
            txtExpireDate.MinDate = Utilities.GetMinDate();

            if (_surveyPublish!= null){
                if (_surveyPublish.SurveyId != null) txtSurveyId.Text = _surveyPublish.SurveyId.ToString();
                txtSurveyPublishId.Text = _surveyPublish.SurveyPublishId.ToString();
                txtCatId.Text = _surveyPublish.CategoryId.ToString()  ;
                txtArticleId.Text =  _surveyPublish.ArticleId.ToString() ;
                if (_surveyPublish.StartDate != null && _surveyPublish.StartDate.CompareTo(Utilities.GetMinDate())>0 ) txtStartDate.SelectedDate = _surveyPublish.StartDate;
                if (_surveyPublish.ExpireDate != null && _surveyPublish.ExpireDate.CompareTo(Utilities.GetMinDate()) > 0) txtExpireDate.SelectedDate = _surveyPublish.ExpireDate;
                radSecurity.Items.FindByValue( _surveyPublish.Security.ToString( )  ).Selected = true;
                txtStatus.Text=   _surveyPublish.Status.ToString( )  ;
            }else
            {
                txtStartDate.SelectedDate = DateTime.Now;
                txtExpireDate.SelectedDate = DateTime.Now.AddDays(7);

            }
        }
        #endregion

    }
}