﻿using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_MySql
{
    /// <summary>
    /// Defines the <see cref="FL_MySqlExecutor" />
    /// </summary>
    public static class FL_MySqlExecutor
    {
        /// <summary>
        /// The MySql_Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void MySql_Con_switch_on(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                var Con1 = new MySqlConnection
                {
                    ConnectionString = Con.ConnectionString
                };
                Con.Dispose();
                Con = Con1;
                Con.Open();
            }
            else
            {
                Con.Close();
                Con.Open();
            }
        }

        /// <summary>
        /// The MySql_Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void MySql_Con_switch_off(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        /// <summary>
        /// The MySql_Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        public static void MySql_Con_switch(this MySqlConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                MySql_Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                MySql_Con_switch_on(Con);
            }
        }

        /// <summary>
        /// The ExecuteStoredProcedure
        /// </summary>
        public static void ExecuteStoredProcedure()
        {
        }

        /// <summary>
        /// The ExecuteMySqlCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteMySqlCommand(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            var r = Cmd.ExecuteNonQuery();
            MySql_Con_switch(Con);
            return r;
        }

        /// <summary>
        /// The GetMySqlValue
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetMySqlValue(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var c = "";
            Cmd.CommandText = Query;
            Con.Con_switch();
            var reader = Cmd.ExecuteReader();
            while (reader.Read())
            {
                c = reader["salhead_formula"].ToString();
            }
            reader.Close();
            reader.Dispose();
            Con.Con_switch();
            return c;
        }

        /// <summary>
        /// The ExecuteMySqlCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteMySqlCommand(this MySqlCommand Cmd)
        {
            MySql_Con_switch(Cmd.Connection);
            var r = Cmd.ExecuteNonQuery();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_MySql_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_MySql_DataTable(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(dt);
            MySql_Con_switch(Con);
            return dt;
        }

        /// <summary>
        /// The FL_MySql_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_MySql_DataTable(this MySqlCommand Cmd)
        {
            var dt = new DataTable();
            MySql_Con_switch(Cmd.Connection);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(dt);
            MySql_Con_switch(Cmd.Connection);
            return dt;
        }

        /// <summary>
        /// The FL_MySql_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_MySql_DataSet(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            MySql_Con_switch(Con);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(ds);
            MySql_Con_switch(Con);
            return ds;
        }

        /// <summary>
        /// The FL_MySql_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_MySql_DataSet(this MySqlCommand Cmd)
        {
            var ds = new DataSet();
            MySql_Con_switch(Cmd.Connection);
            var adp = new MySqlDataAdapter(Cmd);
            adp.Fill(ds);
            MySql_Con_switch(Cmd.Connection);
            return ds;
        }

        /// <summary>
        /// The FL_MySql_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_MySql_RepeterData(this MySqlCommand Cmd, string Query, MySqlConnection Con)
        {
            var r = new Repeater { DataSource = FL_MySql_DataSet(Cmd, Query, Con) };
            r.DataBind();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_MySql_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_MySql_RepeterData(this MySqlCommand Cmd)
        {
            var r = new Repeater { DataSource = FL_MySql_DataSet(Cmd) };
            r.DataBind();
            MySql_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_MySql_Check_Column_Exists
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="MySqlCommand"/></param>
        /// <param name="Con">The Con<see cref="MySqlConnection"/></param>
        /// <param name="Database_Name">The Database_Name<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="ColumnName">The ColumnName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool FL_MySql_Check_Column_Exists(this MySqlCommand Cmd, MySqlConnection Con, string Database_Name, string TableName, string ColumnName)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + Database_Name + "' AND TABLE_NAME='" +
                              TableName + "' and COLUMN_NAME = '" + ColumnName + "') as exist;";
            MySql_Con_switch(Con);
            var reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            MySql_Con_switch(Con);
            return !v.Equals("0") && !v.Equals("");
        }

        /// <summary>
        /// The FL_mysql_execute_command
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The sqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int FL_mysql_execute_command(string Constring, string SqlCommand)
        {
            var Connection = new MySqlConnection(Constring);
            var Cmd = new MySqlCommand(SqlCommand, Connection);
            Connection.Open();
            var r = Cmd.ExecuteNonQuery();
            Connection.Close();
            Cmd.Dispose();
            Connection.Dispose();
            return r;
        }

        /// <summary>
        /// The FL_mysql_dataadapter
        /// </summary>
        /// <param name="Constring">The Constring<see cref="string"/></param>
        /// <param name="SqlCommand">The sqlCommand<see cref="string"/></param>
        /// <returns>The <see cref="MySqlDataAdapter"/></returns>
        public static MySqlDataAdapter FL_mysql_dataadapter(string Constring, string SqlCommand)
        {
            //DataSet ds = new DataSet();

            var Connection = new MySqlConnection(Constring);
            var Cmd = new MySqlCommand(SqlCommand, Connection);
            Connection.Open();
            var da = new MySqlDataAdapter(Cmd);
            //DataTable dt = new DataTable();
            //DA.Fill(dt);
            //ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            //ds.Tables.Add(dt);
            Connection.Close();
            //Cmd.Dispose();
            //Connection.Dispose();
            return da;
        }
    }
}
