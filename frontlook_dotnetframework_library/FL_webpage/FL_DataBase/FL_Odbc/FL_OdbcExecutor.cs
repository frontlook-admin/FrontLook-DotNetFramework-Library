using System.Data;
using System.Data.Odbc;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Odbc
{
    public static class FL_OdbcExecutor
    {
        public static void Odbc_Con_switch_on(OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                OdbcConnection Con1 = new OdbcConnection
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

        public static void Odbc_Con_switch_off(OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public static void Odbc_Con_switch(OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Odbc_Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                Odbc_Con_switch_on(Con);
            }
        }

        public static void ExecuteStoredProcedure()
        {

        }

        public static int ExecuteOdbcCommand(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Odbc_Con_switch(Con);
            int r = Cmd.ExecuteNonQuery();
            Odbc_Con_switch(Con);
            return r;
        }

        public static int ExecuteOdbcCommand(this OdbcCommand Cmd)
        {
            Odbc_Con_switch(Cmd.Connection);
            int r = Cmd.ExecuteNonQuery();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        public static DataTable FL_DataTable(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            DataTable dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Odbc_Con_switch(Con);
            OdbcDataAdapter adp = new OdbcDataAdapter(Cmd);
            adp.Fill(dt);
            Odbc_Con_switch(Con);
            return dt;
        }

        public static DataTable FL_DataTable(this OdbcCommand Cmd)
        {
            DataTable dt = new DataTable();
            Odbc_Con_switch(Cmd.Connection);
            OdbcDataAdapter adp = new OdbcDataAdapter(Cmd);
            adp.Fill(dt);
            Odbc_Con_switch(Cmd.Connection);
            return dt;
        }

        public static DataSet FL_DataSet(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            DataSet ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Odbc_Con_switch(Con);
            OdbcDataAdapter adp = new OdbcDataAdapter(Cmd);
            adp.Fill(ds);
            Odbc_Con_switch(Con);
            return ds;
        }

        public static DataSet FL_DataSet(this OdbcCommand Cmd)
        {
            DataSet ds = new DataSet();
            Odbc_Con_switch(Cmd.Connection);
            OdbcDataAdapter adp = new OdbcDataAdapter(Cmd);
            adp.Fill(ds);
            Odbc_Con_switch(Cmd.Connection);
            return ds;
        }

        public static Repeater FL_RepeterData(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_DataSet(Cmd, Query, Con);
            r.DataBind();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        public static Repeater FL_RepeterData(this OdbcCommand Cmd)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_DataSet(Cmd);
            r.DataBind();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        public static bool FL_Check_Column_Exists(OdbcConnection Con, OdbcCommand Cmd, string database_name, string tableName, string columnname)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + database_name + "' AND TABLE_NAME='" +
                              tableName + "' and COLUMN_NAME = '" + columnname + "') as exist;";
            Odbc_Con_switch(Con);
            OdbcDataReader reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            Odbc_Con_switch(Con);
            if (v.Equals("0") || v.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DataTable FL_get_odbc_datatable(string Constring, string Query)
        {
            DataTable dt = new DataTable();
            OdbcConnection Connection = new OdbcConnection(Constring);
            OdbcCommand Cmd = new OdbcCommand(Query, Connection);
            Connection.Open();
            OdbcDataAdapter da = new OdbcDataAdapter(Cmd);
            da.Fill(dt);
            //DA.Update(dt);
            Connection.Close();
            Cmd.Dispose();
            Connection.Dispose();
            return dt;
        }

        [SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public static int FL_odbc_execute_command(string Constring, string sqlCommand)
        {
            int r = 0;
            OdbcConnection Connection = new OdbcConnection(Constring);
            OdbcCommand Cmd = new OdbcCommand(sqlCommand, Connection);
            Connection.Open();

            r = Cmd.ExecuteNonQuery();
            //DA.Update(dt);
            Connection.Close();
            //BackgroundWorker bgw = new BackgroundWorker();

            Cmd.Dispose();
            Connection.Dispose();
            return r;
        }
    }
}