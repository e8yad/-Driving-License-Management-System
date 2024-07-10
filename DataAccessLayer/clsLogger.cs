using System;
using System.Diagnostics;

namespace DataAccessLayer
{
    internal class clsLogger
    { 

        /// <summary>
        ///  Function that is Responsible to log all error happened during run time 
        /// </summary>
        /// <param name="e">is exception happened</param>
        public static void LogErrors(Exception e)
        {
            string Source = "DVLD";
            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, "Application");
            }

            string EventContent = e.Message + '\n' + e.StackTrace;

            try
            {
                EventLog.WriteEntry(Source, EventContent, EventLogEntryType.Error,e.HResult);

            }
            catch (Exception)
            {


            }

        }
    }
}
