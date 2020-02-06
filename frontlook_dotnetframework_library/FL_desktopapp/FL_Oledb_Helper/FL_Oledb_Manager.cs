using frontlook_dotnetframework_library.FL_webpage.FL_DataBase;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Oledb_Helper
{
    /// <summary>
    /// Defines the <see cref="FL_Oledb_Manager" />
    /// </summary>
    public static class FL_Oledb_Manager
    {
        /// <summary>
        /// The FL_get_oledb_datatable
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
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

        /// <summary>
        /// The FL_get_oledb_dataset
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        [SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public static DataSet FL_get_oledb_dataset(string Constring, string Query)
        {
            var ds = new DataSet("data_set");
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

        /// <summary>
        /// The FL_oledb_execute_command
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The SqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
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

        /// <summary>
        /// The FL_get_only_oledbdataset
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_get_only_oledbdataset(string Constring, string Query)
        {
            DataSet ds = FL_get_oledb_dataset(Constring, Query);
            return ds;
        }
    }
}
