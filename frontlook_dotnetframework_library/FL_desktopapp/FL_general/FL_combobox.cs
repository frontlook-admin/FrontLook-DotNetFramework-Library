using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_General
{
    public static class FL_Combobox
    {
        public static string[] ComboBoxStrings(ComboBox ComboBox)
        {
            var items = new string[ComboBox.Items.Count];

            for(var i = 0; i<ComboBox.Items.Count; i++)
            {
                items[i] = ComboBox.Items[i].ToString();
            }
            return items;
        }

        public static IEnumerable<string> search_result(string TempStr, List<string> Cmblist)
        {
            var data = Cmblist.Where(M => M.ToLower().Contains(TempStr.ToLower()));
            return data;
        }

    }
}
