using System.Linq;
using System.Text;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General.FL_string_helper
{
    /// <summary>
    /// String Maintainer
    /// </summary>

    /// <summary>
    /// Filters string.
    /// </summary>
    public static class FL_String_Element_Filter
    {
        /// <summary>
        /// Filters and removes only special characters.
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_remove_special_char(string Str)
        {
            var sb = new StringBuilder();
            foreach (var c in Str.Where(C =>
                (C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z') || C == '.' || C == '_'))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Accepts only digits
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_acceptonlydigit(string Str)
        {
            var sb = new StringBuilder();
            foreach (var c in Str.Where(C => (C >= '0' && C <= '9')))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Accepts only alphabets
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_acceptonlyalphabet(string Str)
        {
            var sb = new StringBuilder();
            foreach (var c in Str.Where(C => (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z')))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Accepts alphabet and digit.
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_acceptAlphabetAndNumber(string Str)
        {
            var sb = new StringBuilder();
            foreach (var c in Str.Where(C => (C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z')))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Accepts Alphabet Number Point and Underscore
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_acceptAlphabetNumberPointUnderscore(string Str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in Str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Accepts number and point
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_acceptNumberAndPoint(string Str)
        {
            var sb = new StringBuilder();
            foreach (var c in Str.Where(C => (C >= '0' && C <= '9') || C == '.'))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Accepts Emailaddress Parameters
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string FL_acceptEmailAddress(string Str)
        {
            var sb = new StringBuilder();
            foreach (var c in Str.Where(C => (C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') ||
                                             (C >= 'a' && C <= 'z') || C == '.' ||
                                             C == '_' || C == '@'))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
