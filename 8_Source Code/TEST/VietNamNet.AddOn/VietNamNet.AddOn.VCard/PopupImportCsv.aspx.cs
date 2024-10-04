using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using VietNamNet.AddOn.VCard.Core.Common;
using VietNamNet.AddOn.VCard.Core.Common.ValueObject;
using VietNamNet.AddOn.VCard.Core.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.AddOn.VCard
{
    public partial class PopupImportCsv : BasePage
    {
        #region  "Controls"

        #endregion

        #region "Event Handlers"
        protected override void OnPreInit(EventArgs e)
        {
            dynamicLayout = false;
            base.OnPreInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            //// test only
            //Session[Constants.Session.USER_ID] = 7;
            //Session[Constants.Session.USER_LOGINNAME] = "dnson";
            //Session[Constants.Session.USER_FULLNAME] = "Đỗ Nam Sơn";
            //Session[Constants.Session.USER_EMAIL] = "dnson@vietnamnet.vn";
            //Session[Constants.Session.USER_STATUS] = "Hoạt động";


            PageLoad();

            if (!isLogged)
            {
                Utilities.NoRightToAccess();
            }

            if (!IsPostBack)
            {
                SetupEnvironment();
            }
        }

        private void Initialize()
        {
        }

        #region "Button event handlers"
      
        protected void CmdUpdateClick(object sender, EventArgs e)
        {
            try
            {
                List<VCards> lstVCard = ReadUploadFileContent();

                lblMessage.Text = "lstVCard:" + lstVCard.Count.ToString();
            } 
            catch ( Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    
        protected void CmdReadClick(object sender, EventArgs e)
        {
            List<VCards> lstVCard = ReadUploadFileContent();
 
            grdView.DataSource = lstVCard;
            grdView.DataBind();
        }
  
        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                List<VCards> lstVCard = new List<VCards>();
                switch (e.Item.Value)
                {
                    case "Read":
                        lstVCard = ReadUploadFileContent();

                        grdView.DataSource = lstVCard;
                        grdView.DataBind();
                        break;
                    case "Update":
                        lstVCard = ReadUploadFileContent();
                        VCardsHelper vHelper;
                        foreach (VCards v in lstVCard   )
                        {
                            vHelper = new VCardsHelper(v);
                            vHelper.DoSave();
                        }

                        lblMessage.Text = "File bao gồm " + lstVCard.Count.ToString() + " thông tin VCard đã được cập nhật ";
                        break;
                    case "Delete":
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }


        }

        #endregion

        #endregion

        #region "Private Methods"
        private List<VCards> ReadUploadFileContent()
        {
                byte[] byt;
                if (FileUpload1.HasFile)
                {
                    //lblMessage.Text = "ContentType:" + FileUpload1.PostedFile.ContentType;
                    //throw new Exception(FileUpload1.PostedFile.ContentType);
                    if (FileUpload1.PostedFile.ContentType.ToString().IndexOf("application/vnd.ms-excel") < 0
                        || FileUpload1.PostedFile.FileName.IndexOf(".csv") < 0)
                        throw new Exception("Sai định dạng file nhập. Hãy tải lên một file csv được xuất từ outlook");
                    
                    byt = FileUpload1.FileBytes;
                }
                else
                {
                    throw new Exception("Chưa tải file");
                }
                string str = System.Text.Encoding.UTF8.GetString(byt);
            try
            { 
                VCardsUtils u = new VCardsUtils();
                DataTable dt = u.ReadFromCsvString(str, true);

                List<VCards> lstVCard = new List<VCards>();
                VCards v = new VCards();
                foreach (DataRow rw in dt.Rows)
                {
                    v = new VCards();
                    foreach (DataColumn col in dt.Columns)
                    {
                        switch (col.ColumnName)
                        {
                            case "Web Page":
                                v.OrgWebsite = rw[col].ToString();break;
                            case "Personal Web Page":
                                v.Homepage = rw[col].ToString(); break;
                            case "Business Web Page":
                                v.OrgWebsite = rw[col].ToString(); break;
                            case "Notes":
                                v.Notes = rw[col].ToString();break;
                            case "E-mail Address":
                                v.OrgEmail1 = rw[col].ToString();break;
                            case "E-mail 2 Address":
                                v.OrgEmail2 = rw[col].ToString();break;
                            case "Mobile Phone":
                                v.HomeMobile = rw[col].ToString();break;
                            case "Home Phone":
                                v.HomePhone = rw[col].ToString(); break;
                            case "Home Fax":
                                v.HomeFax = rw[col].ToString(); break;
                            case "Home Address":
                                v.HomeAdr1 = rw[col].ToString(); break;
                            case "Home Street":
                                v.HomeAdr2 = rw[col].ToString(); break;
                            case "Business Phone":
                                v.OrgMobile = rw[col].ToString(); break;
                            case "Company Main Phone":
                                v.OrgPhone = rw[col].ToString(); break;
                            case "Business Fax":
                                v.OrgFax = rw[col].ToString(); break;
                            case "Company":
                                v.OrgName = rw[col].ToString(); break;
                            case "Job Title":
                                v.OrgFax = rw[col].ToString(); break;
                            case "Department":
                                v.OrgUnit = rw[col].ToString(); break;
                            case "Business Address":
                                v.OrgAdr1 = rw[col].ToString(); break;
                            case "Business Street":
                                v.OrgAdr2 = rw[col].ToString(); break;
                            case "Nickname":
                                v.Nickname = rw[col].ToString(); break;
                            case "Pager":
                                v.Pager = rw[col].ToString(); break;
                            case "Name":
                                v.Fullname = rw[col].ToString(); break;
                            case "Office Location":
                                v.OrgOffice = rw[col].ToString(); break;
                        }
                    }
                    if (v.Fullname.Length <=5 )
                        v.Fullname = rw["First Name"].ToString() + " " + rw["Middle Name"].ToString() + " " + rw["Last Name"].ToString();
                   
 

                    v.Created_At = DateTime.Now;
                    v.Created_By = this.UserId;
                    v.Last_Modified_At = DateTime.Now;
                    v.Last_Modified_By = this.UserId;
                    v.Owner = this.UserId;
                    lstVCard.Add(v);
                }
                return lstVCard;
            }
            catch (Exception ex)
            {
                throw new Exception("Sai định dạng file nhập. Hãy tải lên một file csv được xuất đầy đủ từ Microsoft Outlook");
            }
        }

        private void SetupEnvironment()
        {


        }
        #endregion

        #region "Public Methods"
        #endregion

    }
}