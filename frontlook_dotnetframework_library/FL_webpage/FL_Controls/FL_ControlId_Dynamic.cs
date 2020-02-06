using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using _Controls = frontlook_dotnetframework_library.FL_webpage.FL_Controls.FL_Control;
using _sql = frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_SqlExecutor;

namespace frontlook_dotnetframework_library.FL_webpage.FL_Controls
{
    /// <summary>
    /// Defines the <see cref="FL_ControlId_Dynamic" />
    /// </summary>
    public static class FL_ControlId_Dynamic
    {
        /// <summary>
        /// The Head_Count_DB
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Table_Name">The Table_Name<see cref="string"/></param>
        /// <param name="Schema_Name">The Schema_Name<see cref="string"/></param>
        /// <param name="Anti_Parameter">The Anti_Parameter<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
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

        /// <summary>
        /// The Get_Ids_DB
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Table_Name">The Table_Name<see cref="string"/></param>
        /// <param name="Schema_Name">The Schema_Name<see cref="string"/></param>
        /// <param name="Anti_Parameter">The Anti_Parameter<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
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

        /// <summary>
        /// The Get_ControlIds_DB
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Table_Name">The Table_Name<see cref="string"/></param>
        /// <param name="Schema_Name">The Schema_Name<see cref="string"/></param>
        /// <param name="Anti_Parameter">The Anti_Parameter<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] Get_ControlIds_DB(this MySqlCommand Cmd, MySqlConnection Con,
            string Table_Name, string Schema_Name, string Anti_Parameter = null)
        {
            var count = Cmd.Head_Count_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
            var ids = Cmd.Get_Ids_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
            var Controlids = new string[count];
            for (var b = 0; b <= (count - 1); b++)
            {
                Controlids[b] = ids[b].Replace(" ", "");
            }
            return Controlids;
        }

        /*
                public static void DynamicControls_DB(this MySqlCommand Cmd, MySqlConnection Con,
                    string Table_Name, string Schema_Name, Control Control, string Anti_Parameter = null)
                {
                    var count = Cmd.Head_Count_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
                    var ControlIds = Cmd.Get_ControlIds_DB(Con, Table_Name, Schema_Name, Anti_Parameter);
                    for (var b = 0; b <= (count - 1); b++)
                    {
                        Control.Controls.Add(FL_Label_TextBox.FL_label_readonly_textbox_default(ControlIds[b]));
                    }
                }
        */
        /// <summary>
        /// The Selection_Input_Builder
        /// </summary>
        /// <param name="Count">The Count<see cref="int"/></param>
        /// <param name="Ids">The Ids<see cref="IReadOnlyList{string}"/></param>
        /// <returns>The <see cref="string"/></returns>
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

        /// <summary>
        /// The Selection_elements_builder
        /// </summary>
        /// <param name="Count">The Count<see cref="int"/></param>
        /// <param name="Ids">The Ids<see cref="IReadOnlyList{string}"/></param>
        /// <param name="ParentControl">The ParentControl<see cref="Control"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string Selection_elements_builder(int Count, IReadOnlyList<string> Ids, Control ParentControl)
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
                        if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ITextControl)
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + c + ctrl.Text + c;
                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ICheckBoxControl)
                        {
                            var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.Checked;
                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is DropDownList)
                        {
                            var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + c + ctrl.SelectedValue + c;
                        }
                    }
                    else
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ITextControl)
                        {
                            if (_Controls.FL_GetChildControl(ParentControl, Ids[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                                q = q + c + ctrl.Text + f;
                            }
                            else
                            {
                                var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                                q = q + c + ctrl.Text + a;
                            }

                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ICheckBoxControl)
                        {
                            if (_Controls.FL_GetChildControl(ParentControl, Ids[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                                q = q + ctrl.Checked + e;
                            }
                            else
                            {
                                var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                                q = q + ctrl.Checked + d;
                            }
                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is DropDownList)
                        {
                            if (_Controls.FL_GetChildControl(ParentControl, Ids[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                                q = q + c + ctrl.SelectedValue + f;
                            }
                            else
                            {
                                var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                                q = q + c + ctrl.Text + a;
                            }
                        }
                    }
                }
                else if (b > 0 && Count > (b + 1))
                {
                    if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ITextControl)
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, Ids[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.Text + f;
                        }
                        else
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.Text + a;
                        }
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ICheckBoxControl)
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, Ids[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.Checked + e;
                        }
                        else
                        {
                            var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.Checked + d;
                        }
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is DropDownList)
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, Ids[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.SelectedValue + f;
                        }
                        else
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                            q = q + ctrl.Text + a;
                        }
                    }
                }
                else if (b > 0 && Count == (b + 1))
                {
                    if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ITextControl)
                    {
                        var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                        q = q + ctrl.Text + c;
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is ICheckBoxControl)
                    {
                        var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
                        q = q + ctrl.Checked;
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, Ids[b]) is DropDownList)
                    {
                        var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, Ids[b]);
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
