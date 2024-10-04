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
using Telerik.Web.UI;
using VietNamNet.AddOn.Royalty.Components;
using VietNamNet.AddOn.Royalty.Core.Common.ValueObject;
using VietNamNet.AddOn.Royalty.Core.Presentation;
using VietNamNet.CMS.Common.ValueObject;
using VietNamNet.CMS.Presentation;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System.Presentation;
using VietNamNet.Framework.System.ValueObject;

namespace VietNamNet.AddOn.Royalty.FundsManager
{
    public partial class EditFund : RoyaltyBasePage
    {
        #region  "Members"
        private int _FundId =0;
        private int _ArticleId;
        private int _SetType;
        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {

            base.PageLoad();

            if (!isFundManager)
            {
                Utilities.NoRightToAccess();
            }

            if (Request.Params["DocId"] != null )
            {
                _ArticleId = Utilities.ParseInt(Request.Params["DocId"]);
            }
            else
            {
                Utilities.ItemDoesntExist();
            }
            if (Request.Params[VietNamNet.AddOn.Royalty.Core.Common.Constants.ParameterName.FUND_ID] != null)
            {
                _FundId = Utilities.ParseInt(Request.Params[VietNamNet.AddOn.Royalty.Core.Common.Constants.ParameterName.FUND_ID]);

            }

            if (!IsPostBack)
            {

                SetupEnvironment();
                PopularArticleInfo(_ArticleId);
                if (Request.Params["settype"] != null && Utilities.ParseInt(Request.Params["settype"]) <= 4)
                {
                    _SetType = Utilities.ParseInt(Request.Params["settype"]);
                    txtSetType.Text = Request.Params["settype"];
                    SetType(Utilities.ParseInt(txtSetType.Text.Trim()));
                }


                PopularFundItem(_FundId);
                
            }

        }

