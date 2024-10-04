using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Transactions;
using System.Xml.Serialization;
using SubSonic;
using VietNamNet.AddOn.SurveyModule.DAL;

namespace VietNamNet.AddOn.Survey.BizLogic
{
    public class SurveyObject : VietNamNet.AddOn.SurveyModule.DAL.Survey
    {

        #region Members

            private SurveyOptionCollection _options;
        #endregion

        #region Props
            [XmlAttribute("Options")]
            [Bindable(true)]
            public new SurveyOptionCollection Options
            {
                get {return this.SurveyOptions() ;}
                set { _options = value; }
            }
        #endregion

        #region Methods

        public void save()
        {
            using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        this.Save();
                        foreach (SurveyOption option in this.Options)
                        {
                            option.Save();
                        }
                        ts.Complete();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        ts.Dispose();
                    }

                }

            }
        }

        public SurveyCollection ListByCategory(int categoryId)
        {
            SurveyPublishCollection pCol = new SurveyPublishCollection().Where(VietNamNet.AddOn.SurveyModule.DAL.SurveyPublish.Columns.CategoryId,Comparison.Equals, categoryId);
           VietNamNet.AddOn.SurveyModule.DAL.SurveyCollection sCol = new SurveyCollection();

            foreach(SurveyPublish p in pCol )
            {
                sCol.Add(p.Survey);
            }

            return sCol;
        }

        public SurveyCollection ListByArticle(int articleId)
        {
            SurveyPublishCollection pCol = new SurveyPublishCollection().Where(VietNamNet.AddOn.SurveyModule.DAL.SurveyPublish.Columns.ArticleId, Comparison.Equals, articleId);
            VietNamNet.AddOn.SurveyModule.DAL.SurveyCollection sCol = new SurveyCollection();

            foreach (SurveyPublish p in pCol)
            {
                sCol.Add(p.Survey);
            }

            return sCol;
        }

        #endregion


        }
}
