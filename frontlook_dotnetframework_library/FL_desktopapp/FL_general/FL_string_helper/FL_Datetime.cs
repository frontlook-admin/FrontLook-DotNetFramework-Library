using System;
using System.Globalization;
using System.Threading;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General.FL_string_helper
{
    //Returns DateTime
    /// <summary>
    /// Defines the <see cref="FL_DateTime" />
    /// </summary>
    public static class FL_DateTime
    {
        /// <summary>
        /// The Parse_dd_mm_yyyy
        /// </summary>
        /// <param name="DateString">The DateString<see cref="string"/></param>
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

        /// <summary>
        /// The Parse_ddmmyyyy
        /// </summary>
        /// <param name="DateString">The DateString<see cref="string"/></param>
        /// <returns>DateTime</returns>
        public static DateTime Parse_ddmmyyyy(string DateString)
        {
            var ci = new CultureInfo("en-IN");
            return DateTime.ParseExact(DateString, "ddMMyyyy", ci, DateTimeStyles.AssumeLocal);
        }

        /// <summary>
        /// The Parse_yyyy_mm_dd
        /// </summary>
        /// <param name="DateString">The DateString<see cref="string"/></param>
        /// <returns>DateTime</returns>
        public static DateTime Parse_yyyy_mm_dd(string DateString)
        {
            var ci = new CultureInfo("en-IN");
            return DateTime.ParseExact(DateString, "yyyy_MM_dd", ci, DateTimeStyles.AssumeLocal);
        }

        /// <summary>
        /// The Parse_DateTime
        /// </summary>
        /// <param name="DateTime">The DateTime<see cref="string"/></param>
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
