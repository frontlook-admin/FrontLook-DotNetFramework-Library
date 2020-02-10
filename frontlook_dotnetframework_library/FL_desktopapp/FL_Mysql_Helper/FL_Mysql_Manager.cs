//using System.Data;

using frontlook_dotnetframework_library.FL_webpage.FL_DataBase;
using MySql.Data.MySqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Mysql_Helper
{
    /// <summary>
    /// Defines the <see cref="FL_Mysql_Manager" />
    /// </summary>
    public static class FL_Mysql_Manager
    {
        /// <summary>
        /// The FL_MySql_Execute_Command
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The SqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        [SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public static int FL_mysql_execute_command(string Constring, string SqlCommand)
        {
            var r = 0;
            try
            {
                var Connection = new MySqlConnection(Constring);
                var Cmd = new MySqlCommand(SqlCommand, Connection);
                r = Cmd.ExecuteCommand();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return r;
        }

        /// <summary>
        /// The FL_MySql_DataAdapter
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The SqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="MySqlDataAdapter"/></returns>
        public static MySqlDataAdapter FL_mysql_dataadapter(string Constring, string SqlCommand)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            //DataSet ds = new DataSet();
            try
            {
                var Connection = new MySqlConnection(Constring);
                var Cmd = new MySqlCommand(SqlCommand, Connection);
                Connection.Con_switch();
                da = new MySqlDataAdapter(Cmd);
                //DataTable dt = new DataTable();
                //DA.Fill(dt);
                //ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                //ds.Tables.Add(dt);
                Connection.Con_switch();
                //Cmd.Dispose();
                //Connection.Dispose();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return da;
        }

        /// <summary>
        /// The FL_mysql_myreader
        /// </summary>
        /// <param name="Connection">The Connection<see cref="MySqlConnection"/></param>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="MySqlDataReader"/></returns>
        public static MySqlDataReader FL_mysql_myreader(MySqlConnection Connection, MySqlCommand Cmd)
        {
            MySqlDataReader r = null;
            try
            {
                Connection.Con_switch();
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
