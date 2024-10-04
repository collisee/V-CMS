using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace VietNamNet.AddOn.Tracker.Process.Commponents
{

   public static class Configurations
    {
       public static class Survey
       {
           public static int TrackerInterval()
           {
               return int.Parse(ConfigurationSettings.AppSettings.Get("SurveyTrackerInterval"));
           }

           public static string  LogFilePath()
           {
               return ConfigurationSettings.AppSettings.Get("SurveyLogFilePath");
           }
       }

       public static class Comment
       {
           public static int TrackerInterval()
           {
               return int.Parse(ConfigurationSettings.AppSettings.Get("CommentTrackerInterval"));
           }

           public static string LogFilePath()
           {
               return ConfigurationSettings.AppSettings.Get("CommentLogFilePath");
           }
       }

       public static class Article
       {
           public static int TrackerInterval()
           {
               return int.Parse(ConfigurationSettings.AppSettings.Get("ArticleTrackerInterval"));
           }

           public static string LogFilePath()
           {
               return ConfigurationSettings.AppSettings.Get("ArticleLogFilePath");
           }
       }



       public static class Forms
       {
           public const string frmSurvey = "SurveyProcess";
           public const string frmArticle = "ArticleProcess";
           public const string frmComment = "CommentProcess";
           public const string frmSpeedTest = "SpeedTestProcess";
           public const string frmMainForm = "MainForm";


           public static bool AutoClose()
           {
               return bool.Parse(ConfigurationSettings.AppSettings.Get("AutoClose"));
           }  

           public static string StartupForm()
           {
               return ConfigurationSettings.AppSettings.Get("StartupForm");
           } 

       }

          
    }
}
