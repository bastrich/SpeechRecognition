using System.IO;
using System;

namespace SpeechRecognition
{
    static class Logger
    {
        public const string LOGFILE= "log.txt";

        static Logger()
        {
            StreamWriter sw = File.AppendText(LOGFILE);
            sw.WriteLine("Log start  " + DateTime.Now.ToString());
            sw.Close();
        }

        public static void Add(string message)
        {
            try
            {
                StreamWriter sw = File.AppendText(LOGFILE);
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString().Remove(8,8) + ":  " + message);
                sw.Close();
            }
            catch (Exception e)
            {
                StreamWriter sw = File.CreateText(LOGFILE);
                sw.WriteLine("Log start again! " + e.Message + DateTime.Now.ToString());
                sw.WriteLine(DateTime.Now.TimeOfDay.ToString() + ":  " + message);
                sw.Close();
            }
        }
    }
}
