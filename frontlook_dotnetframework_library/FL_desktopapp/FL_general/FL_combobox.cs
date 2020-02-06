using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General
{
    /// <summary>
    /// Defines the <see cref="FL_Combobox" />
    /// </summary>
    public static class FL_Combobox
    {
        /// <summary>
        /// The ComboBoxStrings
        /// </summary>
        /// <param name="ComboBox">The ComboBox<see cref="ComboBox"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] ComboBoxStrings(ComboBox ComboBox)
        {
            var items = new string[ComboBox.Items.Count];

            for (var i = 0; i < ComboBox.Items.Count; i++)
            {
                items[i] = ComboBox.Items[i].ToString();
            }
            return items;
        }

        /// <summary>
        /// The search_result
        /// </summary>
        /// <param name="TempStr">The TempStr<see cref="string"/></param>
        /// <param name="Cmblist">The Cmblist<see cref="List{string}"/></param>
        /// <returns>The <see cref="IEnumerable{string}"/></returns>
        public static IEnumerable<string> search_result(string TempStr, List<string> Cmblist)
        {
            var data = Cmblist.Where(M => M.ToLower().Contains(TempStr.ToLower()));
            return data;
        }
    }
}
