using System;
using System.Globalization;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General.FL_string_helper
{
    /// <summary>
    /// Defines the <see cref="FL_Date_Validator" />
    /// </summary>
    public static class FL_Date_Validator
    {
        /// <summary>
        /// The val_date_dd_mm_yyyy
        /// </summary>
        /// <param name="str">The str<see cref="string"/></param>
        /// <returns>The <see cref="Boolean"/></returns>
        public static Boolean val_date_dd_mm_yyyy(string str)
        {
            var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd-MM-", "dd-MM-yy" };
            DateTime scheduleDate;
            /*bool validDate = DateTime.TryParseExact(
                str,
                dateFormats,
                DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.None,
                out scheduleDate);*/
            return DateTime.TryParseExact(
                str,
                dateFormats,
                DateTimeFormatInfo.InvariantInfo,
                DateTimeStyles.None,
                out scheduleDate);
        }
    }
}
