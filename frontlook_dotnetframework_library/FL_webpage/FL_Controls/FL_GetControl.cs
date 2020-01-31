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

        public static string FL_GetControlString(Control ParentControl, string ChildId, string Ddl_String_Reqd = null)
        {
            var ChildControl = FL_GetChildControl(ParentControl, ChildId);
            switch (ChildControl)
            {
                case ITextControl Control:
                    return Control.Text; // works also for the RadComboBox since it returns the currently selected item's text
                case ICheckBoxControl CheckBoxControl:
                    return CheckBoxControl.Checked.ToString();
                default:
                {
                    if (ChildControl is DropDownList List)
                    {
                        return !string.IsNullOrEmpty(Ddl_String_Reqd)
                            ? string.Equals(Ddl_String_Reqd, "item") ? List.SelectedItem.ToString() :
                            string.Equals(Ddl_String_Reqd, "value") ? List.SelectedValue : List.SelectedItem.ToString()
                            : List.SelectedItem.ToString();

                    }
                    else
                        return string.Empty;
                }
            }
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
            switch (ChildControl)
            {
                case ITextControl Control when !string.IsNullOrEmpty(value):
                    Control.Text = value;
                    break;
                case ITextControl Control:
                    Control.Text = "";
                    break;
                case ICheckBoxControl CheckBoxControl:
                {
                    bool a = false;
                    bool b = true;
                    bool.TryParse(value, out a);
                    bool.TryParse(value, out b);
                    if (a.Equals(true) || b.Equals(false))
                    {
                        CheckBoxControl.Checked = bool.Parse(value);
                    }
                    else
                    {
                        CheckBoxControl.Checked = false;
                    }

                    break;
                }
                default:
                {
                    if (ChildControl is DropDownList List)
                    {
                        if (!string.IsNullOrEmpty(ddl_string_reqd))
                        {
                            if (string.Equals(ddl_string_reqd, "item"))
                            {
                                List.Items.FindByText(value);
                            }
                            else if (string.Equals(ddl_string_reqd, "value"))
                            {
                                List.Items.FindByValue(value);
                            }
                            else
                            {
                                List.Items.FindByText(value);
                            }
                        }
                        else
                        {
                            List.Items.FindByText(value);
                        }
                    }
                    break;
                }
            }
        }
    }
}