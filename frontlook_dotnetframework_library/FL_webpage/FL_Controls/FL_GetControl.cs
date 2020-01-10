using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    public static class FL_GetControl
    {
        public static Control FL_GetChildControl(Control ParentControl, string ChildId)
        {
            var ChildControl = ParentControl.FindControl(ChildId);
            return ChildControl;
        }

        public static string FL_GetControlString(Control ParentControl, string ChildId, string ddl_string_reqd = null)
        {
            var ChildControl = ParentControl.FindControl(ChildId);
            if (ChildControl is ITextControl)
            {
                return ((ITextControl)ChildControl).Text; // works also for the RadComboBox since it returns the currently selected item's text
            }
            else if (ChildControl is ICheckBoxControl)
            {
                return ((ICheckBoxControl)ChildControl).Checked.ToString();
            }
            else if (ChildControl is DropDownList)
            {
                if (!String.IsNullOrEmpty(ddl_string_reqd))
                {
                    if (String.Equals(ddl_string_reqd, "item"))
                    {
                        return ((DropDownList)ChildControl).SelectedItem.ToString();
                    }
                    else if (String.Equals(ddl_string_reqd, "value"))
                    {
                        return ((DropDownList)ChildControl).SelectedValue.ToString();
                    }
                    else
                    {
                        return ((DropDownList)ChildControl).SelectedItem.ToString();
                    }
                }
                else
                {
                    return ((DropDownList)ChildControl).SelectedItem.ToString();
                }
            }
            else
            {
                return null;
            }
        }
    }
}