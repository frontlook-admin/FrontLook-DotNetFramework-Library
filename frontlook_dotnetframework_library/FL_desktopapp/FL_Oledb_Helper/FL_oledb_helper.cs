using System.Data;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Windows;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Oledb_Helper
{
    public static class FL_Oledb_Helper
    {
        public static DataTable FL_get_oledb_datatable(string Constring, string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                var connection = new OleDbConnection(Constring);
                var cmd = new OleDbCommand(Query, connection);
                connection.Con_switch();
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                connection.Con_switch();
                cmd.Dispose();
                connection.Dispose();
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
                var connection = new OleDbConnection(Constring);
                var cmd = new OleDbCommand(Query, connection);
                connection.Con_switch();
                var da = new OleDbDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                ds.Locale = Thread.CurrentThread.CurrentCulture;
                ds.Tables.Add(dt);
                connection.Con_switch();
                cmd.Dispose();
                connection.Dispose();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return ds;
        }

        public static int FL_oledb_execute_command(string Constring, string SqlCommand)
        {
            var r = 0;
            try
            {
                var connection = new OleDbConnection(Constring);
                var cmd = new OleDbCommand(SqlCommand, connection);
                r = cmd.ExecuteCommand();
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