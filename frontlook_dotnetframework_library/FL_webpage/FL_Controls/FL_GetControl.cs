using System;
using System.Security.Policy;
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
            var ChildControl = FL_GetChildControl(ParentControl, ChildId);
            if (ChildControl is ITextControl)
            {
                return ((ITextControl)ChildControl).Text; // works also for the RadComboBox since it returns the currently selected item's text
            }

            if (ChildControl is ICheckBoxControl CheckBoxControl)
            {
                return (CheckBoxControl).Checked.ToString();
            }

            if (ChildControl is DropDownList)
            {
                if (!string.IsNullOrEmpty(ddl_string_reqd))
                {
                    if (string.Equals(ddl_string_reqd, "item"))
                    {
                        return ((DropDownList)ChildControl).SelectedItem.ToString();
                    }

                    if (string.Equals(ddl_string_reqd, "value"))
                    {
                        return ((DropDownList)ChildControl).SelectedValue;
                    }

                    return ((DropDownList)ChildControl).SelectedItem.ToString();
                }

                return ((DropDownList)ChildControl).SelectedItem.ToString();
            }

            return null;
        }

        /// <summary>
        /// For DropDownList And TextBox
        /// </summary>
        /// <param name="ParentControl"></param>
        /// <param name="ChildId"></param>
        /// <param name="value"></param>
        /// <param name="ddl_string_reqd"></param>
        public static void FL_SetControlString(Control ParentControl, string ChildId, string value, string ddl_string_reqd = null)
        {
            var ChildControl = ParentControl.FindControl(ChildId);
            if (ChildControl is ITextControl)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ((ITextControl)ChildControl).Text = value;
                }
                else
                {
                    ((ITextControl)ChildControl).Text = "";
                }
            }
            else if (ChildControl is ICheckBoxControl CheckBoxControl)
            {
                bool a = false;
                bool b = true;
                Boolean.TryParse(value, out a);
                Boolean.TryParse(value, out b);
                if (a.Equals(true) || b.Equals(false))
                {
                    CheckBoxControl.Checked = Boolean.Parse(value);
                }
                else
                {
                    CheckBoxControl.Checked = false;
                }
            }
            else if (ChildControl is DropDownList)
            {
                if (!string.IsNullOrEmpty(ddl_string_reqd))
                {
                    if (string.Equals(ddl_string_reqd, "item"))
                    {
                        ((DropDownList)ChildControl).Items.FindByText(value);
                    }
                    else if (string.Equals(ddl_string_reqd, "value"))
                    {
                        ((DropDownList)ChildControl).Items.FindByValue(value);
                    }
                    else
                    {
                        ((DropDownList)ChildControl).Items.FindByText(value);
                    }
                }
                else
                {
                    ((DropDownList)ChildControl).Items.FindByText(value);
                }
            }
        }
    }
}