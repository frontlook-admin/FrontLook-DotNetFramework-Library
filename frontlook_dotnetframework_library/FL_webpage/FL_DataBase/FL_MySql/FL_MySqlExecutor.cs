using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql
{
    public static class FL_MySqlExecutor
    {
        public static void Con_switch_on(MySqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else if (con.State == ConnectionState.Broken)
            {
                MySqlConnection con1 = new MySqlConnection();
                con1.ConnectionString = con.ConnectionString;
                con.Dispose();
                con = con1;
                con.Open();
            }
            else
            {
                con.Close();
                con.Open();
            }
        }

        public static void Con_switch_off(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public static void Con_switch(MySqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                Con_switch_off(con);
            }
            else if (con.State == ConnectionState.Closed)
            {
                Con_switch_on(con);
            }
        }

        public static void ExecuteStoredProcedure()
        {

        }

        public static int ExecuteMySqlCommand(MySqlConnection con, MySqlCommand cmd, string query)
        {
            cmd.Connection = con;
            cmd.CommandText = query;
            Con_switch(con);
            int r = cmd.ExecuteNonQuery();
            Con_switch(con);
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