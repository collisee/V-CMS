using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.AddOn.Royalty.Components;


namespace VietNamNet.AddOn.Survey.UserControls
{
    public partial class ArticleInfo : BaseUserControls
    {

        #region Members
        private int _articleId = 0;
        public int ArticleId
        {
            get { return _articleId; }
            set { _articleId = value; }
        }

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Public Methods
        public void Bind()
        {
            SetupEnvironment();
        }
        #endregion

        #region Private Methods

        private void SetupEnvironment()
        {
            if (_articleId!=0)
            {
                
            }

        }

        #endregion

    }
}