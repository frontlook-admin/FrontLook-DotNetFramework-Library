using System.Data;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Oledb
{
    public static class FL_OledbExecutor
    {
        public static void OleDb_Con_switch_on(OleDbConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                OleDbConnection Con1 = new OleDbConnection
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

        public static void OleDb_Con_switch_off(OleDbConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public static void OleDb_Con_switch(OleDbConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                OleDb_Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                OleDb_Con_switch_on(Con);
            }
        }

        public static void ExecuteStoredProcedure()
        {

        }

        public static int ExecuteOleDbCommand(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            OleDb_Con_switch(Con);
            int r = Cmd.ExecuteNonQuery();
            OleDb_Con_switch(Con);
            return r;
        }

        public static int ExecuteOleDbCommand(this OleDbCommand Cmd)
        {
            OleDb_Con_switch(Cmd.Connection);
            int r = Cmd.ExecuteNonQuery();
            OleDb_Con_switch(Cmd.Connection);
            return r;
        }

        public static DataTable FL_DataTable(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            DataTable dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            OleDb_Con_switch(Con);
            OleDbDataAdapter adp = new OleDbDataAdapter(Cmd);
            adp.Fill(dt);
            OleDb_Con_switch(Con);
            return dt;
        }

        public static DataTable FL_DataTable(this OleDbCommand Cmd)
        {
            DataTable dt = new DataTable();
            OleDb_Con_switch(Cmd.Connection);
            OleDbDataAdapter adp = new OleDbDataAdapter(Cmd);
            adp.Fill(dt);
            OleDb_Con_switch(Cmd.Connection);
            return dt;
        }

        public static DataSet FL_DataSet(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            DataSet ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            OleDb_Con_switch(Con);
            OleDbDataAdapter adp = new OleDbDataAdapter(Cmd);
            adp.Fill(ds);
            OleDb_Con_switch(Con);
            return ds;
        }

        public static DataSet FL_DataSet(this OleDbCommand Cmd)
        {
            DataSet ds = new DataSet();
            OleDb_Con_switch(Cmd.Connection);
            OleDbDataAdapter adp = new OleDbDataAdapter(Cmd);
            adp.Fill(ds);
            OleDb_Con_switch(Cmd.Connection);
            return ds;
        }

        public static Repeater FL_RepeterData(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_DataSet(Cmd, Query, Con);
            r.DataBind();
            OleDb_Con_switch(Cmd.Connection);
            return r;
        }

        public static Repeater FL_RepeterData(this OleDbCommand Cmd)
        {
            Repeater r = new Repeater();
            r.DataSource = FL_DataSet(Cmd);
            r.DataBind();
            OleDb_Con_switch(Cmd.Connection);
            return r;
        }

        public static bool FL_Check_Column_Exists(OleDbConnection Con, OleDbCommand Cmd, string Database_Name, string tableName, string columnname)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + Database_Name + "' AND TABLE_NAME='" +
                              tableName + "' and COLUMN_NAME = '" + columnname + "') as exist;";
            OleDb_Con_switch(Con);
            OleDbDataReader reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            OleDb_Con_switch(Con);
            if (v.Equals("0") || v.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DataTable FL_get_oledb_datatable(string Constring, string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                OleDbConnection Connection = new OleDbConnection(Constring);
                OleDbCommand Cmd = new OleDbCommand(Query, Connection);
                Connection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(Cmd);
                da.Fill(dt);
                Connection.Close();
                Cmd.Dispose();
                Connection.Dispose();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        [SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public static DataSet FL_get_oledb_dataset(string Constring, string Query)
        {
            DataSet ds = new DataSet("data_set");
            try
            {
                OleDbConnection Connection = new OleDbConnection(Constring);
                OleDbCommand Cmd = new OleDbCommand(Query, Connection);
                Connection.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ds.Locale = Thread.CurrentThread.CurrentCulture;
                ds.Tables.Add(dt);
                Connection.Close();
                Cmd.Dispose();
                Connection.Dispose();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ds;
        }

        public static int FL_oledb_execute_command(string Constring, string sqlCommand)
        {
            int r = 0;
            try
            {
                OleDbConnection Connection = new OleDbConnection(Constring);
                OleDbCommand Cmd = new OleDbCommand(sqlCommand, Connection);
                Connection.Open();

                r = Cmd.ExecuteNonQuery();
                //DA.Update(dt);
                Connection.Close();
                //BackgroundWorker bgw = new BackgroundWorker();

                Cmd.Dispose();
                Connection.Dispose();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return r;
        }

        public static DataSet FL_get_only_oledbdataset(string Constring, string Query)
        {
            DataSet ds = FL_get_oledb_dataset(Constring, Query);
            return ds;
        }
    }
}