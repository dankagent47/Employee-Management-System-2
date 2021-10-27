using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.IO;
using System.Linq;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    
        public class ReadCSV
        {
            public DataTable readCSV;

            public ReadCSV(string fileName, bool firstRowContainsFieldNames = true)
            {
                readCSV = GenerateDataTable(fileName, firstRowContainsFieldNames);
            }

            private static DataTable GenerateDataTable(string fileName, bool firstRowContainsFieldNames = true)
            {
                DataTable result = new DataTable();

                if (fileName == "")
                {
                    return result;
                }

                string delimiters = ",";
                string extension = Path.GetExtension(fileName);

                if (extension.ToLower() == "txt")
                    delimiters = "\t";
                else if (extension.ToLower() == "csv")
                    delimiters = ",";

                using (TextFieldParser tfp = new TextFieldParser(fileName))
                {
                    tfp.SetDelimiters(delimiters);

                    // Get The Column Names
                    if (!tfp.EndOfData)
                    {
                        string[] fields = tfp.ReadFields();

                        for (int i = 0; i < fields.Count(); i++)
                        {
                            if (firstRowContainsFieldNames)
                                result.Columns.Add(fields[i]);
                            else
                                result.Columns.Add("Col" + i);
                        }

                        // If first line is data then add it
                        if (!firstRowContainsFieldNames)
                            result.Rows.Add(fields);
                    }

                    // Get Remaining Rows from the CSV
                    while (!tfp.EndOfData)
                        result.Rows.Add(tfp.ReadFields());
                }

                return result;
            }

        private void LoadCSVOnDataGridView(string fileName, DataGridView dataGridView)
        {
            try
            {
                ReadCSV csv = new ReadCSV(fileName);

                try
                {
                    dataGridView.DataSource = csv.readCSV;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExportDatatableToCsv(string filename, DataTable dt)
        {
            // Open output stream
            StreamWriter swFile = new StreamWriter(filename);

            // Header
            string[] colLbls = new string[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colLbls[i] = dt.Columns[i].ColumnName;
                colLbls[i] = GetWriteableValueForCsv(colLbls[i]);
            }

            // Write labels
            swFile.WriteLine(string.Join(",", colLbls));

            // Rows of Data
            foreach (DataRow rowData in dt.Rows)
            {
                string[] colData = new string[dt.Columns.Count];

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    object obj = rowData[i];
                    colData[i] = GetWriteableValueForCsv(obj);
                }

                // Write data in row
                swFile.WriteLine(string.Join(",", colData));
            }

            // Close output stream
            swFile.Close();
        }

        public static string GetWriteableValueForCsv(object obj)
        {
            // Nullable types to blank
            if (obj == null || obj == Convert.DBNull)
            {
                return "";
            }

            // if string has no ','
            if (obj.ToString().IndexOf(",") == -1)
            {
                return obj.ToString();
            }

            // remove backslahes
            return "\"" + obj.ToString() + "\"";
        }

        public static void ExportDatatviewToCsv(string filename, DataView dv)
        {
            // Open output stream
            StreamWriter swFile = new StreamWriter(filename);

            // Header
            string[] colLbls = new string[dv.Table.Columns.Count];
            for (int i = 0; i < dv.Table.Columns.Count; i++)
            {
                colLbls[i] = dv.Table.Columns[i].ColumnName;
                colLbls[i] = GetWriteableValueForCsv(colLbls[i]);
            }

            // Write labels
            swFile.WriteLine(string.Join(",", colLbls));

            // Rows of Data
            foreach (DataRowView rowData in dv)
            {
                string[] colData = new string[dv.Table.Columns.Count];
                for (int i = 0; i < dv.Table.Columns.Count; i++)
                {
                    object obj = rowData[i];
                    colData[i] = GetWriteableValueForCsv(obj);
                }

                // Write data in row
                swFile.WriteLine(string.Join(",", colData));
            }

            // Close output stream
            swFile.Close();
        }
    }


    


}