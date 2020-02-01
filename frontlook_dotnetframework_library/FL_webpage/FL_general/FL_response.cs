using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_general
{
    /// <summary>
    /// Returns Response To Web Pages
    /// </summary>
    public static class FL_response
    {
        /// <summary>
        /// Returns Java script pop-up message in web page screen and Redirects to a new web page
        /// </summary>
        /// <summary>FL_message(message,redirect_page_name)</summary>
        /// <returns>Returns Java script pop-up message in web page screen and Redirects to a new web page</returns>
        /// <code>FL_message(message,redirect_page_name)</code>
        /// <example>FL_message(message,redirect)</example>
        /// <param name="Message">Message Parameter</param>
        /// <param name="Redirect">Redirect Parameter</param>
        public static string FL_message(this string Message, string Redirect = null)
        {
            if (!string.IsNullOrEmpty(Redirect))
            {
                return "<script language='javascript'>" +
                       "window.alert('" +
                       Message + "');" +
                       "window.location='" + Redirect + "';" +
                       "</script>";
            }
            else
            {
                return "<script language='javascript'>" +
                       "window.alert('" +
                       Message + "');" +
                       "</script>";
            }

        }

        public static string FL_printmessage_to_webpage(this string message)
        {
            return message + "<br/>";
        }
    }
}
