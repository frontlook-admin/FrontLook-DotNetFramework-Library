using frontlook_dotnetframework_library.FL_desktopapp.FL_General;
using frontlook_dotnetframework_library.FL_webpage.FL_DataBase;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Dbf_Helper
{
    /// <summary>
    /// Defines the <see cref="FL_Dbf_Manager" />
    /// </summary>
    [Guid("3A1A8463-73F7-47FE-BCAD-9DDCB9103B07")]
    public static class FL_Dbf_Manager
    {
        /// <summary>
        /// The Get_all_datatable_in_dataset
        /// </summary>
        /// <param name="Filepaths">The Filepaths<see cref="IEnumerable{string}"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet Get_all_datatable_in_dataset(this IEnumerable<string> Filepaths)
        {
            var ds = new DataSet("data_collection") { Locale = Thread.CurrentThread.CurrentCulture };
            foreach (var s in Filepaths)
            {
                var dt = FL_DbfData_To_Excel.FL_get_only_datatable_for_dbf(s);
                ds.Tables.Add(dt);
            }
            return ds;
        }

        /// <summary>
        /// The FL_dbf_datatable
        /// </summary>
        /// <param name="DbfFilepath">The DbfFilepath<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_dbf_datatable(this string DbfFilepath)
        {
            //FileInfo fileInfo = new FileInfo(dbfFilepath);
            //string dbfDirectoryFilepath = fileInfo.DirectoryName;
            //string x = Path.GetDirectoryName(dbfFilepath);
            string dbfConstring1 = FL_dbf_constring(DbfFilepath);
            //Get version information about the os.
            //data_helper1.constring(dbf_filepath);

            //Variable to hold our return value

            //string excelFilename = "";
            //string xml = ""; 
            //string xml_schema = ""; 
            //string sWithoutExt;
            //string s = "";


            var s = DbfFilepath;
            //excelFilename = "";
            //sWithoutExt = "";
            //var excelFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s + ".xlsx";
            var sWithoutExt = Path.GetFileNameWithoutExtension(s);
            var dt = new DataTable();
            try
            {

                var connection = new OleDbConnection(dbfConstring1);
                var sql = "SELECT * FROM " + sWithoutExt;

                var cmd = new OleDbCommand(sql, connection);
                connection.Con_switch();
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                //DA.Update(dt);
                connection.Con_switch();
                //BackgroundWorker bgw = new BackgroundWorker();


            }
            catch (OleDbException e)
            {
                MessageBox.Show("Error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        /// <summary>
        /// The FL_dbf_datatable
        /// </summary>
        /// <param name="DbfFilepath">The DbfFilepath<see cref="string"/></param>
        /// <param name="Sql">The Sql<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_dbf_datatable(this string DbfFilepath, string Sql)
        {
            //FileInfo fileInfo = new FileInfo(dbfFilepath);
            //string dbfDirectoryFilepath = fileInfo.DirectoryName;
            //string x = Path.GetDirectoryName(dbfFilepath);
            var dbfConstring1 = FL_dbf_constring(DbfFilepath);
            //Get version information about the os.
            //data_helper1.constring(dbf_filepath);

            //Variable to hold our return value

            //string excelFilename = "";
            //string xml = ""; 
            //string xml_schema = ""; 
            //string s_without_ext = "";
            //string s = "";


            //var s = dbfFilepath;
            /*excelFilename = "";
            s_without_ext = "";
            excelFilename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + s + ".xlsx";
            s_without_ext = Path.GetFileNameWithoutExtension(s);*/
            var dt = new DataTable();
            try
            {
                var connection = new OleDbConnection(dbfConstring1);
                var cmd = new OleDbCommand(Sql, connection);
                connection.Con_switch();
                var da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                //DA.Update(dt);
                connection.Con_switch();
                //BackgroundWorker bgw = new BackgroundWorker();
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
        /// The FL_dbf_constring
        /// </summary>
        /// <param name="DbfFilepath">The DbfFilepath<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string FL_dbf_constring(this string DbfFilepath)
        {
            var operatingSystem = FL_Os_Helper.FL_get_os();
            string dbfConstring1;
            var fileInfo = new FileInfo(DbfFilepath);
            var dbfDirectoryFilepath = fileInfo.DirectoryName;
            //string x = Path.GetDirectoryName(dbfFilepath);
            //string dbf_filename = "";

            //data_helper.get_os(operatingSystem);
            if (operatingSystem != "")
            {
                operatingSystem = "Windows " + operatingSystem;
            }

            switch (operatingSystem)
            {
                case "Windows XP":
                    dbfConstring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 7":
                    dbfConstring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows Vista":
                    dbfConstring1 = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 8":
                    dbfConstring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 8.1":
                    dbfConstring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                case "Windows 10":
                    dbfConstring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
                default:
                    dbfConstring1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + dbfDirectoryFilepath + ";Extended Properties=dBase IV;User ID=;Password=";
                    break;
            }
            return dbfConstring1;
        }
    }
}
