using System.Data;
using frontlook_dotnetcore_library.FL_DataBase.FL_MySql;
using MySql.Data.MySqlClient;

namespace frontlook_dotnetcore_library.FL_DataBase
{
    /// <summary>
    /// Defines the <see cref="FL_SqlExecutor" />
    /// </summary>
    public static class FL_SqlExecutor
    {
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
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void Con_switch_off(this MySqlConnection Con)
        {
            Con.MySql_Con_switch_off();
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
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteCommand(this MySqlCommand Cmd)
        {
            return Cmd.ExecuteMySqlCommand();
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
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_DataTable(this MySqlCommand Cmd)
        {
            return Cmd.FL_MySql_DataTable();
        }
    }
}
