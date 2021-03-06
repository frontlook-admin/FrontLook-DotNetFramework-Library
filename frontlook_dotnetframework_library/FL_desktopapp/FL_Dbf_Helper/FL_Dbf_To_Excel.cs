﻿using frontlook_dotnetframework_library.FL_desktopapp.FL_Excel_Data_Interop;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using _OledbHelper = frontlook_dotnetframework_library.FL_desktopapp.FL_Oledb_Helper.FL_Oledb_Manager;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Dbf_Helper
{
    /// <summary>
    /// Defines the <see cref="FL_DbfData_To_Excel" />
    /// </summary>
    public static class FL_DbfData_To_Excel
    {
        /// <summary>
        /// The FL_data_to_xls
        /// </summary>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        public static void FL_data_to_xls(this string DbfFilepathWithNameAndExtension)
        {
            var Constring = DbfFilepathWithNameAndExtension.FL_dbf_constring();
            var sWithoutExt = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);
            var Query = "SELECT * FROM " + sWithoutExt;
            var dt = _OledbHelper.FL_get_oledb_datatable(Constring, Query);
            FL_DataTableToExcel_Helper.FL_DataTableToExcel(dt, Path.GetDirectoryName(DbfFilepathWithNameAndExtension) + @"\" + Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension));
        }

        /// <summary>
        /// The FL_data_to_xls
        /// </summary>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Constring1">The Constring1<see cref="string"/></param>
        public static void FL_data_to_xls(string Query, string Constring1)
        {
            FL_data_to_xls(Query, Constring1, null);
        }

        /// <summary>
        /// The FL_data_to_xls
        /// </summary>
        /// <param name="Query">The Query<see cref="string"/></param>
        /// <param name="Constring1">The Constring1<see cref="string"/></param>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        public static void FL_data_to_xls(string Query, string Constring1 = null,
            string DbfFilepathWithNameAndExtension = null)
        {
            if (string.IsNullOrEmpty(DbfFilepathWithNameAndExtension))
            {
                var dt = _OledbHelper.FL_get_oledb_datatable(Constring1, Query);
                var filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + dt.TableName;
                FL_DataTableToExcel_Helper.FL_DataTableToExcel(dt, filename);
            }
            else
            {

                var Constring = DbfFilepathWithNameAndExtension.FL_dbf_constring();
                //var sWithoutExt = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);
                var dt = _OledbHelper.FL_get_oledb_datatable(Constring, Query);
                FL_DataTableToExcel_Helper.FL_DataTableToExcel(dt, Path.GetDirectoryName(DbfFilepathWithNameAndExtension) + @"\" + Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension));

            }
        }

        /*public static void FL_data_to_xls(string Query,string Constring)
        {
            DataTable dt = FL_database_helper.FL_oledb_helper.FL_get_oledb_datatable(Constring, Query);
            var filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + dt.TableName;
            FL_Excel_Data_Interop.FL_DataTableToExcel_Helper.FL_DataTableToExcel(dt, filename);
        }*/
        /// <summary>
        /// The FL_data_to_xls_multiple_datatable_in_single_excel_file
        /// </summary>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        public static void FL_data_to_xls_multiple_datatable_in_single_excel_file(this string DbfFilepathWithNameAndExtension)
        {
            var dirName = Path.GetDirectoryName(DbfFilepathWithNameAndExtension);
            //string[] filepath_null;
            // ReSharper disable once AssignNullToNotNullAttribute
            var filePaths = Directory.GetFiles(dirName, "*.dbf");
            DataToExcel_single_excel_file(filePaths);
        }

        /// <summary>
        /// The FL_data_to_xls_with_datatable
        /// </summary>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_data_to_xls_with_datatable(this string DbfFilepathWithNameAndExtension)
        {
            //var fileInfo = new FileInfo(DbfFilepathWithNameAndExtension);
            var Constring = DbfFilepathWithNameAndExtension.FL_dbf_constring();
            var sWithoutExt = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);
            var Query = "SELECT * FROM " + sWithoutExt;
            var dt = _OledbHelper.FL_get_oledb_datatable(Constring, Query);
            FL_DataTableToExcel_Helper.FL_DataTableToExcel(dt, Path.GetDirectoryName(DbfFilepathWithNameAndExtension) + @"\" + Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension));
            return dt;
        }

        /// <summary>
        /// The FL_get_only_datatable_for_dbf
        /// </summary>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_get_only_datatable_for_dbf(string DbfFilepathWithNameAndExtension)
        {
            //var fileInfo = new FileInfo(DbfFilepathWithNameAndExtension);
            var Constring = DbfFilepathWithNameAndExtension.FL_dbf_constring();
            var sWithoutExt = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);
            var Query = "SELECT * FROM " + sWithoutExt;
            var dt = _OledbHelper.FL_get_oledb_datatable(Constring, Query);
            return dt;
        }

        /// <summary>
        /// The FL_get_OnlyDatatableForDbf_variableQuery
        /// </summary>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        /// <param name="Query">The Query<see cref="String"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable FL_get_OnlyDatatableForDbf_variableQuery(string DbfFilepathWithNameAndExtension, String Query)
        {
            //var fileInfo = new FileInfo(DbfFilepathWithNameAndExtension);
            var Constring = DbfFilepathWithNameAndExtension.FL_dbf_constring();
            //var sWithoutExt = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);
            var dt = _OledbHelper.FL_get_oledb_datatable(Constring, Query);
            return dt;
        }

        /// <summary>
        /// The FL_get_only_dataset_for_dbf
        /// </summary>
        /// <param name="DbfFilepathWithNameAndExtension">The DbfFilepathWithNameAndExtension<see cref="string"/></param>
        /// <returns>The <see cref="DataSet"/></returns>
        public static DataSet FL_get_only_dataset_for_dbf(string DbfFilepathWithNameAndExtension)
        {
            //FileInfo fileInfo = new FileInfo(DbfFilepathWithNameAndExtension);
            var Constring = DbfFilepathWithNameAndExtension.FL_dbf_constring();
            var sWithoutExt = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);
            var Query = "SELECT * FROM " + sWithoutExt;
            var ds = _OledbHelper.FL_get_oledb_dataset(Constring, Query);
            return ds;
        }

        /// <summary>
        /// The DataToExcel_single_excel_file
        /// </summary>
        /// <param name="Filepaths">The Filepaths<see cref="string[]"/></param>
        public static void DataToExcel_single_excel_file(string[] Filepaths)
        {
            var dirName = Path.GetDirectoryName(Filepaths[0]);
            var excelApp = new Application();
            Range headerRange = null;
            var excelWorkBook = excelApp.Workbooks.Add();
            var noWorksheet = 0;
            foreach (var DbfFilepathWithNameAndExtension in Filepaths)
            {

                var dataTable = FL_get_only_datatable_for_dbf(DbfFilepathWithNameAndExtension);
                try
                {
                    headerRange = null;
                    var columnsCount = 0;

                    if (dataTable == null || (columnsCount = dataTable.Columns.Count) == 0)
                        MessageBox.Show("FL_Excel_Data_Interop.FL_DataTableToExcel_Helper.FL_DataTableToExcel: Null or empty input table!", "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);


                    excelApp.Visible = true;

                    Worksheet excelWorkSheet;
                    if (noWorksheet == 0)
                    {
                        excelWorkSheet = excelWorkBook.ActiveSheet;
                        noWorksheet = noWorksheet + 1;
                    }
                    else
                    {
                        excelWorkSheet = excelWorkBook.Worksheets.Add();
                    }


                    object[] header = new object[columnsCount];

                    for (int i = 0; i < columnsCount; i++)
                        header[i] = dataTable.Columns[i].ColumnName;

                    headerRange = excelWorkSheet.get_Range((Range)(excelWorkSheet.Cells[1, 1]), (Range)(excelWorkSheet.Cells[1, columnsCount]));
                    headerRange.Value = header;
                    headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

                    headerRange.Font.Bold = true;

                    // DataCells
                    var rowsCount = dataTable.Rows.Count;
                    var cells = new object[rowsCount, columnsCount];

                    for (int j = 0; j < rowsCount; j++)
                    {
                        for (int i = 0; i < columnsCount; i++)
                        {
                            cells[j, i] = dataTable.Rows[j][i];

                        }

                    }
                    excelWorkSheet.Range[(Range)(excelWorkSheet.Cells[2, 1]), (Range)(excelWorkSheet.Cells[rowsCount + 1, columnsCount])].Value2 = cells;


                    excelWorkSheet.Name = Path.GetFileNameWithoutExtension(DbfFilepathWithNameAndExtension);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //FileInfo fileinfo = new FileInfo(Filepaths[0]);


            //var ExcelFilePath1 = dir_name + @"\" + Path.GetFileNameWithoutExtension(filepaths[0]);
            var excelFilePath = dirName + @"\" + Path.GetFileNameWithoutExtension(dirName);
            //MessageBox.Show(ExcelFilePath1);
            if (string.IsNullOrEmpty(excelFilePath) || File.Exists(excelFilePath))
            {
                excelApp.Visible = true;
            }
            else
            {
                try
                {
                    excelWorkBook.SaveAs(excelFilePath);
                    excelWorkBook.Close();
                    excelApp.Quit();
                    //MessageBox.Show("Excel file saved as "+ExcelFilePath,"DataTable Saved In Excel File",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                        + ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //Marshal.FinalReleaseComObject(ExcelWorkSheet);
            Marshal.FinalReleaseComObject(headerRange);
            Marshal.FinalReleaseComObject(excelApp);
        }

        /// <summary>
        /// The DataSetToExcel_single_excel_file
        /// </summary>
        /// <param name="Ds">The Ds<see cref="DataSet"/></param>
        public static void DataSetToExcel_single_excel_file(DataSet Ds)
        {
            //string dir_name = Path.GetDirectoryName(filepaths[0]);
            var excelApp = new Application();
            Range headerRange = null;
            var excelWorkBook = excelApp.Workbooks.Add();
            var noWorksheet = 0;
            var name = Ds.DataSetName;
            for (var count = 0; count < Ds.Tables.Count; count++)
            {

                var dataTable = Ds.Tables[count];
                var xlssheetname = Ds.Tables[count].TableName;

                try
                {
                    headerRange = null;
                    var columnsCount = 0;

                    if (dataTable == null || (columnsCount = dataTable.Columns.Count) == 0)
                        MessageBox.Show("FL_Excel_Data_Interop.FL_DataTableToExcel_Helper.FL_DataTableToExcel: Null or empty input table!", "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);


                    excelApp.Visible = true;

                    Worksheet excelWorkSheet;
                    if (noWorksheet == 0)
                    {
                        excelWorkSheet = excelWorkBook.ActiveSheet;
                        noWorksheet = noWorksheet + 1;
                    }
                    else
                    {
                        excelWorkSheet = excelWorkBook.Worksheets.Add();
                    }


                    var header = new object[columnsCount];

                    for (var i = 0; i < columnsCount; i++)
                        // ReSharper disable once PossibleNullReferenceException
                        header[i] = dataTable.Columns[i].ColumnName;

                    headerRange = excelWorkSheet.Range[(Range)(excelWorkSheet.Cells[1, 1]), (Range)(excelWorkSheet.Cells[1, columnsCount])];
                    headerRange.Value = header;
                    headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

                    headerRange.Font.Bold = true;

                    // DataCells
                    // ReSharper disable once PossibleNullReferenceException
                    var rowsCount = dataTable.Rows.Count;
                    var cells = new object[rowsCount, columnsCount];

                    for (var j = 0; j < rowsCount; j++)
                    {
                        for (var i = 0; i < columnsCount; i++)
                        {
                            cells[j, i] = dataTable.Rows[j][i];

                        }

                    }
                    excelWorkSheet.get_Range((Range)(excelWorkSheet.Cells[2, 1]), (Range)(excelWorkSheet.Cells[rowsCount + 1, columnsCount])).Value2 = cells;


                    excelWorkSheet.Name = xlssheetname;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //FileInfo fileinfo = new FileInfo(filepaths[0]);


            //var ExcelFilePath1 = dir_name + @"\" + Path.GetFileNameWithoutExtension(filepaths[0]);
            var excelFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + name;
            //MessageBox.Show(ExcelFilePath1);
            if (string.IsNullOrEmpty(excelFilePath) || File.Exists(excelFilePath))
            {
                excelApp.Visible = true;
            }
            else
            {
                try
                {
                    excelWorkBook.SaveAs(excelFilePath);
                    excelWorkBook.Close();
                    excelApp.Quit();
                    //MessageBox.Show("Excel file saved as "+ExcelFilePath,"DataTable Saved In Excel File",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                        + ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //Marshal.FinalReleaseComObject(ExcelWorkSheet);
            // ReSharper disable once AssignNullToNotNullAttribute
            Marshal.FinalReleaseComObject(headerRange);
            Marshal.FinalReleaseComObject(excelApp);
        }
    }
}
