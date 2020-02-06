namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Odbc
{
    using System.Data;
    using System.Data.Odbc;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Defines the <see cref="FL_OdbcExecutor" />
    /// </summary>
    public static class FL_OdbcExecutor
    {
        /// <summary>
        /// The Odbc_Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        public static void Odbc_Con_switch_on(this OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                var Con1 = new OdbcConnection
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
        /// The Odbc_Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        public static void Odbc_Con_switch_off(this OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        /// <summary>
        /// The Odbc_Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        public static void Odbc_Con_switch(this OdbcConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Odbc_Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                Odbc_Con_switch_on(Con);
            }
        }

        /// <summary>
        /// The ExecuteStoredProcedure
        /// </summary>
        public static void ExecuteStoredProcedure()
        {
        }

        /// <summary>
        /// The ExecuteOdbcCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteOdbcCommand(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Odbc_Con_switch(Con);
            var r = Cmd.ExecuteNonQuery();
            Odbc_Con_switch(Con);
            return r;
        }

        /// <summary>
        /// The ExecuteOdbcCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteOdbcCommand(this OdbcCommand Cmd)
        {
            Odbc_Con_switch(Cmd.Connection);
            var r = Cmd.ExecuteNonQuery();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_Odbc_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_Odbc_DataTable(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            var dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Odbc_Con_switch(Con);
            var adp = new OdbcDataAdapter(Cmd);
            adp.Fill(dt);
            Odbc_Con_switch(Con);
            return dt;
        }

        /// <summary>
        /// The FL_Odbc_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_Odbc_DataTable(this OdbcCommand Cmd)
        {
            var dt = new DataTable();
            Odbc_Con_switch(Cmd.Connection);
            var adp = new OdbcDataAdapter(Cmd);
            adp.Fill(dt);
            Odbc_Con_switch(Cmd.Connection);
            return dt;
        }

        /// <summary>
        /// The FL_Odbc_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_Odbc_DataSet(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            var ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            Odbc_Con_switch(Con);
            var adp = new OdbcDataAdapter(Cmd);
            adp.Fill(ds);
            Odbc_Con_switch(Con);
            return ds;
        }

        /// <summary>
        /// The FL_Odbc_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_Odbc_DataSet(this OdbcCommand Cmd)
        {
            var ds = new DataSet();
            Odbc_Con_switch(Cmd.Connection);
            var adp = new OdbcDataAdapter(Cmd);
            adp.Fill(ds);
            Odbc_Con_switch(Cmd.Connection);
            return ds;
        }

        /// <summary>
        /// The FL_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_RepeterData(this OdbcCommand Cmd, string Query, OdbcConnection Con)
        {
            var r = new Repeater { DataSource = FL_Odbc_DataSet(Cmd, Query, Con) };
            r.DataBind();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_RepeterData(this OdbcCommand Cmd)
        {
            var r = new Repeater { DataSource = FL_Odbc_DataSet(Cmd) };
            r.DataBind();
            Odbc_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_OdbcCheck_Column_Exists
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OdbcCommand"/></param>
        /// <param name="Con">The Con<see cref="OdbcConnection"/></param>
        /// <param name="Database_Name">The Database_Name<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="Columnname">The Columnname<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool FL_OdbcCheck_Column_Exists(OdbcCommand Cmd, OdbcConnection Con, string Database_Name, string TableName, string Columnname)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + Database_Name + "' AND TABLE_NAME='" +
                              TableName + "' and COLUMN_NAME = '" + Columnname + "') as exist;";
            Odbc_Con_switch(Con);
            var reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            Odbc_Con_switch(Con);
            return !v.Equals("0") && !v.Equals("");
        }
    }
}
