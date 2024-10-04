using System;
using System.Collections.Generic;
using DAL;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
namespace GetContentFromRolo
{
    public class Main
    {
        public void GetContentFromRolo()
        {
            Utils utils = null;
            String url = "";
            try
            {
                
                DAL.Article article;
                String strImgLink = "";
                String strHfef = "";
                Int32 categoryId;
                Boolean checkColumn = false;
                XmlDocument xmlDocument = null;
                DataTable dataTable = null;

                utils = new Utils();
                //Lay key cua Rolo cung cap
                String strKey = utils.GetAppSetting("RoloKey");
                //Lay duong dan thu muc luu file log
                utils.LogPath = utils.GetAppSetting("LogDir");
                //-------------------Bat dau phan lay Latest News cua Rolo---------------
                //Lay danh sach cac link can lay tin tu Rolo
                IDataReader dataReader = new NewsDB().GetListSources(1, utils);
                
                while (dataReader.Read())
                {
                    url = Convert.ToString(dataReader["href"]);
                    categoryId = Convert.ToInt32(dataReader["CategoryID"]);
                    xmlDocument = new XmlDocument();
                    xmlDocument = utils.GetXmlFromUrl(url, strKey);
                    dataTable = new NewsDB().Xml2DataSet(xmlDocument, "link");
                    
                    if (dataTable != null)
                    {
                        utils.WriteLog(utils.LogPath, "Starting get data from url= " + url + " to Database", "Infor", DateTime.Now.ToString());
                        //Duyet danh sach cac tin moi nhat trong tung cate
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            //Luu link da lay tin ve vao truong SubTitle6 de lan sau khong lay lai
                            if (dataRow["link"] != null)
                            {
                                strHfef = Convert.ToString(dataRow["link"]) ?? "";
                            }
                            else
                            {
                                strHfef = "";
                            }

                            if (!strHfef.Equals("") && !new GetContentFromRolo.NewsDB().CheckLinkExisted(strHfef, utils))
                            {
                                article = new Article();
                                article.Name = Convert.ToString(dataRow["title"] ?? "");
                                article.Title = Convert.ToString(dataRow["title"]) ?? "";
                                article.Lead = Convert.ToString(dataRow["summary"]) ?? "";
                                article.Status = "Lấy tự động";
                                article.ArticleContentTypeId = 1; //Tin bai
                                article.ArticleTypeId = 4; //tin nhanh
                                article.History = "Lấy tin tự động từ Rolo";
                                article.SubTitle6 = strHfef; //Link goc cua tin
                                article.SubTitle5 = Convert.ToString(dataRow["source"]) ?? ""; //Nguon lay tin
                                article.CategoryId = categoryId;
                                strImgLink = Convert.ToString(dataRow["img"] ?? "");
                                if (!strImgLink.Equals(""))
                                {
                                    String imgName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
                                    String strDate = DateTime.Now.ToString("yyyy/MM/dd/hh");
                                    Object[] obj = utils.StringToArray(strDate, "/", typeof(string));
                                    String str = "";
                                    for (int i = 0; i < obj.Length; i++)
                                    {
                                        str += (String)obj[i] + "\\";
                                        utils.CreateDir(str);
                                    }

                                    imgName = utils.BuildImageLink(strDate, imgName);
                                    article.ImageLink = utils.SaveImageToDisk(strImgLink, str + "\\" + imgName.Substring(imgName.LastIndexOf("/") + 1),utils) ? imgName : "";

                                }
                                else
                                {
                                    article.ImageLink = "";
                                }
                                article.Detail = new NewsDB().GetNewsDetailContent(Convert.ToString(dataRow["id"]), utils, strKey);
                                new NewsDB().InserNews(article, utils);
                            }
                            utils.WriteLog(utils.LogPath, "Finished get data from url= " + url + " to Database", "Infor", DateTime.Now.ToString());
                        }   
                    }
                    else
                    {
                        utils.WriteLog(utils.LogPath, "DataTable was null", "Infor", DateTime.Now.ToString());
                    }
                    
                }
                //-------------------Ket thuc phan lay Latest News cua Rolo---------------
            }
            catch (Exception ex)
            {
                if (utils != null)
                    utils.WriteLog(utils.LogPath, "Get data from url = " + url + " has error -->" +ex.ToString(), "Error", DateTime.Now.ToString());
            }
        }
    }
}
