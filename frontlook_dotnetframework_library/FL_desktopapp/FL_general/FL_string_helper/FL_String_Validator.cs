using System.Linq;

// ReSharper disable Checkstring namespace
namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General.FL_string_helper
{
    /// <summary>
    /// String Maintainer
    /// </summary>

    /// <summary>
    /// String Validator
    /// </summary>
    public static class FL_String_Validator
    {
        /// <summary>
        /// Validates all but special characters
        /// </summary>
        /// <param name="Str">The Str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_notval_special_char(string Str)
        {
            var a = true;
            foreach (var b in Str.Select(C =>
                (a && !((C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z') || C == '.' ||
                        C == '_'))))
            {
                a = b;
            }
            return a;
        }

        /// <summary>
        /// Validates only digit
        /// </summary>
        /// <param name="Str">The Str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_val_onlydigit(string Str)
        {
            var a = true;
            foreach (var b in Str.Select(C => (a && !(C >= '0' && C <= '9'))))
            {
                a = b;
            }
            return a;
        }

        /// <summary>
        /// Validates only alphabet
        /// </summary>
        /// <param name="Str">The Str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_val_onlyalphabet(string Str)
        {
            var a = true;
            foreach (var b in Str.Select(C => (a && !((C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z')))))
            {
                a = b;
            }
            return a;
        }

        /// <summary>
        /// Validates alphabet and digit
        /// </summary>
        /// <param name="str">The str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_val_AlphabetAndDigit(string str)
        {
            var a = true;
            foreach (var b in str.Select(C =>
                (a && !((C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z')))))
            {
                a = b;
            }
            return a;
        }

        /// <summary>
        /// Validates Alphabet Number Point and Underscore
        /// </summary>
        /// <param name="Str">The Str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_val_AlphabetNumberPointUnderscore(string Str)
        {
            var a = true;
            foreach (var b in Str.Select(C =>
                (a && !((C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z') || C == '.' ||
                        C == '_'))))
            {
                a = b;
            }
            return a;
        }

        /// <summary>
        /// Validates number and point
        /// </summary>
        /// <param name="Str">The Str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_val_NumberAndPoint(string Str)
        {
            var a = true;
            foreach (var b in Str.Select(C => (a && !((C >= '0' && C <= '9') || C == '.'))))
            {
                a = b;
            }
            return a;
        }

        /// <summary>
        /// Accepts Emailaddress Parameters
        /// </summary>
        /// <param name="Str">The Str<see cref="string"/></param>
        /// <returns></returns>
        public static bool FL_val_EmailAddress(string Str)
        {
            var a = true;
            foreach (var b in Str.Select(C =>
                (a && !((C >= '0' && C <= '9') || (C >= 'A' && C <= 'Z') || (C >= 'a' && C <= 'z') || C == '.' ||
                        C == '_' || C == '@'))))
            {
                a = b;
            }
            return a;
        }
    }
}
