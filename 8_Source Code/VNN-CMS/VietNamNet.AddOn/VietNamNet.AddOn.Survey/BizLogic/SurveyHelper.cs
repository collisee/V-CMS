using System;
using System.Collections.Generic;
using System.Transactions;
using SubSonic;
using VietNamNet.AddOn.SurveyModule.DAL; 

namespace VietNamNet.AddOn.Survey.BizLogic
{
    public class SurveyHelper : SurveyController
    {
        public void save(SurveyObject surveyObject)
        {
            using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        surveyObject.Save();
                        foreach (SurveyOption option in surveyObject.Options)
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

        public void save(VietNamNet.AddOn.SurveyModule.DAL.Survey s, SurveyOptionCollection soCol, SurveyPublishCollection pCol)
        {
            using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope())
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        s.Save(); 
                        if (s.SurveyId <=0)
                        {
                            s.SurveyId = (int)s.GetPrimaryKeyValue();
                        }
                        foreach (SurveyOption option in soCol)
                        {
                            option.SurveyId = s.SurveyId;
                            option.Save();
                        }
                        foreach (SurveyPublish p in pCol)
                        {
                            p.SurveyId = s.SurveyId;
                            p.Save();
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
 
        public SurveyObject GetById(object surveyId)
        {
        
            //Get Survey Object
            SurveyModule.DAL.Survey sTemp =  new Select().From<SurveyModule.DAL.Survey>().
                    Where(SurveyModule.DAL.Survey.Columns.SurveyId).IsEqualTo(surveyId).ExecuteSingle<SurveyModule.DAL.Survey>();

            ////Get List Survey Option 
            //SurveyOptionCollection soCol = new Select().From<SurveyOption>()
            //                                    .Where(SurveyOption.Columns.SurveyId).IsEqualTo(surveyId)
            //                                    .ExecuteAsCollection<SurveyOptionCollection>();
 
                
            SurveyObject s = new SurveyObject();
            s.SurveyId  = sTemp.SurveyId ;
            s.Question  = sTemp.Question ;
            s.Tags = sTemp.Tags;
            s.OptionType = sTemp.OptionType;

            s.Notes  = sTemp.Notes;
            s.CreatedBy = sTemp.CreatedBy;
            s.CreatedOn = sTemp.CreatedOn;
            s.ModifiedBy = sTemp.ModifiedBy ;
            s.ModifiOn = sTemp.ModifiOn;
            s.IsDeleted = sTemp.IsDeleted;
            s.IsActive = sTemp.IsActive;
            s.Status = sTemp.Status;

            //Get List Survey Option 
            s.Options = s.SurveyOptions() ;
            return s;
        }

    }
}