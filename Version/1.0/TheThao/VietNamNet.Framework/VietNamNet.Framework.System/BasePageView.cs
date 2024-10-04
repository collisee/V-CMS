using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using VietNamNet.Framework.Biz;
using VietNamNet.Framework.Common;
using Telerik.Web.UI;

namespace VietNamNet.Framework.System
{
    public abstract class BasePageView : BasePage
    {
        #region Properties

        protected string ActionName = string.Empty;
        protected string ServiceName = string.Empty;
        protected int CurrenPage = 0;
        protected DropDownList DropDownListChoiceIndexOfPage;
        protected GridView GridViewDefault;
        protected ImageButton ImageButtonFirst;
        protected ImageButton ImageButtonLast;
        protected ImageButton ImageButtonNext;
        protected ImageButton ImageButtonPrev;
        protected string Keyword = string.Empty;
        protected Label LabelCurrentPage;
        protected Label LabelSeparatorFirst;
        protected Label LabelSeparatorLast;
        protected Label LabelSeparatorNext;
        protected Label LabelSeparatorPage;
        protected Label LabelSeparatorPrev;
        protected Label LabelTotalPage;
        protected LinkButton LinkButtonFirst;
        protected LinkButton LinkButtonGotoPage;
        protected LinkButton LinkButtonLast;
        protected LinkButton LinkButtonNext;
        protected LinkButton LinkButtonPrev;
        protected int PageSize = Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.PageSize));
        protected Panel PanelPaging;
        protected Panel PanelToolbar;
        protected RadGrid RadGridDefault;
        protected Repeater RepeaterView;
        protected int TotalPage = 0;
        protected string Status = string.Empty;

        #endregion

        #region FindControls

        protected virtual void FindControls()
        {
            Control formDefault = Master.FindControl(Constants.Paging.ControlName.FormDefault);
            Control contentMain = (Master == null)
                                      ? Page
                                      : formDefault.FindControl(Constants.Paging.ControlName.ContentPlaceHolderContainer);

            PanelToolbar = (Panel)contentMain.FindControl(Constants.Paging.ControlName.PanelToolbar);
            RadGridDefault = (RadGrid)contentMain.FindControl(Constants.Paging.ControlName.RadGridDefault);
            GridViewDefault = (GridView)contentMain.FindControl(Constants.Paging.ControlName.GridViewDefault);
            RepeaterView = (Repeater)contentMain.FindControl(Constants.Paging.ControlName.RepeaterView);
            PanelPaging = (Panel)contentMain.FindControl(Constants.Paging.ControlName.PanelPaging);
            ImageButtonFirst = (ImageButton)contentMain.FindControl(Constants.Paging.ControlName.ImageButtonFirst);
            ImageButtonPrev = (ImageButton)contentMain.FindControl(Constants.Paging.ControlName.ImageButtonPrev);
            ImageButtonNext = (ImageButton)contentMain.FindControl(Constants.Paging.ControlName.ImageButtonNext);
            ImageButtonLast = (ImageButton)contentMain.FindControl(Constants.Paging.ControlName.ImageButtonLast);
            LinkButtonFirst = (LinkButton)contentMain.FindControl(Constants.Paging.ControlName.LinkButtonFirst);
            LinkButtonPrev = (LinkButton)contentMain.FindControl(Constants.Paging.ControlName.LinkButtonPrev);
            LinkButtonNext = (LinkButton)contentMain.FindControl(Constants.Paging.ControlName.LinkButtonNext);
            LinkButtonLast = (LinkButton)contentMain.FindControl(Constants.Paging.ControlName.LinkButtonLast);
            LabelSeparatorFirst = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelSeparatorFirst);
            LabelSeparatorPrev = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelSeparatorPrev);
            LabelSeparatorPage = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelSeparatorPage);
            LabelSeparatorNext = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelSeparatorNext);
            LabelSeparatorLast = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelSeparatorLast);
            LabelCurrentPage = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelCurrentPage);
            LabelTotalPage = (Label)contentMain.FindControl(Constants.Paging.ControlName.LabelTotalPage);
            LinkButtonGotoPage = (LinkButton)contentMain.FindControl(Constants.Paging.ControlName.LinkButtonGotoPage);
            DropDownListChoiceIndexOfPage =
                (DropDownList)contentMain.FindControl(Constants.Paging.ControlName.DropDownListChoiceIndexOfPage);
        }

        #endregion

        #region FunctionForPageLoad

        protected virtual void FunctionforPageLoad()
        {
            //Register Event for Radgrid
            FindControls();

            //Set GridLines
            if (GridViewDefault != null)
            {
                GridViewDefault.GridLines = GridLines.None;
            }

            //Search
            if (!Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.KEYWORD]))
            {
                ViewState[Constants.Paging.Direction.KeyWords] =
                    Keyword = Request.Params[Constants.ParameterName.KEYWORD];
                ViewState[Constants.Paging.Direction.IsSearch] = Constants.Paging.Direction.Searching;
            }

            //Paging
            if (!Nulls.IsNullOrEmpty(Request.Params[Constants.ParameterName.PAGE])
                && Utilities.ParseInt(Request.Params[Constants.ParameterName.PAGE]) > 0
                )
            {
                ViewState[Constants.Paging.Direction.CurrentPage] =
                    ViewState[Constants.Paging.Direction.PreviousPage] =
                    Utilities.ParseInt(Request.Params[Constants.ParameterName.PAGE]);
            }

            ViewState[Constants.Paging.Direction.IsSearch] =
                Nulls.IsNullOrEmpty(ViewState[Constants.Paging.Direction.IsSearch])
                    ? Constants.Paging.Direction.NotSearching
                    : Constants.Paging.Direction.Searching;
            ViewState[Constants.Paging.Direction.KeyWords] =
                Nulls.IsNullOrEmpty(ViewState[Constants.Paging.Direction.KeyWords])
                    ? string.Empty
                    : ViewState[Constants.Paging.Direction.KeyWords].ToString();
            ViewState[Constants.Paging.Direction.CurrentPage] =
                Nulls.IsNullOrEmpty(ViewState[Constants.Paging.Direction.CurrentPage])
                    ? Constants.Paging.Direction.FirstPage
                    : ViewState[Constants.Paging.Direction.CurrentPage].ToString();
            ViewState[Constants.Paging.Direction.PreviousPage] =
                Nulls.IsNullOrEmpty(ViewState[Constants.Paging.Direction.PreviousPage])
                    ? Constants.Paging.Direction.FirstPage
                    : ViewState[Constants.Paging.Direction.PreviousPage].ToString();

            //Bind Data to RadGrid
            DataTable dt = GetDataSource();

            //TODO:
            if (RepeaterView != null)
            {
                RepeaterView.DataSource = dt;
                RepeaterView.DataBind();
            }
            if (GridViewDefault != null)
            {
                GridViewDefault.DataSource = dt;
                GridViewDefault.DataBind();
            }
            if (RadGridDefault != null)
            {
                RadGridDefault.DataSource = dt;
                RadGridDefault.DataBind();
            }

            //Bind data in ComboBox Source
            BindValueinDropDownList();

            //Navigator
            SetLabelForPagingBar();
        }

        public virtual int ItemIndex()
        {
            return
                Utilities.ParseInt(Utilities.GetConfigKey(Constants.ConfigKey.PageSize)) *
                (Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]) - 1);
        }

        #endregion

        #region GetDataSource

        protected virtual DataTable BindSearchingTable()
        {
            DataTable dtSearch = new DataTable(Constants.Paging.Direction.SearchingTableName);
            dtSearch.Columns.Add(Constants.Paging.Direction.IsSearch, typeof(bool));
            dtSearch.Columns.Add(Constants.Paging.Direction.KeyWords, typeof(string));
            DataRow drSearch = dtSearch.NewRow();
            drSearch[Constants.Paging.Direction.IsSearch] =
                Convert.ToBoolean(ViewState[Constants.Paging.Direction.IsSearch]);
            drSearch[Constants.Paging.Direction.KeyWords] =
                Convert.ToString(ViewState[Constants.Paging.Direction.KeyWords]);
            dtSearch.Rows.Add(drSearch);
            return dtSearch;
        }

        protected virtual DataTable GetDataSource()
        {
            //Create Packet
            Packet p = new Packet();
            p.ServiceName = ServiceName;
            p.Action = ActionName;

            //Paging Table
            DataTable dtPaging = new DataTable(Constants.Paging.Direction.PagingTableName);
            dtPaging.Columns.Add(Constants.Paging.Direction.PageIndex, typeof(int));
            dtPaging.Columns.Add(Constants.Paging.Direction.PageSize, typeof(int));
            DataRow drPaging = dtPaging.NewRow();
            drPaging[Constants.Paging.Direction.PageIndex] =
                Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]);
            drPaging[Constants.Paging.Direction.PageSize] = PageSize;
            dtPaging.Rows.Add(drPaging);
            p.RawData.Tables.Add(dtPaging);

            //Searching Table
            p.RawData.Tables.Add(BindSearchingTable());

            // Execute
            p = ServiceFacade.Execute(p);
            DataTable t = Utilities.EncodeDatatable(p.RawData.Tables[0]);

            //Get number of page in the paging
            if (p.RawData.Tables.Count < 2) return t;

            int rowCount = Convert.ToInt32(p.RawData.Tables[1].Rows[0][Constants.Paging.Direction.PageCount]);
            int pageCount = rowCount / PageSize;

            if (rowCount % PageSize == 0)
            {
                ViewState[Constants.Paging.Direction.PageCount] = pageCount;
            }
            else
            {
                ViewState[Constants.Paging.Direction.PageCount] = pageCount + 1;
            }

            return t;
        }

        #endregion

        #region BindValueinDropDownList

        protected virtual void BindValueinDropDownList()
        {
            DataTable dtPageNumber = new DataTable();
            dtPageNumber.Columns.Add(new DataColumn(Constants.Paging.ControlName.ComboBox.ComboText, typeof(string)));
            dtPageNumber.Columns.Add(new DataColumn(Constants.Paging.ControlName.ComboBox.ComboValue, typeof(int)));

            int iCurrentPage = Convert.ToInt32(ViewState[Constants.Paging.Direction.CurrentPage]);
            int iTotalPage = Convert.ToInt32(ViewState[Constants.Paging.Direction.PageCount]);
            if (iTotalPage > 0)
            {
                for (int i = 1; i <= iTotalPage; i++)
                {
                    DataRow dr = dtPageNumber.NewRow();

                    dr[Constants.Paging.ControlName.ComboBox.ComboText] = i.ToString();
                    dr[Constants.Paging.ControlName.ComboBox.ComboValue] = i;

                    dtPageNumber.Rows.Add(dr);
                }

                DataView dvPageNumber = new DataView(dtPageNumber);
                DropDownListChoiceIndexOfPage.DataSource = dvPageNumber;
                DropDownListChoiceIndexOfPage.DataTextField = Constants.Paging.ControlName.ComboBox.ComboText;
                DropDownListChoiceIndexOfPage.DataValueField = Constants.Paging.ControlName.ComboBox.ComboValue;
                DropDownListChoiceIndexOfPage.DataBind();
                DropDownListChoiceIndexOfPage.SelectedValue = (iCurrentPage <= iTotalPage)
                                                                  ? iCurrentPage.ToString()
                                                                  : iTotalPage.ToString();
            }
        }

        #endregion

        #region SetLabelForPagingBar

        protected virtual void SetLabelForPagingBar()
        {
            int iCurrentPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]);
            int iTotalPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.PageCount]);
            // If there is no record to display.
            if (iTotalPage == 0)
            {
                PanelPaging.Visible = false;
            }
            // If there is more than one record to display.
            else
            {
                //Set visible of PagingTable row
                PanelPaging.Visible = true;
                LabelCurrentPage.Text = iCurrentPage.ToString();
                LabelTotalPage.Text = iTotalPage.ToString();

                LinkButtonFirst.Visible = ImageButtonFirst.Visible = LabelSeparatorFirst.Visible =
                                                                     LinkButtonPrev.Visible =
                                                                     ImageButtonPrev.Visible =
                                                                     LabelSeparatorPrev.Visible = (iCurrentPage > 1);

                LinkButtonNext.Visible = ImageButtonNext.Visible = LabelSeparatorNext.Visible =
                                                                   LinkButtonLast.Visible =
                                                                   ImageButtonLast.Visible =
                                                                   LabelSeparatorLast.Visible =
                                                                   (iCurrentPage < iTotalPage);
            }
        }

        #endregion

        #region Paging Action

        protected virtual void btnFirst_Click(object sender, EventArgs e)
        {
            string strURL = Request.Url.ToString();
            strURL = Utilities.SetParamForURL(strURL, Constants.ParameterName.PAGE, "1");
            Response.Redirect(strURL);
        }

        protected virtual void btnPrev_Click(object sender, EventArgs e)
        {
            string strURL = Request.Url.ToString();
            int iCurrentPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]);
            strURL = Utilities.SetParamForURL(strURL, Constants.ParameterName.PAGE, (iCurrentPage - 1).ToString());
            Response.Redirect(strURL);
        }

        protected virtual void btnNext_Click(object sender, EventArgs e)
        {
            string strURL = Request.Url.ToString();
            int iCurrentPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]);
            strURL = Utilities.SetParamForURL(strURL, Constants.ParameterName.PAGE, (iCurrentPage + 1).ToString());
            Response.Redirect(strURL);
        }

        protected virtual void btnLast_Click(object sender, EventArgs e)
        {
            string strURL = Request.Url.ToString();
            int iTotalPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.PageCount]);
            strURL = Utilities.SetParamForURL(strURL, Constants.ParameterName.PAGE, iTotalPage.ToString());
            Response.Redirect(strURL);
        }

        protected virtual void btnGotoPage_Click(object sender, EventArgs e)
        {
            DropDownListChoiceIndexOfPage =
                (DropDownList)FindPageControl(Constants.Paging.ControlName.DropDownListChoiceIndexOfPage);

            string strURL = Request.Url.ToString();
            strURL =
                Utilities.SetParamForURL(strURL, Constants.ParameterName.PAGE,
                                         DropDownListChoiceIndexOfPage.SelectedValue);
            Response.Redirect(strURL);
        }

        protected virtual void btnRadFirst_Click(object sender, EventArgs e)
        {
            ViewState[Constants.Paging.Direction.CurrentPage] = 1;

            FunctionforPageLoad();
        }

        protected virtual void btnRadPrev_Click(object sender, EventArgs e)
        {
            int iCurrentPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]);

            ViewState[Constants.Paging.Direction.CurrentPage] = iCurrentPage - 1;

            FunctionforPageLoad();
        }

        protected virtual void btnRadNext_Click(object sender, EventArgs e)
        {
            int iCurrentPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.CurrentPage]);

            ViewState[Constants.Paging.Direction.CurrentPage] = iCurrentPage + 1;

            FunctionforPageLoad();
        }

        protected virtual void btnRadLast_Click(object sender, EventArgs e)
        {
            int iTotalPage = Utilities.ParseInt(ViewState[Constants.Paging.Direction.PageCount]);

            ViewState[Constants.Paging.Direction.CurrentPage] = iTotalPage;

            FunctionforPageLoad();
        }

        protected virtual void btnRadGotoPage_Click(object sender, EventArgs e)
        {
            DropDownListChoiceIndexOfPage =
                (DropDownList)FindPageControl(Constants.Paging.ControlName.DropDownListChoiceIndexOfPage);

            ViewState[Constants.Paging.Direction.CurrentPage] = DropDownListChoiceIndexOfPage.SelectedValue;

            FunctionforPageLoad();
        }

        #endregion

        #region GridViewDefault Action

        protected virtual void grdViewDefault_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (isViewer)
                    e.Row.Attributes["ondblclick"] =
                        ClientScript.GetPostBackClientHyperlink(GridViewDefault, "Select$" + e.Row.RowIndex);
            }
        }

        #endregion

        #region RadGridDefault Action

        protected virtual void radGridDefault_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridGroupHeaderItem)
            {
                GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
                item.DataCell.Text = item.DataCell.Text.Replace(":", string.Empty).Trim();
            }
        }

        protected virtual void radGridDefault_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;
        }

        #endregion
    }
}
