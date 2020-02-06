using System;
using System.Drawing;
using System.Globalization;

namespace frontlook_dotnetframework_library.FL_webpage.FL_general
{
    /// <summary>
    /// Defines the <see cref="FL_Color" />
    /// </summary>
    public static class FL_Color
    {
        /// <summary>
        /// The FL_Color_Code
        /// </summary>
        /// <param name="Colorcode">The Colorcode<see cref="string"/></param>
        /// <returns>The <see cref="Color"/></returns>
        public static Color FL_Color_Code(string Colorcode)
        {
            Colorcode = Colorcode.TrimStart('#');
            Color col;
            if (Colorcode.Length == 6)
            {
                col = Color.FromArgb(255, // hardcoded opaque
                    int.Parse(Colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(4, 2), NumberStyles.HexNumber));
            }
            else if (Colorcode.Length == 8) // assuming length of 8
            {
                col = Color.FromArgb(
                    int.Parse(Colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(4, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(6, 2), NumberStyles.HexNumber));
            }
            else
            {
                col = Color.FromArgb(Int32.Parse(Colorcode, NumberStyles.HexNumber));
            }
            return col;
        }

        /// <summary>
        /// The FL_Color_Code
        /// </summary>
        /// <param name="Colorcode">The Colorcode<see cref="string"/></param>
        /// <param name="Colorcode_Substitute">The Colorcode_Substitute<see cref="string"/></param>
        /// <returns>The <see cref="Color"/></returns>
        public static Color FL_Color_Code(this string Colorcode, string Colorcode_Substitute = null)
        {
            if (String.IsNullOrEmpty(Colorcode))
            {
                if (!String.IsNullOrEmpty(Colorcode_Substitute))
                {
                    Colorcode = Colorcode_Substitute;
                }
                else
                {
                    Colorcode = "#0066FF";
                }
            }
            Colorcode = Colorcode.TrimStart('#');
            Color col;
            if (Colorcode.Length == 6)
            {
                col = Color.FromArgb(255, // hardcoded opaque
                    int.Parse(Colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(4, 2), NumberStyles.HexNumber));
            }
            else if (Colorcode.Length == 8) // assuming length of 8
            {
                col = Color.FromArgb(
                    int.Parse(Colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(4, 2), NumberStyles.HexNumber),
                    int.Parse(Colorcode.Substring(6, 2), NumberStyles.HexNumber));
            }
            else
            {
                col = Color.FromArgb(Int32.Parse(Colorcode, NumberStyles.HexNumber));
            }
            return col;
        }
    }
}
