using System;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.MediaManager
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }
        }
    }
}