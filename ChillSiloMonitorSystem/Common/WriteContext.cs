using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ChillSiloMonitorSystem.Common
{
    public class WriteContext
    {
        private WriteContext()
        {

        }

        public static void Debug(string strProductVersion, string strModule, string strProcedure, string strText, bool isShow = false)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Text:" + strText);
            WriteLog(sValue.ToString(), "Debug", isShow);
        }

        public static string DebugReturn(string strProductVersion, string strModule, string strProcedure, string strText)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Text:" + strText);
            return sValue.ToString();
        }


        public static void Error(string strProductVersion, string strModule, string strProcedure, string strText, bool isShow = false)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + Environment.NewLine);
            sValue.Append("Log Type: Error" + Environment.NewLine);
            sValue.Append("Log ProductVersion:" + strProductVersion + Environment.NewLine);
            sValue.Append("Log Module: " + strModule + Environment.NewLine);
            sValue.Append("Log Procedure: " + strProcedure + Environment.NewLine);
            sValue.Append("Log Text:" + strText + Environment.NewLine);
            WriteLog(sValue.ToString(), "Error", isShow);
        }

        public static string ErrorReturn(string strProductVersion, string strModule, string strProcedure, string strText)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + Environment.NewLine);
            sValue.Append("Log Type: Error" + Environment.NewLine);
            sValue.Append("Log ProductVersion:" + strProductVersion + Environment.NewLine);
            sValue.Append("Log Module: " + strModule + Environment.NewLine);
            sValue.Append("Log Procedure: " + strProcedure + Environment.NewLine);
            sValue.Append("Log Text:" + strText + Environment.NewLine);
            return sValue.ToString();
        }

        public static void Info(string strProductVersion, string strModule, string strProcedure, string strText, bool isShow = false)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + Environment.NewLine);
            sValue.Append("Log Type: Info" + Environment.NewLine);
            sValue.Append("Log ProductVersion:" + strProductVersion + Environment.NewLine);
            sValue.Append("Log Module: " + strModule + Environment.NewLine);
            sValue.Append("Log Procedure: " + strProcedure + Environment.NewLine);
            sValue.Append("Log Text:" + strText + Environment.NewLine);
            WriteLog(sValue.ToString(), "Info", isShow);
        }

        public static string InfoReturn(string strProductVersion, string strModule, string strProcedure, string strText)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + Environment.NewLine);
            sValue.Append("Log Type: Info" + Environment.NewLine);
            sValue.Append("Log ProductVersion:" + strProductVersion + Environment.NewLine);
            sValue.Append("Log Module: " + strModule + Environment.NewLine);
            sValue.Append("Log Procedure: " + strProcedure + Environment.NewLine);
            sValue.Append("Log Text:" + strText + Environment.NewLine);
            return sValue.ToString();
        }

        public static void Warn(string strProductVersion, string strModule, string strProcedure, string strText, bool isShow = false)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + Environment.NewLine);
            sValue.Append("Log Type: Warn" + Environment.NewLine);
            sValue.Append("Log ProductVersion:" + strProductVersion + Environment.NewLine);
            sValue.Append("Log Module: " + strModule + Environment.NewLine);
            sValue.Append("Log Procedure: " + strProcedure + Environment.NewLine);
            sValue.Append("Log Text:" + strText + Environment.NewLine);
            WriteLog(sValue.ToString(), "Warn", isShow);
        }

        public static string WarnReturn(string strProductVersion, string strModule, string strProcedure, string strText)
        {
            StringBuilder sValue = new StringBuilder();
            sValue.Append("Log Time: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + Environment.NewLine);
            sValue.Append("Log Type: Warn" + Environment.NewLine);
            sValue.Append("Log ProductVersion:" + strProductVersion + Environment.NewLine);
            sValue.Append("Log Module: " + strModule + Environment.NewLine);
            sValue.Append("Log Procedure: " + strProcedure + Environment.NewLine);
            sValue.Append("Log Text:" + strText + Environment.NewLine);
            return sValue.ToString();
        }



        private static void WriteLog(string sWriteData, string strType, bool isShow = false)
        {
            //Log
            string strText = string.Empty;
            string strObjectName = string.Empty;
            string strMessage = string.Empty;
            string strAckMessage = string.Empty;
            FileInfo fsFileInfo = null;
            FileStream filStream = null;
            StreamWriter swStream = null;
            string strPath = "~/Log/";// = Application.StartupPath;
            string[] files = null;
            DateTime nowDate = DateTime.Now;
            DateTime fDate = nowDate;
            //show log message
            if (isShow == true)
            {
                switch (strType)
                {
                    case "Debug":
                        strPath = strPath + "/Debug/";
                        // Response.Write()
                        // MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "Info":
                        strPath = strPath + "/Info/";
                        //  MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "Warn":
                        strPath = strPath + "/Warn/";
                        // MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "Error":
                        strPath = strPath + "Error/";
                        //  MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                switch (strType)
                {
                    case "Debug":
                        strPath = strPath + "/Debug/";
                        // Response.Write()
                        // MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case "Info":
                        strPath = strPath + "/Info/";
                        //  MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "Warn":
                        strPath = strPath + "/Warn/";
                        // MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case "Error":
                        strPath = strPath + "Error/";
                        //  MessageBox.Show(sWriteData, strText, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }

            ///log excption
            try
            {
                //del 
                files = System.IO.Directory.GetFiles(strPath, "*.Log");
                foreach (string strP in files)
                {
                    if (fDate.AddMonths(1).Date < Convert.ToDateTime(strP.Substring(strP.Length - 12, 12).Substring(0, 4) + "/" + strP.Substring(strP.Length - 12, 12).Substring(4, 2) + "/" + strP.Substring(strP.Length - 12, 12).Substring(6, 2)))
                    {
                        File.Delete(strP);
                    }
                }
                // check the log file exists, if does not exist, create the file
                strPath = strPath + "\\" + nowDate.ToString("yyyyMMdd") + ".Log";
                fsFileInfo = new FileInfo(strPath);
                if (File.Exists(strPath) == false)
                {
                    filStream = fsFileInfo.Create();
                    filStream.Close();
                }
                //checking the log file size
                if ((fsFileInfo.Length / 1000) >= 1024)
                {
                    // open the file data stream object
                    filStream = fsFileInfo.Open(FileMode.Open, FileAccess.Write);
                }
                else
                {
                    // open the file data strea additional object
                    filStream = fsFileInfo.Open(FileMode.Append, FileAccess.Write);
                }
                swStream = new StreamWriter(filStream);
                // after writing the wrong inforamtion, close the file
                var _with1 = swStream;
                _with1.WriteLine(sWriteData);
                _with1.WriteLine();
                _with1.Flush();
                _with1.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }
    }
}