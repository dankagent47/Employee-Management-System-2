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
    class ExportToFiles<T> where T : FileIO {
        public List<string> files = new List<string> { };
        public T file_writer;
        public void Export(DataTable table)
        {
            foreach(var file in files)
            {
                file_writer.ExportDatatableToFile(file, table);
            }
        }
    }

    abstract public class FileIO
    {
        public abstract string GetWriteableValueForFile(object obj);
        public abstract void ExportDataviewToFile(string filename, DataView dv);
        public abstract void ExportDatatableToFile(string filename, DataTable dt);
    }

        public class CSV_IO : FileIO
        {
            public DataTable readCSV;

            public CSV_IO(string fileName, bool firstRowContainsFieldNames = true)
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
                    throw new Exception("Inappropriate class; consider using TxtIO()");
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

        private void LoadFileOnDataGridView(string fileName, DataGridView dataGridView)
        {
            try
            {
                CSV_IO csv = new CSV_IO(fileName);

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

        override public void ExportDatatableToFile(string filename, DataTable dt)
        {
            // Open output stream
            StreamWriter swFile = new StreamWriter(filename);

            // Header
            string[] colLbls = new string[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colLbls[i] = dt.Columns[i].ColumnName;
                colLbls[i] = GetWriteableValueForFile(colLbls[i]);
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
                    colData[i] = GetWriteableValueForFile(obj);
                }

                // Write data in row
                swFile.WriteLine(string.Join(",", colData));
            }

            // Close output stream
            swFile.Close();
        }

        override public string GetWriteableValueForFile(object obj)
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

        override public void ExportDataviewToFile(string filename, DataView dv)
        {
            // Open output stream
            StreamWriter swFile = new StreamWriter(filename);

            // Header
            string[] colLbls = new string[dv.Table.Columns.Count];
            for (int i = 0; i < dv.Table.Columns.Count; i++)
            {
                colLbls[i] = dv.Table.Columns[i].ColumnName;
                colLbls[i] = GetWriteableValueForFile(colLbls[i]);
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
                    colData[i] = GetWriteableValueForFile(obj);
                }

                // Write data in row
                swFile.WriteLine(string.Join(",", colData));
            }

            // Close output stream
            swFile.Close();
        }
    }

    public class Txt_IO : FileIO
    {
        public DataTable readTxt;

        public Txt_IO(string fileName, bool firstRowContainsFieldNames = true)
        {
            readTxt = GenerateDataTable(fileName, firstRowContainsFieldNames);
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

            if (extension.ToLower() == "csv")
                throw new Exception("Inappropriate class; consider using CSV_IO()");
            else if (extension.ToLower() == "txt")
                delimiters = "\t";

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

        private void LoadFileOnDataGridView(string fileName, DataGridView dataGridView)
        {
            try
            {
                Txt_IO txt = new Txt_IO(fileName);

                try
                {
                    dataGridView.DataSource = txt.readTxt;
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

        override public void ExportDatatableToFile(string filename, DataTable dt)
        {
            // Open output stream
            StreamWriter swFile = new StreamWriter(filename);

            // Header
            string[] colLbls = new string[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colLbls[i] = dt.Columns[i].ColumnName;
                colLbls[i] = GetWriteableValueForFile(colLbls[i]);
            }

            // Write labels
            swFile.WriteLine(string.Join('\t', colLbls));

            // Rows of Data
            foreach (DataRow rowData in dt.Rows)
            {
                string[] colData = new string[dt.Columns.Count];

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    object obj = rowData[i];
                    colData[i] = GetWriteableValueForFile(obj);
                }

                // Write data in row
                swFile.WriteLine(string.Join("\t", colData));
            }

            // Close output stream
            swFile.Close();
        }

        override public string GetWriteableValueForFile(object obj)
        {
            // Nullable types to blank
            if (obj == null || obj == Convert.DBNull)
            {
                return "";
            }

            // if string has no ','
            if (obj.ToString().IndexOf("\t") == -1)
            {
                return obj.ToString();
            }

            // remove backslahes
            return "\"" + obj.ToString() + "\"";
        }

        override public void ExportDataviewToFile(string filename, DataView dv)
        {
            // Open output stream
            StreamWriter swFile = new StreamWriter(filename);

            // Header
            string[] colLbls = new string[dv.Table.Columns.Count];
            for (int i = 0; i < dv.Table.Columns.Count; i++)
            {
                colLbls[i] = dv.Table.Columns[i].ColumnName;
                colLbls[i] = GetWriteableValueForFile(colLbls[i]);
            }

            // Write labels
            swFile.WriteLine(string.Join("\t", colLbls));

            // Rows of Data
            foreach (DataRowView rowData in dv)
            {
                string[] colData = new string[dv.Table.Columns.Count];
                for (int i = 0; i < dv.Table.Columns.Count; i++)
                {
                    object obj = rowData[i];
                    colData[i] = GetWriteableValueForFile(obj);
                }

                // Write data in row
                swFile.WriteLine(string.Join("\t", colData));
            }

            // Close output stream
            swFile.Close();
        }
    }

}