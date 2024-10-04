using System;
using System.ServiceProcess;
using GetContentFromRolo;

namespace RoloService
{
    partial class RoloService : ServiceBase
    {
        public RoloService()
        {
            //_timer = new Timer(new TimerCallback(null), null, Timeout.Infinite, Timeout.Infinite);       
            InitializeComponent();
            this.ServiceName = "RoloService";
            this.eventLog1.Log = "Application";

            // These Flags set whether or not to handle that specific

            //  type of event. Set to true if you need it, false otherwise.

            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;

        }
 
        protected override void OnStart(string[] args)
        {
            Utils utils = null;
            utils = new Utils();
            String timeInterval = utils.GetAppSetting("TimeInterval") ?? "";
            utils = null;
            if (!timeInterval.Equals(""))
            {
                timer1.Interval = Int16.Parse(timeInterval) * 60000;
                timer1.Enabled = true;
                //eventLog1.WriteEntry("timeInterval will start after " + timeInterval);
            }
            else
            {
                timer1.Enabled = false;
                
            }
            eventLog1.WriteEntry("Rolo Service started");
           
            
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            eventLog1.WriteEntry("Rolo Service stoped");
        }
        private static void CrawlDataFromRolo()
        {
           new GetContentFromRolo.Main().GetContentFromRolo();
           
        }

        private void Timer1Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            eventLog1.Source = "RoloService";
            eventLog1.WriteEntry("Rolo Service starting get DATA at: " + DateTime.Now.ToString());
            CrawlDataFromRolo();
            eventLog1.Source = "RoloService";
            eventLog1.WriteEntry("Rolo Service finished get DATA at: " + DateTime.Now.ToString());
        }
    }
}
