using System;
using System.Windows.Forms;

namespace VietNamNet.AddOn.Tracker.Process
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch (Commponents.Configurations.Forms.StartupForm())
                {
                   case Commponents.Configurations.Forms.frmArticle:
                      Application.Run(new frmArticleProcess());
                        break;
                    case Commponents.Configurations.Forms.frmComment:
                        Application.Run(new frmCommentProcess());
                        break;
                    case Commponents.Configurations.Forms.frmSurvey:
                        Application.Run(new frmSurveyProcess());
                        break;
                    case Commponents.Configurations.Forms.frmSpeedTest:
                        Application.Run(new frmSpeedTestProcess());
                        break;
                    default :
                       Application.Run(new frmMainForm());
                        break;
                }

           

        }
    }
}