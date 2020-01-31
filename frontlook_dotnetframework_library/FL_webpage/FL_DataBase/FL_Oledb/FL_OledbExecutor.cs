namespace frontlook_dotnetframework_library.FL_webpage.FL_DataBase.FL_Oledb
{
    using System.Data;
    using System.Data.OleDb;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Defines the <see cref="FL_OledbExecutor" />
    /// </summary>
    public static class FL_OledbExecutor
    {
        /// <summary>
        /// The OleDb_Con_switch_on
        /// </summary>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        public static void OleDb_Con_switch_on(this OleDbConnection Con)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            else if (Con.State == ConnectionState.Broken)
            {
                var Con1 = new OleDbConnection
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
        /// The OleDb_Con_switch_off
        /// </summary>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        public static void OleDb_Con_switch_off(this OleDbConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        /// <summary>
        /// The OleDb_Con_switch
        /// </summary>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        public static void OleDb_Con_switch(this OleDbConnection Con)
        {
            if (Con.State == ConnectionState.Open)
            {
                OleDb_Con_switch_off(Con);
            }
            else if (Con.State == ConnectionState.Closed)
            {
                OleDb_Con_switch_on(Con);
            }
        }

        /// <summary>
        /// The ExecuteStoredProcedure
        /// </summary>
        public static void ExecuteStoredProcedure()
        {
        }

        /// <summary>
        /// The ExecuteOleDbCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteOleDbCommand(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            OleDb_Con_switch(Con);
            var r = Cmd.ExecuteNonQuery();
            OleDb_Con_switch(Con);
            return r;
        }

        /// <summary>
        /// The ExecuteOleDbCommand
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int ExecuteOleDbCommand(this OleDbCommand Cmd)
        {
            OleDb_Con_switch(Cmd.Connection);
            var r = Cmd.ExecuteNonQuery();
            OleDb_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_OleDb_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_OleDb_DataTable(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            var dt = new DataTable();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            OleDb_Con_switch(Con);
            var adp = new OleDbDataAdapter(Cmd);
            adp.Fill(dt);
            OleDb_Con_switch(Con);
            return dt;
        }

        /// <summary>
        /// The FL_OleDb_DataTable
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_OleDb_DataTable(this OleDbCommand Cmd)
        {
            var dt = new DataTable();
            OleDb_Con_switch(Cmd.Connection);
            var adp = new OleDbDataAdapter(Cmd);
            adp.Fill(dt);
            OleDb_Con_switch(Cmd.Connection);
            return dt;
        }

        /// <summary>
        /// The FL_OleDb_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_OleDb_DataSet(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            var ds = new DataSet();
            Cmd.Connection = Con;
            Cmd.CommandText = Query;
            OleDb_Con_switch(Con);
            var adp = new OleDbDataAdapter(Cmd);
            adp.Fill(ds);
            OleDb_Con_switch(Con);
            return ds;
        }

        /// <summary>
        /// The FL_OleDb_DataSet
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_OleDb_DataSet(this OleDbCommand Cmd)
        {
            var ds = new DataSet();
            OleDb_Con_switch(Cmd.Connection);
            var adp = new OleDbDataAdapter(Cmd);
            adp.Fill(ds);
            OleDb_Con_switch(Cmd.Connection);
            return ds;
        }

        /// <summary>
        /// The FL_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_RepeterData(this OleDbCommand Cmd, string Query, OleDbConnection Con)
        {
            var r = new Repeater {DataSource = FL_OleDb_DataSet(Cmd, Query, Con)};
            r.DataBind();
            OleDb_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_RepeterData
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <returns>The <see cref="Repeater"/></returns>
        public static Repeater FL_RepeterData(this OleDbCommand Cmd)
        {
            var r = new Repeater {DataSource = FL_OleDb_DataSet(Cmd)};
            r.DataBind();
            OleDb_Con_switch(Cmd.Connection);
            return r;
        }

        /// <summary>
        /// The FL_Check_Column_Exists
        /// </summary>
        /// <param name="Cmd">The Cmd<see cref="OleDbCommand"/></param>
        /// <param name="Con">The Con<see cref="OleDbConnection"/></param>
        /// <param name="Database_Name">The Database_Name<see cref="string"/></param>
        /// <param name="TableName">The TableName<see cref="string"/></param>
        /// <param name="Columnname">The Columnname<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool FL_Check_Column_Exists(OleDbCommand Cmd, OleDbConnection Con, string Database_Name, string TableName, string Columnname)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = "SELECT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + Database_Name + "' AND TABLE_NAME='" +
                              TableName + "' and COLUMN_NAME = '" + Columnname + "') as exist;";
            OleDb_Con_switch(Con);
            var reader = Cmd.ExecuteReader();
            var v = "";
            while (reader.Read())
            {
                v = reader["exist"].ToString();
            }
            reader.Dispose();
            reader.Close();
            OleDb_Con_switch(Con);
            return !v.Equals("0") && !v.Equals("");
        }
    }
}
