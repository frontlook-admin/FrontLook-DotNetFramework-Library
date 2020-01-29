using System.Data;
using System.Data.Odbc;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Odbc
{
    public static class FL_OdbcExecutor
    {
        public static void Odbc_Con_switch_on(this OdbcConnection Con)
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

        public static void Odbc_Con_switch_off(this OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public static void Odbc_Con_switch(this OdbcConnection Con)
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

        public static DataTable FL_OdbcDataTable(this OdbcCommand Cmd, string Query, OdbcConnection Con)
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

        public static DataTable FL_OdbcDataTable(this OdbcCommand Cmd)
        {
            DataTable dt = new DataTable();
            Odbc_Con_switch(Cmd.Connection);
            OdbcDataAdapter adp = new OdbcDataAdapter(Cmd);
            adp.Fill(dt);
            Odbc_Con_switch(Cmd.Connection);
            return dt;
        }

        public static DataSet FL_OdbcDataSet(this OdbcCommand Cmd, string Query, OdbcConnection Con)
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

        public static DataSet FL_OdbcDataSet(this OdbcCommand Cmd)
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
            r.DataSource = FL_OdbcDataSet(Cmd, Query, Con);
            r.DataBind();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        public static Repeater FL_RepeterData(this OdbcCommand Cmd)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_OdbcDataSet(Cmd);
            r.DataBind();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        public static bool FL_OdbcCheck_Column_Exists(OdbcCommand Cmd, OdbcConnection Con, string Database_Name, string TableName, string Columnname)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + Database_Name + "' AND TABLE_NAME='" +
                              TableName + "' and COLUMN_NAME = '" + Columnname + "') as exist;";
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
    }
}