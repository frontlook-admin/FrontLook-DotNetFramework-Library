﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace frontlook_dotnetframework_library.FL_desktopapp.FL_Excel_Data_Interop
{
    /// <summary>
    /// Defines the <see cref="FL_DataTableToExcel_Helper" />
    /// </summary>
    public static class FL_DataTableToExcel_Helper
    {
        /// <summary>
        /// The FL_DataTableToExcel
        /// </summary>
        /// <param name="DataTable">The DataTable<see cref="DataTable"/></param>
        /// <param name="ExcelFilePath">The ExcelFilePath<see cref="string"/></param>
        public static void FL_DataTableToExcel(DataTable DataTable, string ExcelFilePath)
        {
            try
            {
                var unused = (DataTable.Columns.Count + 1) * (DataTable.Rows.Count + 1);

                int columnsCount;

                var v = (columnsCount = DataTable.Columns.Count);
                if (v == 0)
                {
                    //MessageBox.Show("FL_Excel_Data_Interop.FL_DataTableToExcel_Helper.FL_DataTableToExcel: Null or empty input table!", "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show("Null or empty input table!", "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // load excel, and create a new workbook
                var excel = new Application();
                excel.Workbooks.Add();
                //Excel.Visible = true;
                // single worksheet
                _Worksheet worksheet = excel.ActiveSheet;

                var header = new object[columnsCount];
                //var stopwatch = new Stopwatch();
                //stopwatch.Reset();
                //stopwatch.Start();
                // column headings               
                for (var i = 0; i < columnsCount; i++)
                    header[i] = DataTable.Columns[i].ColumnName;

                var headerRange = worksheet.Range[(Range)(worksheet.Cells[1, 1]), (Range)(worksheet.Cells[1, columnsCount])];
                headerRange.Value = header;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                //HeaderRange.Interior.Color = SystemColors.GrayTextBrush;
                headerRange.Font.Bold = true;

                // DataCells
                var rowsCount = DataTable.Rows.Count;
                var cells = new object[rowsCount, columnsCount];

                for (var j = 0; j < rowsCount; j++)
                {
                    for (var i = 0; i < columnsCount; i++)
                    {
                        cells[j, i] = DataTable.Rows[j][i];

                    }
                    //rel_cells = 0;
                    //rel_cells = ColumnsCount * j;
                    //var time = stopwatch.ElapsedMilliseConds;
                    //var speed = (rel_cells / time);
                    //Console.WriteLine("Speed:" + speed + "cells/sec");
                }
                worksheet.Range[(Range)(worksheet.Cells[2, 1]), (Range)(worksheet.Cells[rowsCount + 1, columnsCount])].Value2 = cells;
                //stopwatch.Stop();
                //var final_speed = (total_cells / stopwatch.ElapsedMilliseConds);
                //Console.WriteLine("Completed At Speed:" + final_speed + "cells/sec");
                if (string.IsNullOrEmpty(ExcelFilePath) || File.Exists(ExcelFilePath))
                {

                    excel.Visible = true;
                }
                else
                { // no file path is given
                    try
                    {
                        worksheet.SaveAs(ExcelFilePath);
                        excel.Quit();
                        //MessageBox.Show("Excel file saved as "+ExcelFilePath,"DataTable Saved In Excel File",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                        + ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                Marshal.FinalReleaseComObject(worksheet);
                Marshal.FinalReleaseComObject(headerRange);
                Marshal.FinalReleaseComObject(excel);

                //System.Windows.MessageBox.Show("Excel file saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// The DataTableToExcel_Excel_Visible
        /// </summary>
        /// <param name="DataTable">The DataTable<see cref="DataTable"/></param>
        /// <param name="ExcelFilePath">The ExcelFilePath<see cref="string"/></param>
        public static void DataTableToExcel_Excel_Visible(DataTable DataTable, string ExcelFilePath)
        {
            try
            {
                var unused = (DataTable.Columns.Count + 1) * (DataTable.Rows.Count + 1);

                int columnsCount;

                if ((columnsCount = DataTable.Columns.Count) == 0)
                {
                    //MessageBox.Show("FL_Excel_Data_Interop.FL_DataTableToExcel_Helper.FL_DataTableToExcel: Null or empty input table!", "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show("Null or empty input table!", "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // load excel, and create a new workbook
                Application excel = new Application();
                excel.Workbooks.Add();
                excel.Visible = true;
                // single worksheet
                _Worksheet worksheet = excel.ActiveSheet;

                object[] header = new object[columnsCount];
                //var stopwatch = new Stopwatch();
                //stopwatch.Reset();
                //stopwatch.Start();
                // column headings               
                for (int i = 0; i < columnsCount; i++)
                    header[i] = DataTable.Columns[i].ColumnName;

                Range headerRange = worksheet.get_Range((Range)(worksheet.Cells[1, 1]), (Range)(worksheet.Cells[1, columnsCount]));
                headerRange.Value = header;
                headerRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                //HeaderRange.Interior.Color = SystemColors.GrayTextBrush;
                headerRange.Font.Bold = true;

                // DataCells
                var rowsCount = DataTable.Rows.Count;
                var cells = new object[rowsCount, columnsCount];

                for (int j = 0; j < rowsCount; j++)
                {
                    for (int i = 0; i < columnsCount; i++)
                    {
                        cells[j, i] = DataTable.Rows[j][i];

                    }
                    //rel_cells = 0;
                    //rel_cells = ColumnsCount * j;
                    //var time = stopwatch.ElapsedMilliseConds;
                    //var speed = (rel_cells / time);
                    //Console.WriteLine("Speed:" + speed + "cells/sec");
                }
                worksheet.Range[(Range)(worksheet.Cells[2, 1]), (Range)(worksheet.Cells[rowsCount + 1, columnsCount])].Value2 = cells;
                //stopwatch.Stop();
                //var final_speed = (total_cells / stopwatch.ElapsedMilliseConds);
                //Console.WriteLine("Completed At Speed:" + final_speed + "cells/sec");
                if (string.IsNullOrEmpty(ExcelFilePath) || File.Exists(ExcelFilePath))
                {

                    excel.Visible = true;
                }
                else
                { // no file path is given
                    try
                    {
                        worksheet.SaveAs(ExcelFilePath);
                        excel.Quit();
                        //MessageBox.Show("Excel file saved as "+ExcelFilePath,"DataTable Saved In Excel File",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                        + ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                Marshal.FinalReleaseComObject(worksheet);
                Marshal.FinalReleaseComObject(headerRange);
                Marshal.FinalReleaseComObject(excel);

                //System.Windows.MessageBox.Show("Excel file saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error..!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// The AllocConsole
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();
    }
}
