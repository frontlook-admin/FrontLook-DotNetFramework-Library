using System.Data.Odbc;
using System.Data.OleDb;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Odbc;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Oledb;
using MySql.Data.MySqlClient;

namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase
{
    public static class FL_SqlExecutor
    {
        public static void Con_switch_on(this OleDbConnection Con)
        {
            FL_OledbExecutor.OleDb_Con_switch_on(Con);
        }

        public static void Con_switch_on(this OdbcConnection Con)
        {
            FL_OdbcExecutor.Odbc_Con_switch_on(Con);
        }

        public static void Con_switch_on(this MySqlConnection Con)
        {
            FL_MySqlExecutor.MySql_Con_switch_on(Con);
        }

        public static void Con_switch_off(this OleDbConnection Con)
        {
            FL_OledbExecutor.OleDb_Con_switch_off(Con);
        }

        public static void Con_switch_off(this OdbcConnection Con)
        {
            FL_OdbcExecutor.Odbc_Con_switch_off(Con);
        }

        public static void Con_switch_off(this MySqlConnection Con)
        {
            FL_MySqlExecutor.MySql_Con_switch_off(Con);
        }

        public static void Con_switch(this OleDbConnection Con)
        {
            FL_OledbExecutor.OleDb_Con_switch(Con);
        }

        public static void Con_switch(this OdbcConnection Con)
        {
            FL_OdbcExecutor.Odbc_Con_switch(Con);
        }

        public static void Con_switch(this MySqlConnection Con)
        {
            FL_MySqlExecutor.MySql_Con_switch(Con);
        }

        public static int ExecuteCommand(this OleDbCommand Cmd, string Query, OleDbConnection Con )
        {
            return Cmd.ExecuteOleDbCommand(Query, Con);
        }

        public static int ExecuteCommand(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            return Cmd.ExecuteOdbcCommand(Query, Con);
        }

        public static int ExecuteCommand(MySqlConnection Con, MySqlCommand Cmd, string Query)
        {
            return Cmd.ExecuteMySqlCommand(Query, Con);
        }

        public static int ExecuteCommand(this OleDbCommand Cmd)
        {
            return Cmd.ExecuteOleDbCommand();
        }

        public static int ExecuteCommand(this OdbcCommand Cmd)
        {
            return Cmd.ExecuteOdbcCommand();
        }

        public static int ExecuteCommand(this MySqlCommand Cmd)
        {
            return Cmd.ExecuteMySqlCommand();
        }
    }
}