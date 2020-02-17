using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using _Controls = frontlook_dotnetframework_library.FL_webpage.FL_Controls.FL_Control;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql
{
    /// <summary>
    /// Defines the <see cref="FL_MySqlExecutor" />
    /// </summary>
    public static class FL_MySqlExecutor
    {
        /// <summary>
        /// The MySql_Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void MySql_Con_switch_on(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                var Con1 = new MySqlConnection
                {
                    ConnectionString = Con.ConnectionString
                };
                Con.Dispose();
                Con = Con1;
                Con.Open();
            }
            else
            {
                Con.Close();
                Con.Open();
            }
        }

        /// <summary>
        /// The MySql_Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void MySql_Con_switch_off(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        /// <summary>
        /// The MySql_Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void MySql_Con_switch(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                MySql_Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                MySql_Con_switch_on(Con);
            }
        }

        /// <summary>
        /// The ExecuteStoredProcedure
        /// </summary>
        public static void ExecuteStoredProcedure()
        {
        }

        /// <summary>
        /// The ExecuteMySqlCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteMySqlCommand(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            var r = Cmd.ExecuteNonQuery();
            MySql_Con_switch(Con);
            return r;
        }

        /// <summary>
        /// The GetMySqlValue
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="ParameterName"></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetMySqlValue(this MySqlCommand Cmd, string Query, MySqlConnection Con, string ParameterName)
        {
            var c = "";
            Cmd.CommandText = Query;
            Con.Con_switch();
            var reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                c = reader[ParameterName].ToString();
            }
            reader.Close();
            reader.Dispose();
            Con.Con_switch();
            return c;
        }

        /// <summary>
        /// The ExecuteMySqlCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteMySqlCommand(this MySqlCommand Cmd)
        {
            MySql_Con_switch(Cmd.Connection);
            var r = Cmd.ExecuteNonQuery();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_MySql_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_MySql_DataTable(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(dt);
            MySql_Con_switch(Con);
            return dt;
        }

        /// <summary>
        /// The FL_MySql_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_MySql_DataTable(this MySqlCommand Cmd)
        {
            var dt = new DataTable();
            MySql_Con_switch(Cmd.Connection);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(dt);
            MySql_Con_switch(Cmd.Connection);
            return dt;
        }

        /// <summary>
        /// The FL_MySql_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_MySql_DataSet(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(ds);
            MySql_Con_switch(Con);
            return ds;
        }

        /// <summary>
        /// The FL_MySql_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_MySql_DataSet(this MySqlCommand Cmd)
        {
            var ds = new DataSet();
            MySql_Con_switch(Cmd.Connection);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(ds);
            MySql_Con_switch(Cmd.Connection);
            return ds;
        }

        /// <summary>
        /// The FL_MySql_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_MySql_RepeterData(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var r = new Repeater { DataSource = FL_MySql_DataSet(Cmd, Query, Con) };
            r.DataBind();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_MySql_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_MySql_RepeterData(this MySqlCommand Cmd)
        {
            var r = new Repeater { DataSource = FL_MySql_DataSet(Cmd) };
            r.DataBind();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_MySql_Execute_Command
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The sqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int FL_MySql_Execute_Command(string Constring, string SqlCommand)
        {
            var Connection = new MySqlConnection(Constring);
            var Cmd = new MySqlCommand(SqlCommand, Connection);
            Connection.Open();
            var r = Cmd.ExecuteNonQuery();
            Connection.Close();
            Cmd.Dispose();
            Connection.Dispose();
            return r;
        }

        /// <summary>
        /// The FL_MySql_DataAdapter
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The sqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="MySqlDataAdapter"/></returns>
        public static MySqlDataAdapter FL_MySql_DataAdapter(string Constring, string SqlCommand)
        {
            //DataSet ds = new DataSet();

            var Connection = new MySqlConnection(Constring);
            var Cmd = new MySqlCommand(SqlCommand, Connection);
            Connection.Open();
            var da = new MySqlDataAdapter(Cmd);
            //DataTable dt = new DataTable();
            //DA.Fill(dt);
            //ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            //ds.Tables.Add(dt);
            Connection.Close();
            //Cmd.Dispose();
            //Connection.Dispose();
            return da;
        }

        /// <summary>
        /// The FL_MySql_Check_Column_Exists
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Database_Name">The Database_Name<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="ColumnName">The ColumnName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool FL_MySql_Check_Column_Exists(this MySqlCommand Cmd, MySqlConnection Con,
            string Database_Name, string TableName, string ColumnName)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                              Database_Name + "' AND TABLE_NAME='" + TableName + "' and COLUMN_NAME = '" +
                              ColumnName + "') as exist;";
            MySql_Con_switch(Con);
            var reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            MySql_Con_switch(Con);
            return !v.Equals("0") && !v.Equals("");
        }

        /// <summary>
        /// The FL_MySqlGet_ColumnCount
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="DatabaseName">The DatabaseName<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="AntiColumnParameter">The AntiColumnParameter<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int FL_MySqlGet_ColumnCount(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, string AntiColumnParameter = null)
        {
            var count = 0;
            string command;
            if (string.IsNullOrEmpty(AntiColumnParameter))
            {
                command = "SELECT COUNT(COLUMN_NAME) as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "';";
            }
            else
            {
                command = "SELECT COUNT(COLUMN_NAME) as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' AND COLUMN_NAME NOT IN (SELECT '" + AntiColumnParameter + "');";
            }

            cmd.CommandText = command;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = int.Parse(reader["c"].ToString());
            }
            reader.Close();
            con.Con_switch();
            return count;
        }

        /// <summary>
        /// The FL_MySqlGet_ColumnCount
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="QueryWithCountParameter">The QueryWithCountParameter<see cref="string"/></param>
        /// <param name="CountParameterName">The CountParameterName<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int FL_MySqlGet_ColumnCount(this MySqlCommand cmd, MySqlConnection con,
            string QueryWithCountParameter, string CountParameterName)
        {
            var count = 0;
            cmd.CommandText = QueryWithCountParameter;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = int.Parse(reader[CountParameterName].ToString());
            }
            reader.Close();
            con.Con_switch();
            return count;
        }

        /// <summary>
        /// The FL_MySqlGet_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="QueryWithCountParameter">The QueryWithCountParameter<see cref="string"/></param>
        /// <param name="CountParameterName">The CountParameterName<see cref="string"/></param>
        /// <param name="QueryWithColumnParameter">The QueryWithColumnParameter<see cref="string"/></param>
        /// <param name="ColumnParameterName">The ColumnParameterName<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_MySqlGet_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string QueryWithCountParameter, string CountParameterName, string QueryWithColumnParameter,
            string ColumnParameterName)
        {
            var ColumnNames = new string[cmd.FL_MySqlGet_ColumnCount(con, QueryWithCountParameter, CountParameterName)];
            cmd.CommandText = QueryWithColumnParameter;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ColumnNames[i] = reader[ColumnParameterName].ToString()/*.Replace(" ", "")*/;
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ColumnNames;
        }

        /// <summary>
        /// The FL_MySqlGet_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="QueryWithColumnParameter">The QueryWithColumnParameter<see cref="string"/></param>
        /// <param name="ColumnParameterName">The ColumnParameterName<see cref="string"/></param>
        /// <param name="ColumnCount">The ColumnCount<see cref="int"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_MySqlGet_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string QueryWithColumnParameter, string ColumnParameterName, int ColumnCount)
        {
            var ColumnNames = new string[ColumnCount];
            cmd.CommandText = QueryWithColumnParameter;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ColumnNames[i] = reader[ColumnParameterName].ToString()/*.Replace(" ", "")*/;
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ColumnNames;
        }

        /// <summary>
        /// The FL_MySqlGet_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="DatabaseName">The DatabaseName<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="ColumnCount">The ColumnCount<see cref="int"/></param>
        /// <param name="AntiColumnParameter">The AntiColumnParameter<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_MySqlGet_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, int ColumnCount, string AntiColumnParameter = null)
        {
            var ColumnNames = new string[ColumnCount];
            string command;
            if (string.IsNullOrEmpty(AntiColumnParameter))
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' ORDER BY ORDINAL_POSITION;";
            }
            else
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' AND COLUMN_NAME NOT IN (SELECT '" + AntiColumnParameter + "') ORDER BY ORDINAL_POSITION;";
            }
            cmd.CommandText = command;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ColumnNames[i] = reader["c"].ToString()/*.Replace(" ", "")*/;
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ColumnNames;
        }

        /// <summary>
        /// The FL_MySqlGet_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="DatabaseName">The DatabaseName<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="AntiColumnParameter">The AntiColumnParameter<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_MySqlGet_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, string AntiColumnParameter = null)
        {
            var ColumnNames = new string[cmd.FL_MySqlGet_ColumnCount(con, DatabaseName, TableName, AntiColumnParameter)];
            string command;
            if (string.IsNullOrEmpty(AntiColumnParameter))
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' ORDER BY ORDINAL_POSITION;";
            }
            else
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' AND COLUMN_NAME NOT IN (SELECT '" + AntiColumnParameter + "') ORDER BY ORDINAL_POSITION;";
            }
            cmd.CommandText = command;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ColumnNames[i] = reader["c"].ToString()/*.Replace(" ", "")*/;
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ColumnNames;
        }

        public static string[] FL_MySqlGet_ControlIds(this MySqlCommand cmd, MySqlConnection con,
            string QueryWithColumnParameter, string ColumnParameterName, int ColumnCount)
        {
            var ControlIds = new string[ColumnCount];
            cmd.CommandText = QueryWithColumnParameter;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ControlIds[i] = reader[ColumnParameterName].ToString().Replace(" ", "");
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ControlIds;
        }

        public static string[] FL_MySqlGet_ControlIds(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, int ColumnCount, string AntiColumnParameter = null)
        {
            var ControlIds = new string[ColumnCount];
            string command;
            if (string.IsNullOrEmpty(AntiColumnParameter))
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' ORDER BY ORDINAL_POSITION;";
            }
            else
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' AND COLUMN_NAME NOT IN (SELECT '" + AntiColumnParameter + "') ORDER BY ORDINAL_POSITION;";
            }
            cmd.CommandText = command;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ControlIds[i] = reader["c"].ToString().Replace(" ", "");
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ControlIds;
        }

        public static string[] FL_MySqlGet_ControlIds(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, string AntiColumnParameter = null)
        {
            var ControlIds = new string[cmd.FL_MySqlGet_ColumnCount(con, DatabaseName, TableName, AntiColumnParameter)];
            string command;
            if (string.IsNullOrEmpty(AntiColumnParameter))
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' ORDER BY ORDINAL_POSITION;";
            }
            else
            {
                command = "SELECT COLUMN_NAME as c FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" +
                          DatabaseName + "' AND TABLE_NAME='" + TableName + "' AND COLUMN_NAME NOT IN (SELECT '" + AntiColumnParameter + "') ORDER BY ORDINAL_POSITION;";
            }
            cmd.CommandText = command;
            var i = 0;
            cmd.Connection = con;
            con.Con_switch();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ControlIds[i] = reader["c"].ToString().Replace(" ", "");
                i++;
            }
            reader.Close();
            reader.Dispose();
            con.Con_switch();
            return ControlIds;
        }

        /// <summary>
        /// The FL_MySql_SelectionElementBuilder
        /// </summary>
        /// <param name="count">The count<see cref="int"/></param>
        /// <param name="ColumnNames">The ColumnNames<see cref="IReadOnlyList{string}"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string FL_MySql_ColumnElementBuilder(int count, IReadOnlyList<string> ColumnNames)
        {
            const string b = "`";
            const string a = "`,`";
            var q = "";
            for (var i = 0; i <= (count - 1); i++)
            {
                if (i == 0)
                {
                    if (count == 1)
                    {
                        q = q + b + ColumnNames[i] + b;
                    }
                    else
                    {
                        q = q + b + ColumnNames[i] + a;
                    }
                }
                else if (i > 0 && count > (i + 1))
                {
                    q = q + ColumnNames[i] + a;
                }
                else if (i > 0 && count == (i + 1))
                {
                    q = q + ColumnNames[i] + b;
                }
                else
                {
                    break;
                }
            }
            return q;
        }

       public static string FL_MySql_ColumnValueElementBuilder(Control ParentControl, int Count, IReadOnlyList<string> ChildControlIds)
        {
            //int Count, IReadOnlyList<string> Ids, Control ParentControl
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
                        if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ITextControl)
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + c + ctrl.Text + c;
                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ICheckBoxControl)
                        {
                            var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.Checked;
                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is DropDownList)
                        {
                            var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + c + ctrl.SelectedValue + c;
                        }
                    }
                    else
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ITextControl)
                        {
                            if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                                q = q + c + ctrl.Text + f;
                            }
                            else
                            {
                                var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                                q = q + c + ctrl.Text + a;
                            }

                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ICheckBoxControl)
                        {
                            if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                                q = q + ctrl.Checked + e;
                            }
                            else
                            {
                                var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                                q = q + ctrl.Checked + d;
                            }
                        }
                        else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is DropDownList)
                        {
                            if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b + 1]) is ICheckBoxControl)
                            {
                                var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                                q = q + c + ctrl.SelectedValue + f;
                            }
                            else
                            {
                                var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                                q = q + c + ctrl.Text + a;
                            }
                        }
                    }
                }
                else if (b > 0 && Count > (b + 1))
                {
                    if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ITextControl)
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.Text + f;
                        }
                        else
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.Text + a;
                        }
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ICheckBoxControl)
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.Checked + e;
                        }
                        else
                        {
                            var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.Checked + d;
                        }
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is DropDownList)
                    {
                        if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b + 1]) is ICheckBoxControl)
                        {
                            var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.SelectedValue + f;
                        }
                        else
                        {
                            var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                            q = q + ctrl.Text + a;
                        }
                    }
                }
                else if (b > 0 && Count == (b + 1))
                {
                    if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ITextControl)
                    {
                        var ctrl = (ITextControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                        q = q + ctrl.Text + c;
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is ICheckBoxControl)
                    {
                        var ctrl = (ICheckBoxControl)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                        q = q + ctrl.Checked;
                    }
                    else if (_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]) is DropDownList)
                    {
                        var ctrl = (DropDownList)_Controls.FL_GetChildControl(ParentControl, ChildControlIds[b]);
                        q = q + ctrl.SelectedValue + c;
                    }
                }
                else
                {
                    break;
                }
            }
            return q;
            /*const string b = "'";
            const string a = "','";
            var q = "";
            for (var i = 0; i <= (count - 1); i++)
            {
                string v;
                if (i == 0)
                {
                    if (count == 1)
                    {
                        v = _controls.FL_GetControlString(ParentControl, ChildControlIds[i]).Trim();
                        q = q + b + v + b;
                    }
                    else
                    {
                        v = _controls.FL_GetControlString(ParentControl, ChildControlIds[i]).Trim();
                        q = q + b + v + a;
                    }
                }
                else if (i > 0 && count > (i + 1))
                {
                    v = _controls.FL_GetControlString(ParentControl, ChildControlIds[i]).Trim();
                    q = q + v + a;
                }
                else if (i > 0 && count == (i + 1))
                {
                    v = _controls.FL_GetControlString(ParentControl, ChildControlIds[i]).Trim();
                    q = q + v + b;
                }
                else
                {
                    break;
                }
            }
            return q;*/
       }

       public static string FL_MySql_InsertQueryBuilder(int count, IReadOnlyList<string> ColumnNames,
            Control ParentControl, IReadOnlyList<string> ChildControlIds,string DataBaseName,
            string TableName)
       {
            return "INSERT INTO `" + DataBaseName + "`.`" + TableName + "` (" +
                   FL_MySql_ColumnElementBuilder(count, ColumnNames) + ") VALUES(" +
                   FL_MySql_ColumnValueElementBuilder(ParentControl, count, ChildControlIds) + ");";
       }

       public static string FL_MySql_UpdateQueryBuilder(Control ParentControl, int count, IReadOnlyList<string> controlids,
           IReadOnlyList<string> ColumnNames, string DataBaseName, string TableName, string WhereParameter)
        {
            var q = "";
            const string a = ", `";
            const string b = "`=";
            const string c = "`";

            for (var j = 0; j <= (count - 1); j++)
            {
                string v;
                if (j == 0)
                {
                    if (count == 1)
                    {
                        v = _Controls.FL_GetControlString(ParentControl, controlids[j]).Trim();
                        q = c + ColumnNames[j] + b + v;
                    }
                    else
                    {
                        v = _Controls.FL_GetControlString(ParentControl, controlids[j]).Trim();
                        q = c + ColumnNames[j] + b + v + a;
                    }
                }
                else if (j > 0 && count > (j + 1))
                {
                    v = _Controls.FL_GetControlString(ParentControl, controlids[j]).Trim();
                    q = q + ColumnNames[j] + b + v + a;
                }
                else if (j > 0 && count == (j + 1))
                {
                    v = _Controls.FL_GetControlString(ParentControl, controlids[j]).Trim();
                    q = "UPDATE `"+DataBaseName+"`.`"+TableName+"` SET " + q + ColumnNames[j] + b + v + " WHERE " + WhereParameter + "; ";
                }
            }
            return q;
        }
    }
}
