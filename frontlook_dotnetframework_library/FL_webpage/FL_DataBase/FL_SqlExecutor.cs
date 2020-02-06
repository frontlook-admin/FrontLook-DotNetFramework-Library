namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase
{
    using FL_MySql;
    using FL_Odbc;
    using FL_Oledb;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Data.Odbc;
    using System.Data.OleDb;

    /// <summary>
    /// Defines the <see cref="FL_SqlExecutor" />
    /// </summary>
    public static class FL_SqlExecutor
    {
        /// <summary>
        /// The Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        public static void Con_switch(this OleDbConnection Con)
        {
            Con.OleDb_Con_switch();
        }

        /// <summary>
        /// The Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        public static void Con_switch(this OdbcConnection Con)
        {
            Con.Odbc_Con_switch();
        }

        /// <summary>
        /// The Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void Con_switch(this MySqlConnection Con)
        {
            Con.MySql_Con_switch();
        }

        /// <summary>
        /// The Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        public static void Con_switch_off(this OleDbConnection Con)
        {
            Con.OleDb_Con_switch_off();
        }

        /// <summary>
        /// The Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        public static void Con_switch_off(this OdbcConnection Con)
        {
            Con.Odbc_Con_switch_off();
        }

        /// <summary>
        /// The Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void Con_switch_off(this MySqlConnection Con)
        {
            Con.MySql_Con_switch_off();
        }

        /// <summary>
        /// The Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        public static void Con_switch_on(this OleDbConnection Con)
        {
            Con.OleDb_Con_switch_on();
        }

        /// <summary>
        /// The Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        public static void Con_switch_on(this OdbcConnection Con)
        {
            Con.Odbc_Con_switch_on();
        }

        /// <summary>
        /// The Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void Con_switch_on(this MySqlConnection Con)
        {
            Con.MySql_Con_switch_on();
        }

        /// <summary>
        /// The ExecuteCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            return Cmd.ExecuteOleDbCommand(Query, Con);
        }

        /// <summary>
        /// The ExecuteCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            return Cmd.ExecuteOdbcCommand(Query, Con);
        }

        /// <summary>
        /// The ExecuteCommand
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(MySqlConnection Con, MySqlCommand Cmd, string Query)
        {
            return Cmd.ExecuteMySqlCommand(Query, Con);
        }

        /// <summary>
        /// The ExecuteCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(this OleDbCommand Cmd)
        {
            return Cmd.ExecuteOleDbCommand();
        }

        /// <summary>
        /// The ExecuteCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(this OdbcCommand Cmd)
        {
            return Cmd.ExecuteOdbcCommand();
        }

        /// <summary>
        /// The ExecuteCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(this MySqlCommand Cmd)
        {
            return Cmd.ExecuteMySqlCommand();
        }

        /// <summary>
        /// The FL_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            return Cmd.FL_OleDb_DataTable(Query, Con);
        }

        /// <summary>
        /// The FL_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            return Cmd.FL_Odbc_DataTable(Query, Con);
        }

        /// <summary>
        /// The FL_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            return Cmd.FL_MySql_DataTable(Query, Con);
        }

        /// <summary>
        /// The FL_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this OleDbCommand Cmd)
        {
            return Cmd.FL_OleDb_DataTable();
        }

        /// <summary>
        /// The FL_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this OdbcCommand Cmd)
        {
            return Cmd.FL_Odbc_DataTable();
        }

        /// <summary>
        /// The FL_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this MySqlCommand Cmd)
        {
            return Cmd.FL_MySql_DataTable();
        }

        public static bool FL_Check_Column_Exists(this MySqlCommand Cmd, MySqlConnection Con, string Database_Name,
            string TableName, string ColumnName)
        {
            return Cmd.FL_MySql_Check_Column_Exists(Con,Database_Name,TableName,ColumnName);
        }
    }
}
