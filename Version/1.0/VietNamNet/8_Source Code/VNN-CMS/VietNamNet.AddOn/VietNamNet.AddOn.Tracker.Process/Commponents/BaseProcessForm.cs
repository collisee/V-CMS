using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using VietNamNet.AddOn.Tracker.Components;

namespace VietNamNet.AddOn.Tracker.Process.Commponents
{

   public   class BaseProcessForm  : Form
    {
        #region Members

       public int c = 0;
        private string _fileName = string.Empty;
       public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
            }
        }

        private List<LogEntry> _entries = new List<LogEntry>();
        public List<LogEntry> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public DateTime _lastUpdate;

        public readonly ILog iLog = LogManager.GetLogger(Constants.ServiceName.Comment);

        #endregion

        #region Contructor

        public void FormLoad()
        {
            log4net.Config.DOMConfigurator.Configure();
        }
        #endregion

        #region Private Methods

        #endregion

    }
}
 