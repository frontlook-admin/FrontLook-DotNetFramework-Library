using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using _sql = frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql.FL_MySqlExecutor;
using _controls = frontlook_dotnetframework_library.FL_webpage.FL_Controls.FL_GetControl;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    public static class FL_ControlId_Dynamic
    {
        public static int Head_Count_DB(this MySqlCommand Cmd, MySqlConnection Con,
            string Table_Name, string Schema_Name, string Anti_Parameter = null)
        {
            var count = 0;
            string command;
            if (string.IsNullOrEmpty(Anti_Parameter))
            {
                command = "SELECT COUNT(COLUMN_NAME) as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          Schema_Name + "' AND TABLE_NAME='" + Table_Name + "';";
            }
            else
            {
                command = "SELECT COUNT(COLUMN_NAME) as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          Schema_Name + "' AND TABLE_NAME='" + Table_Name + "' AND COLUMN_NAME NOT IN (SELECT '" + Anti_Parameter + "');";
            }
            Cmd.CommandText = command;
            Cmd.Connection = Con;
            _sql.Con_switch(Con);
            var reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                count = int.Parse(reader["c"].ToString());
            }
            reader.Close();
            _sql.Con_switch(Con);
            return count;
        }

        public static string[] Get_Ids_DB(this MySqlCommand Cmd, MySqlConnection Con,
            string Table_Name, string Schema_Name, string Anti_Parameter = null)
        {
            var ids = new string[Cmd.Head_Count_DB(Con, Table_Name, Schema_Name)];
            string command;
            if (string.IsNullOrEmpty(Anti_Parameter))
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          Schema_Name + "' AND TABLE_NAME='" + Table_Name + "' ORDER BY ORDINAL_POSITION;";
            }
            else
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          Schema_Name + "' AND TABLE_NAME='" + Table_Name + "' AND COLUMN_NAME NOT IN (SELECT '" + Anti_Parameter + "') ORDER BY ORDINAL_POSITION;";
            }
            Cmd.CommandText = command;
            var i = 0;
            Cmd.Connection = Con;
            _sql.Con_switch(Con);
            var reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                ids[i] = reader["c"].ToString();
                i++;
            }
            reader.Close();
            reader.Dispose();
            _sql.Con_switch(Con);
            return ids;
        }

        public static string[] Get_ControlIds_DB(this MySqlCommand Cmd, MySqlConnection Con,
            string Table_Name, string Schema_Name, string Anti_Parameter = null)
        {
            var count = Cmd.Head_Count_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
            var ids = Cmd.Get_Ids_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
            var controlids = new string[count];
            for (var b = 0; b <= (count - 1); b++)
            {
                controlids[b] = ids[b].Replace(" ", "");
            }
            return controlids;
        }

        /*
                public static void Dynamiccontrols_DB(this MySqlCommand Cmd, MySqlConnection Con,
                    string Table_Name, string Schema_Name, Control Control, string Anti_Parameter = null)
                {
                    var count = Cmd.Head_Count_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
                    var controlIds = Cmd.Get_ControlIds_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
                    for (var b = 0; b <= (count - 1); b++)
                    {
                        Control.Controls.Add(FL_Label_TextBox.FL_label_readonly_textbox_default(controlIds[b]));
                    }
                }
        */

        public static string Selection_Input_Builder(int Count, IReadOnlyList<string> Ids)
        {
            const string c = "`";
            const string a = "`,`";
            var q = "";
            for (var b = 0; b <= (Count - 1); b++)
            {
                if (b == 0)
                {
                    if (Count == 1)
                    {
                        q = q + c + Ids[b] + c;
                    }
                    else
                    {
                        q = q + c + Ids[b] + a;
                    }
                }
                else if (b > 0 && Count > (b + 1))
                {
                    q = q + Ids[b] + a;
                }
                else if (b > 0 && Count == (b + 1))
                {
                    q = q + Ids[b] + c;
                }
                else
                {
                    break;
                }
            }
            return q;
        }

        public static string Selection_elements_builder(int Count, IReadOnlyList<string> Ids, Control Parentcontrol)
        {
            const string c = "'";
            const string a = "','";
            const string d = ",'";
            const string f = "',";
            const string e = ",";
            var q = "";
            for (var b = 0; b <= (Count - 1); b++)
            {
                if (b == 0)
                {
                    if (Count == 1)
                    {
                        if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ITextControl)
                        {
                            var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + c + ctrl.Text + c;
                        }
                        else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ICheckBoxControl)
                        {
                            var ctrl = (ICheckBoxControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.Checked;
                        }
                        else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is DropDownList)
                        {
                            var ctrl = (DropDownList)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + c + ctrl.SelectedValue + c;
                        }
                    }
                    else
                    {
                        if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ITextControl)
                        {
                            if (_controls.FL_GetChildControl(Parentcontrol, Ids[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                                q = q + c + ctrl.Text + f;
                            }
                            else
                            {
                                var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                                q = q + c + ctrl.Text + a;
                            }

                        }
                        else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ICheckBoxControl)
                        {
                            if (_controls.FL_GetChildControl(Parentcontrol, Ids[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (ICheckBoxControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                                q = q + ctrl.Checked + e;
                            }
                            else
                            {
                                var ctrl = (ICheckBoxControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                                q = q + ctrl.Checked + d;
                            }
                        }
                        else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is DropDownList)
                        {
                            if (_controls.FL_GetChildControl(Parentcontrol, Ids[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (DropDownList)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                                q = q + c + ctrl.SelectedValue + f;
                            }
                            else
                            {
                                var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                                q = q + c + ctrl.Text + a;
                            }
                        }
                    }
                }
                else if (b > 0 && Count > (b + 1))
                {
                    if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ITextControl)
                    {
                        if (_controls.FL_GetChildControl(Parentcontrol, Ids[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.Text + f;
                        }
                        else
                        {
                            var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.Text + a;
                        }
                    }
                    else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ICheckBoxControl)
                    {
                        if (_controls.FL_GetChildControl(Parentcontrol, Ids[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (ICheckBoxControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.Checked + e;
                        }
                        else
                        {
                            var ctrl = (ICheckBoxControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.Checked + d;
                        }
                    }
                    else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is DropDownList)
                    {
                        if (_controls.FL_GetChildControl(Parentcontrol, Ids[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (DropDownList)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.SelectedValue + f;
                        }
                        else
                        {
                            var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                            q = q + ctrl.Text + a;
                        }
                    }
                }
                else if (b > 0 && Count == (b + 1))
                {
                    if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ITextControl)
                    {
                        var ctrl = (ITextControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                        q = q + ctrl.Text + c;
                    }
                    else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is ICheckBoxControl)
                    {
                        var ctrl = (ICheckBoxControl)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                        q = q + ctrl.Checked;
                    }
                    else if (_controls.FL_GetChildControl(Parentcontrol, Ids[b]) is DropDownList)
                    {
                        var ctrl = (DropDownList)_controls.FL_GetChildControl(Parentcontrol, Ids[b]);
                        q = q + ctrl.SelectedValue + c;
                    }
                }
                else
                {
                    break;
                }
            }
            return q;
        }
    }
}
