using System;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql
{
    public static class FL_MySqlExecutor
    {
        public static void MySql_Con_switch_on(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                MySqlConnection Con1 = new MySqlConnection
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

        public static void MySql_Con_switch_off(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

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

        public static void ExecuteStoredProcedure()
        {

        }

        public static int ExecuteMySqlCommand(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            int r = Cmd.ExecuteNonQuery();
            MySql_Con_switch(Con);
            return r;
        }

        public static int ExecuteMySqlCommand(this MySqlCommand Cmd)
        {
            MySql_Con_switch(Cmd.Connection);
            int r = Cmd.ExecuteNonQuery();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        public static DataTable FL_MySql_MySqlDataTable(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            DataTable dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            MySqlDataAdapter adp = new MySqlDataAdapter(Cmd);
            adp.Fill(dt);
            MySql_Con_switch(Con);
            return dt;
        }

        public static DataTable FL_MySql_DataTable(this MySqlCommand Cmd)
        {
            DataTable dt = new DataTable();
            MySql_Con_switch(Cmd.Connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(Cmd);
            adp.Fill(dt);
            MySql_Con_switch(Cmd.Connection);
            return dt;
        }

        public static DataSet FL_MySql_DataSet(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            DataSet ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            MySqlDataAdapter adp = new MySqlDataAdapter(Cmd);
            adp.Fill(ds);
            MySql_Con_switch(Con);
            return ds;
        }

        public static DataSet FL_MySql_DataSet(this MySqlCommand Cmd)
        {
            DataSet ds = new DataSet();
            MySql_Con_switch(Cmd.Connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(Cmd);
            adp.Fill(ds);
            MySql_Con_switch(Cmd.Connection);
            return ds;
        }

        public static Repeater FL_MySql_RepeterData(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_MySql_DataSet(Cmd, Query, Con);
            r.DataBind();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        public static Repeater FL_MySql_RepeterData(this MySqlCommand Cmd)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_MySql_DataSet(Cmd);
            r.DataBind();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        public static bool FL_MySql_Check_Column_Exists(MySqlCommand Cmd, MySqlConnection Con, string Database_Name, string TableName, string Columnname)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + Database_Name + "' AND TABLE_NAME='" +
                              TableName + "' and COLUMN_NAME = '" + Columnname + "') as exist;";
            MySql_Con_switch(Con);
            MySqlDataReader reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            MySql_Con_switch(Con);
            if (v.Equals("0") || v.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /*Copied*/
        public static int FL_mysql_execute_command(string Constring, string sqlCommand)
        {
            MySqlConnection Connection = new MySqlConnection(Constring);
            MySqlCommand Cmd = new MySqlCommand(sqlCommand, Connection);
            Connection.Open();
            var r = Cmd.ExecuteNonQuery();
            Connection.Close();
            Cmd.Dispose();
            Connection.Dispose();
            return r;
        }

        public static MySqlDataAdapter FL_mysql_dataadapter(string Constring, string sqlCommand)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            //DataSet ds = new DataSet();

            MySqlConnection Connection = new MySqlConnection(Constring);
            MySqlCommand Cmd = new MySqlCommand(sqlCommand, Connection);
            Connection.Open();
            da = new MySqlDataAdapter(Cmd);
            //DataTable dt = new DataTable();
            //DA.Fill(dt);
            //ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            //ds.Tables.Add(dt);
            Connection.Close();
            //Cmd.Dispose();
            //Connection.Dispose();
            return da;
        }

        /*public static MySqlDataReader FL_mysql_myreader(MySqlConnection Connection, MySqlCommand Cmd)
        {
            MySqlDataReader r = null;
            Connection.Open();
            return Cmd.ExecuteReader();
        }*/

        /*Copied*/

        /*public static bool CheckObjectExists(MySqlConnection Con, MySqlCommand Cmd,string database_name,string tableName, string columnname)
        {
            bool isObjectExist = false;
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='"+database_name+"' AND TABLE_NAME='"+tableName+"' and COLUMN_NAME = '"+tableName+"') as exist;";
            using (Con)
            {
                using (Cmd)
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@TableName", tableName);
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        Cmd.Parameters.AddWithValue("@ColumnName", columnname);
                    }
                    Con.Open();
                    object IsExists = Cmd.ExecuteScalar();
                    if (IsExists != null && IsExists != DBNull.Value)
                    {
                        isObjectExist = Convert.ToBoolean(IsExists);
                    }
                    Con.Close();
                }
            }
            return isObjectExist;
        }*/
    }
}