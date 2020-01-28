using System;
using System.Drawing;
using System.Globalization;

namespace frontlook_dotnetframework_library.FL_webpage.FL_general
{
    public static class FL_Color
    {
        public static Color FL_Color_Code(string colorcode)
        {
            colorcode = colorcode.TrimStart('#');
            Color col;
            if (colorcode.Length == 6)
            {
                col = Color.FromArgb(255, // hardcoded opaque
                    int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber));
            }
            else if (colorcode.Length == 8) // assuming length of 8
            {
                col = Color.FromArgb(
                    int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(6, 2), NumberStyles.HexNumber));
            }
            else
            {
                col = Color.FromArgb(Int32.Parse(colorcode, NumberStyles.HexNumber));
            }
            return col;
        }

        public static Color FL_Color_Code(this string colorcode, string colorcode_substitute = null)
        {
            if (String.IsNullOrEmpty(colorcode))
            {
                if (!String.IsNullOrEmpty(colorcode_substitute))
                {
                    colorcode = colorcode_substitute;
                }
                else
                {
                    colorcode = "#0066FF";
                }
            }
            colorcode = colorcode.TrimStart('#');
            Color col;
            if (colorcode.Length == 6)
            {
                col = Color.FromArgb(255, // hardcoded opaque
                    int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber));
            }
            else if (colorcode.Length == 8) // assuming length of 8
            {
                col = Color.FromArgb(
                    int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber),
                    int.Parse(colorcode.Substring(6, 2), NumberStyles.HexNumber));
            }
            else
            {
                col = Color.FromArgb(Int32.Parse(colorcode, NumberStyles.HexNumber));
            }
            return col;
        }
    }
}