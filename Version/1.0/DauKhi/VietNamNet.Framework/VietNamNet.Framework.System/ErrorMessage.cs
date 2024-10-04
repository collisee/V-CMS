using System.Web.UI;
using System.Web.UI.WebControls;

namespace VietNamNet.Framework.System
{
    public class ErrorMessage : UserControl
    {
        public void AddMessage(string strMsg)
        {
            BulletedList bllMessage = (BulletedList)this.FindControl("bllMessage");
            if (bllMessage != null) bllMessage.Items.Add(new ListItem(strMsg));
        }

        public void ClearMessage()
        {
            BulletedList bllMessage = (BulletedList)this.FindControl("bllMessage");
            if (bllMessage != null) bllMessage.Items.Clear();
        }
    }
}