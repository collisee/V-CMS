using System;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.Union
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            PageLoad();

            //if (!isViewer)
            //{
            //    Utilities.NoRightToAccess();
            //}
        }

        private void Initialize()
        {
            moduleAlias = "VietNamNet.AddOn.Union";
            viewAlias = "VietNamNet.AddOn.Union.View";
            addNewAlias = "VietNamNet.AddOn.Union.AddNew";
            updateAlias = "VietNamNet.AddOn.Union.Update";
            deleteAlias = "VietNamNet.AddOn.Union.Delete";
        }

        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
    }
}