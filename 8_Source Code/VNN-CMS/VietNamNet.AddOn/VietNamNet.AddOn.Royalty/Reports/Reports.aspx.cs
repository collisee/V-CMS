using System;
using System.Data;
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;
using Constants = VietNamNet.AddOn.Royalty.Core.Common.Constants;

namespace VietNamNet.AddOn.Royalty
{
    public partial class Reports : RoyaltyBasePageView
    {
        #region Members
      
        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        { 
            
            base.PageLoad();

            if (!isStatistics)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                SetupEnvironment();
            }
        }

        #endregion


        #region Private Methods
           private void  SetupEnvironment()
           {
               
           }
        #endregion


        #region Public Methods

        #endregion
   
   }
}
