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
        /// </summary>
        /// <param name="Message">Message Parameter</param>
        /// <param name="Redirect">Redirect Parameter</param>
        /// <returns>Returns Java script pop-up message in web page screen and Redirects to a new web page</returns>
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

        /// <summary>
        /// The FL_printmessage_to_webpage
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string FL_printmessage_to_webpage(this string message)
        {
            return message + "<br/>";
        }
    }
}
