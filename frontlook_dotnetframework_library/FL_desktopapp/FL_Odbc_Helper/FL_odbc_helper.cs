using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Odbc_Helper
{
    public class FL_Odbc_Manager
    {
        public static DataTable FL_get_odbc_datatable(string Constring, string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                OdbcConnection Connection = new OdbcConnection(Constring);
                OdbcCommand Cmd = new OdbcCommand(Query, Connection);
                Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(Cmd);
                da.Fill(dt);
                //DA.Update(dt);
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
        public static int FL_odbc_execute_command(string Constring, string sqlCommand)
        {
            int r = 0;
            try
            {
                OdbcConnection Connection = new OdbcConnection(Constring);
                OdbcCommand Cmd = new OdbcCommand(sqlCommand, Connection);
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
    }
}