        protected void radToolBarDefault_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        { 
           try
           {
               //lblMessage.Text = ""  + e.Item.Value;
               switch (e.Item.Value)
               {
                   case "GoBack":
                       Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_LISTBYARTICLE
                                   + "?&DocId=" + txtArticleId.Text.Trim());
                       break;
                   case "Update":
                       UpdateItem();
                       Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_LISTBYARTICLE
                                   + "?&DocId=" + txtArticleId.Text.Trim());
                       break;
                   case "Delete":
                       DeleteItem(Utilities.ParseInt(txtFundId.Text.Trim()));
                       Response.Redirect(VietNamNet.AddOn.Royalty.Core.Common.Constants.FormNames.FUND_LISTBYARTICLE
                                   + "?&DocId=" + txtArticleId.Text.Trim());
                       break;
                   case "Cancel":
                       Response.Redirect("Default.aspx"); break;
               }
            }
            catch (Exception exc)
            {
                lblMessage.Text = exc.Message;
            }
            }

        protected void cboTypeParent_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            PopularType();
            PopularTypeDescription();
        }
        protected void cboType_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            PopularTypeDescription();
        }

        protected void GrdViewPageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            //PopularType(e.NewPageIndex);
        }
        protected void GrdViewPageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {

        }
        protected void GrdViewItemCommand(object source, GridCommandEventArgs e)
        {

        }

        protected void cmbIsMember_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SetAuthor();
        }

        protected void cmbGroup_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (!Utilities.Event_Handler(o, e)) return;

            BindDataToUser(Utilities.ParseInt(cmbGroup.SelectedValue) );
        }

        #endregion

        #region Private Methods
        private void SetupEnvironment()
        {
            PopularParentType();
            PopularType();
            PopularTypeDescription();
            PopularGroupUser();
            BindDataToUser(0);
            BindDataToCollaborator();
        }
        private void PopularParentType()
        {
            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            helper.ValueObject.Parent_Id = 0;
            DataTable dt = helper.ListByParent();

            cboTypeParent.DataTextField = "Title";
            cboTypeParent.DataValueField = "Type_Id";
            cboTypeParent.DataSource = dt;
            cboTypeParent.DataBind();  
             
        }
        private void PopularType()
        {
            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            helper.ValueObject.Parent_Id = Utilities.ParseInt(cboTypeParent.SelectedValue);
            DataTable dt = helper.ListByParent();

            cboType.DataTextField = "Title";
            cboType.DataValueField = "Type_Id";
            cboType.DataSource = dt;
            cboType.DataBind();
        }
        private void PopularTypeDescription()
        {
            if (cboType.SelectedIndex < 0)
                cboType.SelectedIndex = 0;

            RoyaltyTypesHelper helper = new RoyaltyTypesHelper(new RoyaltyTypes());
            helper.ValueObject.Type_Id = Utilities.ParseInt(cboType.SelectedValue);
            helper.Load();

            if (helper.ValueObject == null)
            {
                Utilities.ItemDoesntExist();
            }

            lblTypeDescription.Text = helper.ValueObject.Description + "<br/>" +
                                      "<label class='w100'>Thấp nhất:</label><label class='w100 right'>" + helper.ValueObject.MIN_VAL.ToString() + "</label><br/>" +
                                      "<label class='w100'>Cao nhất: </label><label class='w100 right'>" + helper.ValueObject.MAX_VAL.ToString() + "</label>";
        }

        private void PopularGroupUser()
        {
            GroupHelper helper = new GroupHelper(new Group());
            cmbGroup.DataSource = helper.ListAll();
            cmbGroup.DataBind();
            cmbGroup.Items.Insert(0, new RadComboBoxItem("Tất cả", "0"));
            //if (gid > 0) cmbGroup.SelectedValue = gid.ToString();
        }
        private void BindDataToUser(int gid)
        {
            UserHelper helper = new UserHelper(new User());
            if (gid > 0)
            {
                helper.ValueObject.GroupId = gid;
                cmbUser.DataSource = helper.GetUserByGroup();
            }
            else
            {
                cmbUser.DataSource = helper.ListAll();
            }

            cmbUser.DataBind();
        }
        private void BindDataToCollaborator()
        {
            CollaboratorHelper helper = new CollaboratorHelper(new Collaborator());
            cmbCollaborator.DataSource = helper.ListAll();
            cmbCollaborator.DataBind(); 
        }

        private void PopularArticleInfo(int ArticleId)
        {
            txtArticleId.Text = ArticleId.ToString();
            ArticleHelper helper = new ArticleHelper(new Article());
            helper.ValueObject.Id = ArticleId;
            helper.Load();

            if (helper.ValueObject == null) Utilities.ItemDoesntExist();


            //check Status -> policy

            lblArticleInfo.Text = " <label></label>" +
                                  " <label>" + helper.ValueObject.Name + "</label>" +
                                  " <i>Ngày XB: " + String.Format("{0:dd/MM/yyyy HH:mm}", helper.ValueObject.PublishDate) + "</i>";

            cmbIsMember.Items.FindItemByValue(helper.ValueObject.IsMember.ToString()).Selected = true;
            if (cmbUser.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()) != null) cmbUser.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()).Selected = true;
            if (cmbCollaborator.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()) != null) cmbCollaborator.Items.FindItemByValue(helper.ValueObject.AuthorId.ToString()).Selected = true;
            SetAuthor();

        }
        private void PopularFundItem(int FundId)
        {
            if (FundId != 0)
            {
                txtFundId.Text = FundId.ToString();

                RoyaltyFundHelper helper = new RoyaltyFundHelper(new RoyaltyFund());
                helper.ValueObject.Fund_Id = FundId;
                helper.Load();

                if (helper.ValueObject == null)
                {
                    Utilities.ItemDoesntExist();
                }
                else
                {
                    ((RadToolBarButton)radToolBarDefault.Items.FindItemByValue("Delete")).Visible = true;

                    RoyaltyFund obj = helper.ValueObject;

                    txtSetType.Text = obj.Set_Type.ToString();

                    txtTextFund.Text = obj.Text_Fund.ToString();
                    txtImageFund.Text = obj.Image_Fund.ToString();
                    txtAudioFund.Text = obj.Audio_Fund.ToString();
                    txtVideoFund.Text = obj.Video_Fund.ToString();
                    txtOtherFund.Text = obj.Other_Fund.ToString();

                    txtNotes.Text = obj.Notes;

                    cmbIsMember.Items.FindItemByValue(obj.Author_IsMember.ToString()).Selected = true;
                       if (cmbUser.Items.FindItemByValue(obj.Author_Id.ToString())!= null) cmbUser.Items.FindItemByValue(obj.Author_Id.ToString()).Selected = true;
                       if (cmbCollaborator.Items.FindItemByValue(obj.Author_Id.ToString())!=null)  cmbCollaborator.Items.FindItemByValue(obj.Author_Id.ToString()).Selected = true;
                    SetAuthor();

                    // Set Type
                    RoyaltyTypesHelper thelper = new RoyaltyTypesHelper(new RoyaltyTypes());
                    thelper.ValueObject.Type_Id= obj.Type_Id;
                    thelper.Load();
                    if (cboTypeParent.Items.FindItemByValue(thelper.ValueObject.Parent_Id.ToString())!=null) cboTypeParent.Items.FindItemByValue(thelper.ValueObject.Parent_Id.ToString()).Selected = true;
                    PopularType();
                    if (cboType.Items.FindItemByValue(obj.Type_Id.ToString()) != null) cboType.Items.FindItemByValue(obj.Type_Id.ToString()).Selected = true;
                    
                }

                SetType(Utilities.ParseInt(txtSetType.Text.Trim()));
            }
        }

        private void UpdateItem()
        {
            // Valid
            if (Utilities.ParseInt(txtTextFund.Value.ToString()) ==0 &&
                Utilities.ParseInt(txtImageFund.Value.ToString()) == 0 &&
                Utilities.ParseInt(txtAudioFund.Value.ToString()) == 0 &&
                Utilities.ParseInt(txtVideoFund.Value.ToString()) == 0 &&
                Utilities.ParseInt(txtOtherFund.Value.ToString()) == 0)
                    throw new Exception("Hãy nhập thông tin Giá chấm Nhuận bút!");


            // Do save
            RoyaltyFundHelper fHelper = new RoyaltyFundHelper(new RoyaltyFund());
            fHelper.ValueObject.Fund_Id = Utilities.ParseInt(_FundId.ToString());

            fHelper.ValueObject.Article_Id = Utilities.ParseInt(txtArticleId.Text );
            fHelper.ValueObject.Text_Fund = Utilities.ParseInt(txtTextFund.Value.ToString());
            fHelper.ValueObject.Image_Fund = Utilities.ParseInt(txtImageFund.Value.ToString());
            fHelper.ValueObject.Audio_Fund= Utilities.ParseInt(txtAudioFund.Value.ToString());
            fHelper.ValueObject.Video_Fund = Utilities.ParseInt(txtVideoFund.Value.ToString());
            fHelper.ValueObject.Other_Fund = Utilities.ParseInt(txtOtherFund.Value.ToString());

            fHelper.ValueObject.Type_Id = Utilities.ParseInt(cboType.SelectedValue.ToString());
            fHelper.ValueObject.Set_Type = txtSetType.Text.Trim();
            fHelper.ValueObject.Notes = txtNotes.Text.Trim();

            fHelper.ValueObject.Setter_Id = this.UserId;
            fHelper.ValueObject.Pay_Status = 0;

            fHelper.ValueObject.Author_IsMember = Utilities.ParseInt(cmbIsMember.SelectedValue);
            fHelper.ValueObject.Author_Id = Utilities.ParseInt(cmbIsMember.SelectedValue == "1" ? cmbUser.SelectedValue : cmbCollaborator.SelectedValue);

            fHelper.ValueObject.Pay_Date = DateTime.Now;
          
            fHelper.ValueObject.Created_At = DateTime.Now;
            fHelper.ValueObject.Created_By = this.UserId;
            fHelper.ValueObject.Last_Modified_At = DateTime.Now;
            fHelper.ValueObject.Last_Modified_By = this.UserId;

            fHelper.DoSave();



        }

        private void SetType(int type)
        {
            switch (type)
            {
                case 0:
                    lblFundStatus.Text = "Chấm mới";
                    break;
                case 1:
                    lblFundStatus.Text = "Điều chỉnh thêm";
                    break;
                case 2:
                    lblFundStatus.Text = "Điều chỉnh bớt";
                    break;
                case 3:
                    lblFundStatus.Text = "Bổ sung";
                    break;
            }
        }
        private void SetAuthor()
        {
            if (Utilities.ParseInt(cmbIsMember.SelectedValue) == 1)
            {
                plhMember.Visible = true;
                plhNotMember.Visible = false;
            }
            else
            {
                plhMember.Visible = false;
                plhNotMember.Visible = true;
            }
        }

        private void DeleteItem(int fundId)
        {
            RoyaltyFundHelper helper = new RoyaltyFundHelper(new RoyaltyFund());
            helper.ValueObject.Fund_Id = fundId;
            helper.ValueObject.Last_Modified_At = DateTime.Now;
            helper.ValueObject.Last_Modified_By = UserId;

            helper.Delete();
        }
        #endregion

        #region Public Methods

        #endregion

    }
}
