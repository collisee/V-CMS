using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using System.Net;
using SubSonic;
namespace GetContentFromRolo
{

    ///Muc dich: Class chua cac ham tien ich cap nhat vao CSDL cua V-CMS voi nguon du lieu duoc lay tu Rolo
    ///Nguoi tao: PhongDH
    ///Ngay tao: 20/09/2010

    public class NewsDB
    {
        public DataTable Xml2DataSet(XmlDocument xmlDocument)
        {
            DataSet ds = null;
            DataTable dataTable = null;
            Boolean checkColumn = false;
            try
            {  
                ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xmlDocument)); 
                if (ds.Tables.Count > 0)
                {                    
                    dataTable = ds.Tables[ds.Tables.Count - 1];
                }
            }
            catch (Exception ex)
            {
                
               throw;
            } finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
                
            }
            return dataTable;
        }
        public DataTable Xml2DataSet(XmlDocument xmlDocument, String column2Check)
        {
            DataSet ds = null;
            DataTable dataTable = null;
            Boolean checkColumn = false;
            try
            {
                ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xmlDocument));
                if (ds.Tables.Count > 0)
                {
                    int i = 0;
                    foreach (DataTable dataTable1 in ds.Tables)
                    {
                        foreach (DataColumn dataCol in dataTable1.Columns)
                        {
                            checkColumn = dataCol.ColumnName.ToString().ToLower().Trim().Equals(column2Check);
                            if (checkColumn)
                                break;
                        }
                        if (checkColumn)
                            break;
                        i = i + 1;
                    }
                    if (checkColumn)
                    {
                        dataTable = ds.Tables[i];
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }

            }
            return dataTable;
        }
        //Muc dich: Lay danh sach cac chuyen muc se lay tin tu dong tu rolo
        //Nguoi tao: PhongDH
        //Ngay tao: 21/09/2010
        //Tham so dau vao:
        //  -newsFlag: Co danh dau nhung chuyen muc can lay tin
        //Gia tri tri ve: IDataReader - danh sach cac chuyen muc se lay tin tu dong tu rolo
        public IDataReader GetListSources(byte newsFlag)
        {
            IDataReader dataReader = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                SqlQuery qry = new Select().From(DAL.Source.Schema).Where(DAL.Source.Columns.NewsFlag).IsEqualTo(newsFlag);
                dataReader = qry.ExecuteReader();
            }
            catch (Exception)
            {
                
                throw;
            } finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
            }
            return dataReader;
        }
        public IDataReader GetListSources(byte newsFlag, GetContentFromRolo.Utils utils)
        {
            IDataReader dataReader = null;
            DataSet ds = null;
            try
            {
                ds = new DataSet();
                SqlQuery qry = new Select().From(DAL.Source.Schema).Where(DAL.Source.Columns.NewsFlag).IsEqualTo(newsFlag).OrderAsc(DAL.Source.Columns.CategoryID);
                dataReader = qry.ExecuteReader();
            }
            catch (Exception ex)
            {
                utils.WriteLog(utils.LogPath, ex.ToString(), "GetListSources::Error", DateTime.Now.ToString()); 
            }
            finally
            {
                if (ds != null)
                {
                    ds.Dispose();
                    ds = null;
                }
            }
            return dataReader;
        }
        //Muc dich: Lay noi dung chi tiet cua 1 tin tu rolo
        //Nguoi tao: PhongDH
        //Ngay tao: 21/09/2010
        //Tham so dau vao:
        //  -newsId: Id cua tin can lay noi dung chi tiet
        //  -utils: Class de thao tac voi du lieu XML, URL, Image
        //  -key: Ma so Rolo cung cap de lay tin
        //Gia tri tri ve: String - Noi dung chi tiet cua tin
        public String GetNewsDetailContent(String newsId,GetContentFromRolo.Utils utils, String key)
        {
            DataTable dataTable = null;
            DataSet ds = null;
            String strContent = "";
            try
            {
                XmlDocument xmlDocument = utils.GetXmlFromUrl(utils.BuildNewsDetailLink(newsId), key);
                XmlNode root = xmlDocument.DocumentElement;
                dataTable = new GetContentFromRolo.NewsDB().Xml2DataSet(xmlDocument, "content");
                if (dataTable != null)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        strContent = Convert.ToString(dataRow["content"]) ?? "";

                    }
                }
            }
            catch (Exception ex)
            {
                utils.WriteLog(utils.LogPath, ex.ToString(), "GetNewsDetailContent::Error", DateTime.Now.ToString()); ;
                
            }
            finally
            {
                if (dataTable != null)
                {
                    dataTable.Dispose();
                    dataTable = null;
                }
            }
            return strContent;
        }
        //Muc dich: Kiem tra link nay da duoc lay tin bai ve chua
        //Nguoi tao: PhongDH
        //Ngay tao: 21/09/2010
        //Tham so dau vao:
        //  -href: Link can kiem tra
        //Gia tri tri ve: Boolean 
        public Boolean CheckLinkExisted(String href)
        {
            Double articleId = 0;
            try
            {
                SqlQuery qry = new Select().From(DAL.Article.Schema).Where(DAL.Article.Columns.SubTitle6).IsEqualTo(href.ToLower());
                articleId = (double) qry.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            return articleId > 0;
        }
        public Boolean CheckLinkExisted(String href, GetContentFromRolo.Utils utils)
        {
            Double articleId = 0;
            IDataReader dataReader = null;
            try
            {
                SqlQuery qry = new Select().From(DAL.Article.Schema).Where(DAL.Article.Columns.SubTitle6).IsEqualTo(href);
                dataReader = qry.ExecuteReader();
                while (dataReader.Read())
                {
                    articleId = Convert.ToDouble(dataReader["id"]);
                } 
            }
            catch (Exception ex)
            {
                utils.WriteLog(utils.LogPath, ex.ToString(), "CheckLinkExisted::Error", DateTime.Now.ToString());
                articleId = 0;
            }
            return articleId > 0;
        }
        //Muc dich: Insert tin bai moi vao bang Article
        //Nguoi tao: PhongDH
        //Ngay tao: 21/09/2010
        //Tham so dau vao:
        //  -article: Doi tuong Article
        //  -utils: Class thuc hien cac tac vu lien quan den XML,Image...
        //Gia tri tri ve: Boolean - Ket qua insert
        public Boolean InserNews(DAL.Article article, GetContentFromRolo.Utils utils)
        {
            int Id = 0;
            StoredProcedure sp = null;
            try
            {
                sp = DAL.SPs.InsertNew(article.Name, article.Title, article.ImageLink, article.Lead, article.Detail,
                                        article.History, article.SubTitle6, article.Status, article.ArticleTypeId, article.ArticleContentTypeId, article.CategoryId, article.SubTitle5);
                sp.Execute();
                return true;
            }
            catch (Exception ex)
            {
                utils.WriteLog(utils.LogPath, ex.ToString(), "InserNews::Error", DateTime.Now.ToString()); ;
                return false;
            }
            
        }
    }
}
