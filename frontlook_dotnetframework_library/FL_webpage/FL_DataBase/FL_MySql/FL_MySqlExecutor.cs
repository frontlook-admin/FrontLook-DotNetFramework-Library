using System;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql
{
    public static class FL_MySqlExecutor
    {
        public static void Con_switch_on(MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                MySqlConnection con1 = new MySqlConnection
                {
                    ConnectionString = Con.ConnectionString
                };
                Con.Dispose();
                Con = con1;
                Con.Open();
            }
            else
            {
                Con.Close();
                Con.Open();
            }
        }

        public static void Con_switch_off(MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public static void Con_switch(MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                Con_switch_on(Con);
            }
        }

        public static void ExecuteStoredProcedure()
        {

        }

        public static int ExecuteMySqlCommand(MySqlConnection Con, MySqlCommand Cmd, string Query)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Con_switch(Con);
            int r = Cmd.ExecuteNonQuery();
            Con_switch(Con);
            return r;
        }

        public static int ExecuteMySqlCommand(MySqlCommand cmd)
        {
            Con_switch(cmd.Connection);
            int r = cmd.ExecuteNonQuery();
            Con_switch(cmd.Connection);
            return r;
        }

        public static DataTable FL_DataTable(MySqlConnection con, MySqlCommand cmd, string query)
        {
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd.CommandText = query;
            Con_switch(con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            Con_switch(con);
            return dt;
        }

        public static DataTable FL_DataTable(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            Con_switch(cmd.Connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(dt);
            Con_switch(cmd.Connection);
            return dt;
        }

        public static DataSet FL_DataSet(MySqlConnection con, MySqlCommand cmd, string query)
        {
            DataSet ds = new DataSet();
            cmd.Connection = con;
            cmd.CommandText = query;
            Con_switch(con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            Con_switch(con);
            return ds;
        }

        public static DataSet FL_DataSet(MySqlCommand cmd)
        {
            DataSet ds = new DataSet();
            Con_switch(cmd.Connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            Con_switch(cmd.Connection);
            return ds;
        }

        public static Repeater FL_RepeterData(MySqlConnection con, MySqlCommand cmd, string query)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_DataSet(con, cmd, query);
            r.DataBind();
            Con_switch(cmd.Connection);
            return r;
        }

        public static Repeater FL_RepeterData(MySqlCommand cmd)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_DataSet(cmd);
            r.DataBind();
            Con_switch(cmd.Connection);
            return r;
        }

        public static bool FL_Check_Column_Exists(MySqlConnection con, MySqlCommand cmd, string database_name, string tableName, string columnname)
        {
            cmd.Connection = con;
            cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + database_name + "' AND TABLE_NAME='" +
                              tableName + "' and COLUMN_NAME = '" + columnname + "') as exist;";
            Con_switch(con);
            MySqlDataReader reader = cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            Con_switch(con);
            if (v.Equals("0") || v.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*public static bool CheckObjectExists(MySqlConnection con, MySqlCommand cmd,string database_name,string tableName, string columnname)
        {
            bool isObjectExist = false;
            cmd.Connection = con;
            cmd.CommandText = "SELECT EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='"+database_name+"' AND TABLE_NAME='"+tableName+"' and COLUMN_NAME = '"+tableName+"') as exist;";
            using (con)
            {
                using (cmd)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        cmd.Parameters.AddWithValue("@ColumnName", columnname);
                    }
                    con.Open();
                    object IsExists = cmd.ExecuteScalar();
                    if (IsExists != null && IsExists != DBNull.Value)
                    {
                        isObjectExist = Convert.ToBoolean(IsExists);
                    }
                    con.Close();
                }
            }
            return isObjectExist;
        }*/
    }
}