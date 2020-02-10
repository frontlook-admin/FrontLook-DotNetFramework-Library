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
        public static int ExecuteCommand(this MySqlCommand Cmd, MySqlConnection Con, string Query)
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
        /// The GetValue
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="ParameterName"></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetValue(this MySqlCommand Cmd, string Query, MySqlConnection Con, string ParameterName)
        {
            return Cmd.GetMySqlValue(Query, Con, ParameterName);
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

        /// <summary>
        /// The FL_Check_Column_Exists
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Database_Name">The Database_Name<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="ColumnName">The ColumnName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool FL_Check_Column_Exists(this MySqlCommand Cmd, MySqlConnection Con, string Database_Name,
            string TableName, string ColumnName)
        {
            return Cmd.FL_MySql_Check_Column_Exists(Con, Database_Name, TableName, ColumnName);
        }

        /// <summary>
        /// The FL_Get_ColumnCount
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="DatabaseName">The DatabaseName<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="AntiColumnParameter">The AntiColumnParameter<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int FL_Get_ColumnCount(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, string AntiColumnParameter = null)
        {
            return cmd.FL_MySqlGet_ColumnCount(con, DatabaseName, TableName, AntiColumnParameter);
        }

        /// <summary>
        /// The FL_Get_ColumnCount
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="QueryWithCountParameter">The QueryWithCountParameter<see cref="string"/></param>
        /// <param name="CountParameterName">The CountParameterName<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int FL_Get_ColumnCount(this MySqlCommand cmd, MySqlConnection con, string QueryWithCountParameter, string CountParameterName)
        {
            return cmd.FL_MySqlGet_ColumnCount(con, QueryWithCountParameter, CountParameterName);
        }

        /// <summary>
        /// The FL_Get_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="QueryWithCountParameter">The QueryWithCountParameter<see cref="string"/></param>
        /// <param name="CountParameterName">The CountParameterName<see cref="string"/></param>
        /// <param name="QueryWithColumnParameter">The QueryWithColumnParameter<see cref="string"/></param>
        /// <param name="ColumnParameterName">The ColumnParameterName<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_Get_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string QueryWithCountParameter, string CountParameterName, string QueryWithColumnParameter,
            string ColumnParameterName)
        {
            return cmd.FL_MySqlGet_ColumnNames(con, QueryWithCountParameter, CountParameterName,
                QueryWithColumnParameter, ColumnParameterName);
        }

        /// <summary>
        /// The FL_Get_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="QueryWithColumnParameter">The QueryWithColumnParameter<see cref="string"/></param>
        /// <param name="ColumnParameterName">The ColumnParameterName<see cref="string"/></param>
        /// <param name="ColumnCount">The ColumnCount<see cref="int"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_Get_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string QueryWithColumnParameter, string ColumnParameterName, int ColumnCount)
        {
            return cmd.FL_MySqlGet_ColumnNames(con, QueryWithColumnParameter, ColumnParameterName,
                ColumnCount);
        }

        /// <summary>
        /// The FL_Get_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="DatabaseName">The DatabaseName<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="AntiColumnParameter">The AntiColumnParameter<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_Get_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, string AntiColumnParameter = null)
        {
            return cmd.FL_MySqlGet_ColumnNames(con, DatabaseName, TableName, AntiColumnParameter);
        }

        /// <summary>
        /// The FL_Get_ColumnNames
        /// </summary>
        /// <param name="cmd">The cmd<see cref="MySqlCommand"/></param>
        /// <param name="con">The con<see cref="MySqlConnection"/></param>
        /// <param name="DatabaseName">The DatabaseName<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="ColumnCount">The ColumnCount<see cref="int"/></param>
        /// <param name="AntiColumnParameter">The AntiColumnParameter<see cref="string"/></param>
        /// <returns>The <see cref="string[]"/></returns>
        public static string[] FL_Get_ColumnNames(this MySqlCommand cmd, MySqlConnection con,
            string DatabaseName, string TableName, int ColumnCount = 0, string AntiColumnParameter = null)
        {
            if (ColumnCount != 0)
            {
                return cmd.FL_MySqlGet_ColumnNames(con, DatabaseName, TableName,
                    ColumnCount, AntiColumnParameter);
            }
            else
            {

                return cmd.FL_MySqlGet_ColumnNames(con, DatabaseName, TableName,
                    AntiColumnParameter);
            }
        }
    }
}
