using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VietNamNet.CMS.Common;
using VietNamNet.CMS.DBAccess;
using VietNamNet.Framework.Common;
using VietNamNet.Framework.System;

namespace VietNamNet.CMS.Articles.UserControls
{
    public partial class PanelArticleMedia : UserControl
    {
        #region Public Properties

        [Description("Edit Option")]
        [Browsable(true)]
        [DefaultSettingValue("1")]
        public int EditOption
        {
            get { return Utilities.ParseInt(ViewState[CMSConstants.ViewState.EditOption]); }
            set { ViewState[CMSConstants.ViewState.EditOption] = value; }
        }

        #endregion

        #region Handler Method

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (EditOption == 0)
                {
                    pnlEdit.Visible = false;
                    radGridMedia.Columns[radGridMedia.Columns.Count - 1].Visible = false; //Delete
                    radGridMedia.Columns[radGridMedia.Columns.Count - 2].Visible = true; //Embed
                    radGridMedia.Columns[radGridMedia.Columns.Count - 3].Visible = false; //Detail edit
                    radGridMedia.Columns[radGridMedia.Columns.Count - 4].Visible = true; //Detail display
                    radGridMedia.ClientSettings.AllowRowsDragDrop = false;
                    radGridMedia.ClientSettings.ClientEvents.OnRowDropping = string.Empty;
                    btnDelMedia.Visible = false;
                }
            }
        }

        protected void radGridMedia_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                    ? (DataTable) Session[GetArticleMediaSessionName()]
                                    : ArticleMediaDAO.GetTemplateTable();
            radGridMedia.DataSource = dtMedia.Select("SaveStatus <> 'DELETE'");
        }

        protected void radGridMedia_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (!Utilities.Event_Handler(source, e)) return;

            if (Utilities.StringCompare(e.CommandName, Constants.CommandNames.Delete) && e.Item is GridDataItem)
            {
                DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                        ? (DataTable) Session[GetArticleMediaSessionName()]
                                        : ArticleMediaDAO.GetTemplateTable();
                int id = Utilities.ParseInt(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);
                foreach (DataRow row in dtMedia.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                    if (rid == id)
                    {
                        row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                        row[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_At] = DateTime.Now;
                        row[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        break;
                    }
                }

                Session[GetArticleMediaSessionName()] = dtMedia;

                radGridMedia.Rebind();
            }
        }

        protected void radGridMedia_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            if (EditOption == 0) return;

            if (string.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == radGridMedia.ClientID)
                {
                    //reorder items in grid
                    DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                            ? (DataTable)Session[GetArticleMediaSessionName()]
                                            : ArticleMediaDAO.GetTemplateTable();

                    DataTable dtMediaToMove = ArticleMediaDAO.GetTemplateTable();
                    foreach (GridDataItem draggedItem in e.DraggedItems)
                    {
                        DataRow tmpOrder = GetOrder(dtMedia, Utilities.ParseInt(draggedItem.GetDataKeyValue("Id")));
                        if (tmpOrder != null) //Move from Media to Temp
                        {
                            dtMediaToMove = AddRow(dtMediaToMove, tmpOrder);
                            dtMedia.Rows.Remove(tmpOrder);
                        }
                    }

                    //get destinationIndex
                    DataRow order = GetOrder(dtMedia, Utilities.ParseInt(e.DestDataItem.GetDataKeyValue("Id")));
                    if (order == null) return;

                    int destinationIndex = dtMedia.Rows.IndexOf(order);

                    if (e.DropPosition == GridItemDropPosition.Below)
                    {
                        destinationIndex += 1;
                    }

                    foreach (DataRow orderToMove in dtMediaToMove.Rows) //Move from Temp to Media
                    {
                        dtMedia = AddRow(dtMedia, orderToMove, destinationIndex++);
                    }

                    //Update Media ord
                    for (int i = 0; i < dtMedia.Rows.Count; i++)
                    {
                        dtMedia.Rows[i][CMSConstants.Entities.ArticleMedia.FieldName.Ord] = i + 1;
                        if (Nulls.IsNullOrEmpty(dtMedia.Rows[i][CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus]))
                        {
                            dtMedia.Rows[i][CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus] =
                                Constants.CommonStatus.UPDATE;
                        }
                        dtMedia.Rows[i][CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_At] = DateTime.Now;
                        dtMedia.Rows[i][CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                    }

                    Session[GetArticleMediaSessionName()] = dtMedia;
                    
                    radGridMedia.Rebind();
                }
            }
        }

        protected void txtDetail_TextChanged(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;
            
            if (EditOption == 0) return;

            try
            {
                RadTextBox txtDetail = sender as RadTextBox;

                GridTableCell myPanel = txtDetail.Parent as GridTableCell;

                GridDataItem dataItem = myPanel.Parent as GridDataItem;

                int id = Utilities.ParseInt(dataItem["Id"].Text);

                DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                        ? (DataTable)Session[GetArticleMediaSessionName()]
                                        : ArticleMediaDAO.GetTemplateTable();
                foreach (DataRow row in dtMedia.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                    if (rid == id)
                    {
                        row[CMSConstants.Entities.ArticleMedia.FieldName.Detail] = txtDetail.Text.Trim();
                        if (Nulls.IsNullOrEmpty(row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus]))
                        {
                            row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus] = Constants.CommonStatus.UPDATE;
                        }
                        row[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_At] = DateTime.Now;
                        row[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                        break;
                    }
                }

                Session[GetArticleMediaSessionName()] = dtMedia;
            }
            catch (Exception ex)
            {
                SystemLogging.Error("Article::PanelArticleMedia::ChangeDetail::Error", ex.Message);
            }
            finally
            {
                //radGridMedia.Rebind();
            }
        }

        protected void btnAddMedia_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            if (Nulls.IsNullOrEmpty(txtMedia.Text.Trim())) return;

            //get data
            DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                    ? (DataTable)Session[GetArticleMediaSessionName()]
                                    : ArticleMediaDAO.GetTemplateTable();

            foreach (string media in txtMedia.Text.Trim().Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                //get id
                int id = -1;
                foreach (DataRow row in dtMedia.Rows)
                {
                    int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                    if (rid <= id) id = rid - 1;
                }
                //get ord
                int ord = 1;
                foreach (DataRow row in dtMedia.Rows)
                {
                    int rord = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Ord]);
                    if (rord >= ord) ord = rord + 1;
                }
                //get fileType
                string fileType = GetFileType(media);

                DataRow mediaFile = dtMedia.NewRow();
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Id] = id;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.ArticleId] = 0;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Ord] = ord;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.MediaType] = fileType;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.FileLink] = media;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Thumbnail] =
                    Utilities.StringCompare(fileType, CMSConstants.MediaType.Image)
                        ? Utilities.SetParamForURL(media, "w", "120")
                        : txtThumbnail.Text.Trim();
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Detail] = txtMediaDetail.Text.Trim();
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus] = Constants.CommonStatus.NEW;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Created_At] = DateTime.Now;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Created_By] =
                    Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_At] = DateTime.Now;
                mediaFile[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_By] =
                    Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                dtMedia.Rows.Add(mediaFile);
            }

            Session[GetArticleMediaSessionName()] = dtMedia;

            radGridMedia.Rebind();
        }

        protected void btnDelMedia_Click(object sender, EventArgs e)
        {
            if (!Utilities.Event_Handler(sender, e)) return;

            DataTable dtMedia = (Session[GetArticleMediaSessionName()] != null)
                                    ? (DataTable)Session[GetArticleMediaSessionName()]
                                    : ArticleMediaDAO.GetTemplateTable();

            for (int i = 0; i < radGridMedia.Items.Count; i++)
            {
                GridDataItem dataItem = radGridMedia.Items[i];

                CheckBox chkSelected = (CheckBox)dataItem.FindControl("chkSelected");

                if (chkSelected != null && chkSelected.Checked)
                {
                    int id = Utilities.ParseInt(dataItem["Id"].Text);

                    foreach (DataRow row in dtMedia.Rows)
                    {
                        int rid = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                        if (rid == id)
                        {
                            row[CMSConstants.Entities.ArticleMedia.FieldName.SaveStatus] = Constants.CommonStatus.DELETE;
                            row[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_At] = DateTime.Now;
                            row[CMSConstants.Entities.ArticleMedia.FieldName.Last_Modified_By] = Utilities.ParseInt(Session[Constants.Session.USER_ID]);
                            break;
                        }
                    }
                }
            }

            Session[GetArticleMediaSessionName()] = dtMedia;

            radGridMedia.Rebind();
        }

        #endregion

        #region Public Method

        public void BindDataToMedia()
        {
            radGridMedia.DataBind();
        }

        #endregion

        #region Private Method

        private string GetArticleMediaSessionName()
        {
            int docId = Utilities.ParseInt(Request.Params[Constants.ParameterName.DOC_ID]);
            return string.Format("{0}_{1}", CMSConstants.Session.CMSData.ArticleMedia, docId);
        }

        private static string getFileType(string fileName)
        {
            return Path.GetExtension(fileName);
        }

        private static string checkImageType(string fileType)
        {
            string[] imgTypeAllow = Utilities.GetConfigKey(CMSConstants.ConfigKey.ImageFileType).Split(',');
            if (imgTypeAllow.Length > 0)
            {
                for (int i = 0; i < imgTypeAllow.Length; i++)
                {
                    if (Utilities.StringCompare(fileType, imgTypeAllow[i]))
                    {
                        return CMSConstants.MediaType.Image;
                    }
                }
            }
            return string.Empty;
        }

        private static string checkFlashType(string fileType)
        {
            string[] imgTypeAllow = Utilities.GetConfigKey(CMSConstants.ConfigKey.FlashFileType).Split(',');
            if (imgTypeAllow.Length > 0)
            {
                for (int i = 0; i < imgTypeAllow.Length; i++)
                {
                    if (Utilities.StringCompare(fileType, imgTypeAllow[i]))
                    {
                        return CMSConstants.MediaType.Flash;
                    }
                }
            }
            return string.Empty;
        }

        private static string checkAudioType(string fileType)
        {
            string[] imgTypeAllow = Utilities.GetConfigKey(CMSConstants.ConfigKey.AudioFileType).Split(',');
            if (imgTypeAllow.Length > 0)
            {
                for (int i = 0; i < imgTypeAllow.Length; i++)
                {
                    if (Utilities.StringCompare(fileType, imgTypeAllow[i]))
                    {
                        return CMSConstants.MediaType.Audio;
                    }
                }
            }
            return string.Empty;
        }

        private static string checkVideoType(string fileType)
        {
            string[] imgTypeAllow = Utilities.GetConfigKey(CMSConstants.ConfigKey.VideoFileType).Split(',');
            if (imgTypeAllow.Length > 0)
            {
                for (int i = 0; i < imgTypeAllow.Length; i++)
                {
                    if (Utilities.StringCompare(fileType, imgTypeAllow[i]))
                    {
                        return CMSConstants.MediaType.Video;
                    }
                }
            }
            return string.Empty;
        }

        private string GetFileType(string fileName)
        {
            string mediaType = string.Empty;
            string fileType = getFileType(fileName);
            if (Nulls.IsNullOrEmpty(mediaType)) mediaType = checkImageType(fileType);
            if (Nulls.IsNullOrEmpty(mediaType)) mediaType = checkFlashType(fileType);
            if (Nulls.IsNullOrEmpty(mediaType)) mediaType = checkAudioType(fileType);
            if (Nulls.IsNullOrEmpty(mediaType)) mediaType = checkVideoType(fileType);
            return mediaType;
        }

        private DataRow GetOrder(DataTable source, int id)
        {
            if (source == null || source.Rows.Count == 0) return null;
            foreach (DataRow row in source.Rows)
            {
                int rowId = Utilities.ParseInt(row[CMSConstants.Entities.ArticleMedia.FieldName.Id]);
                if (rowId == id) return row;
            }
            return null;
        }

        private DataTable AddRow(DataTable source, DataRow row)
        {
            if (source == null || row == null) return source;
            DataRow newRow = source.NewRow();
            foreach (DataColumn col in source.Columns)
            {
                if (row.Table.Columns.Contains(col.ColumnName))
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
            }
            source.Rows.Add(newRow);

            return source;
        }

        private DataTable AddRow(DataTable source, DataRow row, int pos)
        {
            if (source == null || row == null) return source;
            DataRow newRow = source.NewRow();
            foreach (DataColumn col in source.Columns)
            {
                if (row.Table.Columns.Contains(col.ColumnName))
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
            }
            source.Rows.InsertAt(newRow, (pos < 0) ? 0 : pos);

            return source;
        }

        #endregion
    }
}