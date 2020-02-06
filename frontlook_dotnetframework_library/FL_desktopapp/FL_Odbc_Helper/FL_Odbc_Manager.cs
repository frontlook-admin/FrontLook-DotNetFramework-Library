using frontlook_dotnetframework_library.FL_webpage.FL_DataBase;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Odbc_Helper
{
    /// <summary>
    /// Defines the <see cref="FL_Odbc_Manager" />
    /// </summary>
    public static class FL_Odbc_Manager
    {
        /// <summary>
        /// The FL_get_odbc_datatable
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_get_odbc_datatable(string Constring, string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                var Connection = new OdbcConnection(Constring);
                var Cmd = new OdbcCommand(Query, Connection);
                Connection.Con_switch();
                var da = new OdbcDataAdapter(Cmd);
                da.Fill(dt);
                //DA.Update(dt);
                Connection.Con_switch();
                Cmd.Dispose();
                Connection.Dispose();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        /// <summary>
        /// The FL_odbc_execute_command
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The SqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        [SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public static int FL_odbc_execute_command(string Constring, string SqlCommand)
        {
            var r = 0;
            try
            {
                var Connection = new OdbcConnection(Constring);
                var Cmd = new OdbcCommand(SqlCommand, Connection);
                r = Cmd.ExecuteCommand();
            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return r;
        }
    }
}
