/************************************************************************/
/* File Name  : frmArticleProcess.cs                                    */
/* File Version  : 1.0                                                  */
/* Project Name  : VietNamNet.AddOn.Tracker                             */
/* Product Version : 1.0                                                */
/* Copyright(C) 2010 Developer Team - VietNamNet. All Rights Reserved   */
/************************************************************************/
/* Description : ArticleProcess: ghi log cua Article                    */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/* File history                                                         */
/* 29/09/2010 File Create                                               */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/*                                                                      */
/************************************************************************/

using System;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;
using log4net;
using SubSonic;
using VietNamNet.AddOn.Tracker.Components;
using VietNamNet.AddOn.Tracker.Core.tracker;
using VietNamNet.AddOn.Tracker.Process.Commponents;

namespace VietNamNet.AddOn.Tracker.Process
{
    public partial class frmArticleProcess : Form
    {
        #region Members

        private int c = 0;
        private string _fileName = string.Empty;
        private string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                //RecentFileList.InsertFile(value);
            }
        }

        private List<LogEntry> _entries = new List<LogEntry>();
        public List<LogEntry> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        private DateTime _lastUpdate;

        private readonly ILog iLog = LogManager.GetLogger(Constants.ServiceName.Article);
        //protected ILog iLog = LogManager.GetLogger("adsafsdf");
        #endregion

        #region Members
        public frmArticleProcess()
        {
            log4net.Config.DOMConfigurator.Configure();
            InitializeComponent();
        }
        private void frmArticleProcess_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Configurations.Article.LogFilePath();
            SetupEnvironment();

            //MessageBox.Show("done ....");
            if (Configurations.Forms.AutoClose())
            {
                this.Dispose(); 
            } 
        }
        private void cmdRead_Click(object sender, EventArgs e)
        {
            runProcess();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            SetupEnvironment();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                runProcess();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ex=" + ex.Message);
            }
        }

        #endregion

        #region Private Methods
        private void runProcess()
        {
            _entries.Clear();

            // file name đọc từ config
            ReadLogfile(txtFileName.Text);
            UpdateLogProcess();
        }
        private void SetupEnvironment()
        {
            txtMessage.Text = "";

            // gọi vào db lấy ngày cập nhật gần nhất
            //DateTime d = new Select(TrackingArticle.Columns.CreatedOn).Top("1")
            //                        .From(TrackingArticle.Schema.Name)
            //                        .OrderDesc(TrackingArticle.Columns.CreatedOn)
            //                        .Execute() == 0 ? 
            //             DateTime.Now.AddYears(-1) :
            //             new Select(TrackingArticle.Columns.CreatedOn).Top("1")
            //                        .From(TrackingArticle.Schema.Name)
            //                        .OrderDesc(TrackingArticle.Columns.CreatedOn)
            //                        .ExecuteScalar<DateTime>();
            
            DateTime d = new Select    (TrackingArticle.Columns.ModifyOn).Top("1").From( TrackingArticle.Schema).OrderDesc(TrackingArticle.Columns.ModifyOn).ExecuteScalar<DateTime>();
            //SubSonic.SqlQuery query = new Select().Top("1").From(TrackingArticle.Schema);



            if (d <= DateTime.Now.AddYears(-1))
            {
                _lastUpdate = DateTime.Now.AddDays(-7);
            }
            else
            {
                _lastUpdate = d;
            }

            //txtLastUpdate.Text = _lastUpdate.ToString();
            
            _entries.Clear();

           
                timer1.Enabled = true;
                //timer1.Interval = 2 * 60 * 1000; // get interval from config file
                timer1.Interval = Configurations.Article.TrackerInterval() * 1000;
                runProcess();
             
        }

        private void ReadLogfile(string filePath)
        {
            c = 0;
            DateTime d = _lastUpdate;

            while (d <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour,0,0))
            {
                FileName = string.Format(filePath, d.ToString("yyyyMMdd-HH"));

                List<LogEntry> le = LogFile.ReadFileBuffer(FileName);
                if (le.Count > 0)
                {
                    foreach (LogEntry e in le)
                    {
                        _entries.Add(e);
                    }
                    c++;

                    iLog.Info("Read file: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n"); 
                    txtMessage.Text = "Read file: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n" + txtMessage.Text;
                }
                //txtMessage.Text = "Read file: " + FileName.Substring(FileName.IndexOf("log4net\\")) + "\r\n" + txtMessage.Text;
                d = d.AddHours(1);
            }
            iLog.Info("Number of file read: " + c.ToString() + "\r\n"); 
            txtMessage.Text = "Number of file read: " + c.ToString() + "\r\n" + txtMessage.Text;
        }
        private void UpdateLogProcess()
        {
            if (_entries.Count > 0)
            {
                string oId; int countUpdate = 0;
                
                try
                {   //Update to Database
                    using (SharedDbConnectionScope sharedConnectionScope = new SharedDbConnectionScope(VietNamNet.AddOn.Tracker.Core.tracker.DB._provider)  )
                    {
                        using (TransactionScope ts = new TransactionScope())
                        {
                            foreach (LogEntry log in _entries)
                            {
                                if (log.TimeStamp.CompareTo(_lastUpdate) > 0) // Nếu ngày lớn hơn lần cuối cập thì update vào DB
                                {
                                    if (Utils.IsInfoInLog(log, "articleId")  && 
                                        Utils.IsInfoInLog(log, "categoryAlias")  &&
                                        Utils.IsInfoInLog(log, "createdAt"))
                                    {

                                        
                                        TrackingArticle obj = new TrackingArticle(false);

                                        obj.IPAddress = Utils.GetInfoFromLog(log, "Ip", ":");


                                        obj.ArticleId = int.Parse(Utils.GetInfoFromLog(log, "articleId"));
                                        obj.CategoryAlias = Utils.GetInfoFromLog(log, "categoryAlias");
 ; 
                                        obj.CreatedOn= log.TimeStamp;
                                        obj.ModifyOn = log.TimeStamp;


                                        using (SharedDbConnectionScope scope = new SharedDbConnectionScope(DB._provider))
                                        {
                                          obj.Save();
                                            
                                        }
                                      
                                        

                                        countUpdate++;
                                        _lastUpdate = log.TimeStamp;
                                    }
                                }

                            }
                            ts.Complete();
                            ts.Dispose();


                        }
                    }
                    iLog.Info("Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n"); 
                    txtMessage.Text = "Last update success at: " + DateTime.Now + "; log updated: " + countUpdate.ToString() + "\r\n" + txtMessage.Text;

                    txtLastUpdate.Text = _lastUpdate.ToString();
                }
                catch (Exception ex)
                {
                    iLog.Error("Last update fail at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n"); 
                    txtMessage.Text = "Last update fail at: " + DateTime.Now.ToString() + ";ex=" + ex.Message + "\r\n" + txtMessage.Text;
                    throw new Exception(ex.Message + " " + txtMessage.Text,ex);
                }
            }
        }

        #endregion


    }
}