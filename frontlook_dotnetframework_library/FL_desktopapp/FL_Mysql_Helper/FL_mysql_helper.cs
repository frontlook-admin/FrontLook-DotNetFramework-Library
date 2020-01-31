//using System.Data;

using MySql.Data.MySqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Mysql_Helper
{
    public class FL_Mysql_Helper
    {
        [SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public static int FL_mysql_execute_command(string Constring, string SqlCommand)
        {
            var r = 0;
            try
            {
                var Connection = new MySqlConnection(Constring);
                var Cmd = new MySqlCommand(SqlCommand, Connection);
                Connection.Open();
                r = Cmd.ExecuteNonQuery();
                Connection.Close();
                Cmd.Dispose();
                Connection.Dispose();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return r;
        }

        public static MySqlDataAdapter FL_mysql_dataadapter(string Constring, string sqlCommand)
        {
            var da = new MySqlDataAdapter();
            //DataSet ds = new DataSet();
            try
            {
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
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return da;
        }

        public static MySqlDataReader FL_mysql_myreader(MySqlConnection Connection, MySqlCommand Cmd)
        {
            MySqlDataReader r = null;
            try
            {
                Connection.Open();
                r = Cmd.ExecuteReader();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return r;
        }
    }
}