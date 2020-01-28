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
        /// Returns Java Script Pop-Up Message In Web Page Screen
        /// </summary>
        /// <returns>Returns Java Script Pop-Up Message In Web Page Screen</returns>
        /// <code>FL_message(message)</code>
        /// <example>FL_message(message)</example>
        /// <param name="message">Message Parameter</param>
        /*public static string FL_message(this string message)
        {
            return "<script language='javascript'>" +
                   "window.alert('" +
                   message + "');" +
                   "</script>";
        }*/

        /// <summary>
        /// Returns Java script pop-up message in web page screen and Redirects to a new web page
        /// </summary>
        /// <summary>FL_message(message,redirect_page_name)</summary>
        /// <returns>Returns Java script pop-up message in web page screen and Redirects to a new web page</returns>
        /// <code>FL_message(message,redirect_page_name)</code>
        /// <example>FL_message(message,redirect)</example>
        /// <param name="message">Message Parameter</param>
        /// <param name="redirect">Redirect Parameter</param>
        public static string FL_message(this string message, string redirect = null)
        {
            if (!string.IsNullOrEmpty(redirect))
            {
                return "<script language='javascript'>" +
                       "window.alert('" +
                       message + "');" +
                       "window.location='" + redirect + "';" +
                       "</script>";
            }
            else
            {
                return "<script language='javascript'>" +
                       "window.alert('" +
                       message + "');" +
                       "</script>";
            }

        }

        public static string FL_printmessage_to_webpage(this string message)
        {
            return message + "<br/>";
        }
    }
}
