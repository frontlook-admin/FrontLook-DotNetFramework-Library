using System;
using System.Globalization;
using System.Threading;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General.FL_string_helper
{
    //Returns DateTime
    public static class FL_DateTime
    {

        ///<summary>
        /// Returns DateTime from string like 30-11-2019
        /// </summary>
        /// <remarks>Returns Datetime</remarks>
        /// <returns>DateTime</returns>
        public static DateTime Parse_dd_mm_yyyy(string DateString)
        {
            var ci = new CultureInfo("en-IN");
            switch (DateString.Length)
            {
                case 8:
                    return DateTime.ParseExact(DateString, "dd-MM-yy", ci, DateTimeStyles.AssumeLocal);
                case 6:
                    return DateTime.ParseExact(DateString, "dd-MM-", ci, DateTimeStyles.AssumeLocal);
                default:
                    return DateTime.ParseExact(DateString, "dd-MM-yyyy", ci, DateTimeStyles.AssumeLocal);
            }
        }

        ///<summary>
        /// Returns DateTime from string like 30112019
        /// </summary>
        /// <remarks>Returns Datetime</remarks>
        /// <returns>DateTime</returns>
        public static DateTime Parse_ddmmyyyy(string DateString)
        {
            var ci = new CultureInfo("en-IN");
            return DateTime.ParseExact(DateString, "ddMMyyyy", ci, DateTimeStyles.AssumeLocal);
        }

        ///<summary>
        /// Returns DateTime from string like 2019-11-30
        /// </summary>
        /// <remarks>Returns Datetime</remarks>
        /// <returns>DateTime</returns>
        public static DateTime Parse_yyyy_mm_dd(string DateString)
        {
            var ci = new CultureInfo("en-IN");
            return DateTime.ParseExact(DateString, "yyyy_MM_dd", ci, DateTimeStyles.AssumeLocal);
        }

        ///<summary>
        /// Returns DateTime from string like 8/30/2019 1:15:36 PM In windows 7
        /// Returns DateTime from string like 30/AUG/2019 1:15:36 PM/30/08/2019 1:15:36 PM In windows 8 onwards.
        /// </summary>
        /// <remarks>Returns Datetime</remarks>
        /// <returns>DateTime</returns>
        public static DateTime Parse_DateTime(string DateTime)
        {

            //var ci = new CultureInfo("en-IN");
            //var cu = CultureInfo.CurrentUICulture.DateTimeFormat.FullDateTimePattern;
            //var cd = CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            //var cf = currentCulture.DateTimeFormat.ShortDatePattern + " " + currentCulture.DateTimeFormat.LongTimePattern;
            //return DateTime.ParseExact(dateTime, cf, ci, DateTimeStyles.AssumeLocal);
            return System.DateTime.Parse(DateTime, currentCulture);
        }
    }
}
