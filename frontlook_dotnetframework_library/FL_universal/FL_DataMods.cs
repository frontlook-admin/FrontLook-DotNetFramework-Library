using System;
using System.Data;
using System.Windows.Controls;

namespace frontlook_dotnetframework_library.FL_universal
{
    public static class FL_DataMods
    {
        public static DataTable FL_DataSetToDataTable(DataSet ds, string TableName)
        {
            return ds.Tables[TableName];
        }

        public static DataTable FL_DataSetToDataTable(DataSet ds, int TableNumber)
        {
            return ds.Tables[TableNumber];
        }

        public static DataSet FL_DataTableToDataSet(DataTable dt, String DataSetName)
        {
            DataSet ds = new DataSet(DataSetName);
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet FL_DataTableToDataSet(DataTable[] dt)
        {
            DataSet ds = new DataSet();
            foreach (var dt0 in dt)
            {
                ds.Tables.Add(dt[0]);
            }

            return ds;

        }

        public static DataSet FL_DataTableToDataSet(DataTable[] dt, String DataSetName)
        {
            DataSet ds = new DataSet(DataSetName);
            foreach (var dt0 in dt)
            {
                ds.Tables.Add(dt0);
            }
            return ds;
        }

        public static DataTable ChangeOrientation(DataTable dt)
        {
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dt.Columns[i].ColumnName;
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dt.Rows[j][i];
                }
            }
            return dt2;
        }
    }
}