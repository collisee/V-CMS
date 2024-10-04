using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace VietNamNet.AddOn.Tracker.Process.Commponents
{
    public static class LogFile
    {

        #region Read File Buffer
        public static List<LogEntry> ReadFileBuffer(string filePath)
        {
            List<LogEntry> entries = new List<LogEntry>();

            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string sBuffer = string.Empty;
            int iIndex = 1;


            try
            {
            
            FileStream oFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader oStreamReader = new StreamReader(oFileStream);
            sBuffer = string.Format("<root>{0}</root>", oStreamReader.ReadToEnd());
            oStreamReader.Close();
            oFileStream.Close();


            ////////////////////////////////////////////////////////////////////////////////
            StringReader oStringReader = new StringReader(sBuffer);
            XmlTextReader oXmlTextReader = new XmlTextReader(oStringReader);
            oXmlTextReader.Namespaces = false;
            while (oXmlTextReader.Read())
            {
                if ((oXmlTextReader.NodeType == XmlNodeType.Element) && (oXmlTextReader.Name == "log4j:event"))
                {
                    LogEntry logentry = new LogEntry();

                    logentry.Item = iIndex;

                    double dSeconds = Convert.ToDouble(oXmlTextReader.GetAttribute("timestamp"));
                    logentry.TimeStamp = dt.AddMilliseconds(dSeconds).ToLocalTime();
                    //logentry.TimeStamp = DateTime.Parse(oXmlTextReader.GetAttribute("timestamp"));
                    logentry.Thread = oXmlTextReader.GetAttribute("thread");

                    #region get level
                    /*///////////////////////////////////////////////////////////////////////////////
                        logentry.Level = oXmlTextReader.GetAttribute("level");
                        switch (logentry.Level)
                        {
                            case "ERROR":
                                {
                                    logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.ERROR);
                                    break;
                                }
                            case "INFO":
                                {
                                    logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.INFO);
                                    break;
                                }
                            case "DEBUG":
                                {
                                    logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.DEBUG);
                                    break;
                                }
                            case "WARN":
                                {
                                    logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.WARN);
                                    break;
                                }
                            case "FATAL":
                                {
                                    logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.FATAL);
                                    break;
                                }
                            default:
                                {
                                    logentry.Image = LogEntry.Images(LogEntry.IMAGE_TYPE.CUSTOM);
                                    break;
                                }
                        }
                        ///////////////////////////////////////////////////////////////////////////////*/
                    #endregion

                    #region read xml
                    ////////////////////////////////////////////////////////////////////////////////
                    while (oXmlTextReader.Read())
                    {
                        if (oXmlTextReader.Name == "log4j:event")   // end element
                            break;
                        else
                        {
                            switch (oXmlTextReader.Name)
                            {
                                case ("log4j:message"):
                                    {
                                        logentry.Message = oXmlTextReader.ReadString();
                                        break;
                                    }
                                case ("log4j:data"):
                                    {
                                        switch (oXmlTextReader.GetAttribute("name"))
                                        {
                                            case ("log4jmachinename"):
                                                {
                                                    logentry.MachineName = oXmlTextReader.GetAttribute("value");
                                                    break;
                                                }
                                            case ("log4net:HostName"):
                                                {
                                                    logentry.HostName = oXmlTextReader.GetAttribute("value");
                                                    break;
                                                }
                                            case ("log4net:UserName"):
                                                {
                                                    logentry.UserName = oXmlTextReader.GetAttribute("value");
                                                    break;
                                                }
                                            case ("log4japp"):
                                                {
                                                    logentry.App = oXmlTextReader.GetAttribute("value");
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case ("log4j:throwable"):
                                    {
                                        logentry.Throwable = oXmlTextReader.ReadString();
                                        break;
                                    }
                                case ("log4j:locationInfo"):
                                    {
                                        logentry.Class = oXmlTextReader.GetAttribute("class");
                                        logentry.Method = oXmlTextReader.GetAttribute("method");
                                        logentry.File = oXmlTextReader.GetAttribute("file");
                                        logentry.Line = oXmlTextReader.GetAttribute("line");
                                        break;
                                    }
                            }
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////
                    #endregion

                    entries.Add(logentry);
                    iIndex++;

                    #region Show Counts
                    /*///////////////////////////////////////////////////////////////////////////////
                        int ErrorCount =
                        (
                            from entry in Entries
                            where entry.Level == "ERROR"
                            select entry
                        ).Count();

                        if (ErrorCount > 0)
                        {
                            labelErrorCount.Content = string.Format("{0:#,#}  ", ErrorCount);
                            labelErrorCount.Visibility = Visibility.Visible;
                            imageError.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            labelErrorCount.Visibility = Visibility.Hidden;
                            imageError.Visibility = Visibility.Hidden;
                        }

                        int InfoCount = 
                        (
                            from entry in Entries
                            where entry.Level == "INFO"
                            select entry
                        ).Count();

                        if (InfoCount > 0)
                        {
                            labelInfoCount.Content = string.Format("{0:#,#}  ", InfoCount);
                            labelInfoCount.Visibility = Visibility.Visible;
                            imageInfo.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            labelInfoCount.Visibility = Visibility.Hidden;
                            imageInfo.Visibility = Visibility.Hidden;
                        }

                        int WarnCount =
                        (
                            from entry in Entries
                            where entry.Level == "WARN"
                            select entry
                        ).Count();

                        if (WarnCount > 0)
                        {
                            labelWarnCount.Content = string.Format("{0:#,#}  ", WarnCount);
                            labelWarnCount.Visibility = Visibility.Visible;
                            imageWarn.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            labelWarnCount.Visibility = Visibility.Hidden;
                            imageWarn.Visibility = Visibility.Hidden;
                        }

                        int DebugCount =
                        (
                            from entry in Entries
                            where entry.Level == "DEBUG"
                            select entry
                        ).Count();

                        if (DebugCount > 0)
                        {
                            labelDebugCount.Content = string.Format("{0:#,#}  ", DebugCount);
                            labelDebugCount.Visibility = Visibility.Visible;
                            imageDebug.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            labelDebugCount.Visibility = Visibility.Hidden;
                            labelDebugCount.Visibility = Visibility.Hidden;
                        }
                        ///////////////////////////////////////////////////////////////////////////////*/
                    #endregion
                }

            }
            }
            catch (Exception ex)
            {

            }

            return entries;
        }
        #endregion
         

    }
   
        
}
