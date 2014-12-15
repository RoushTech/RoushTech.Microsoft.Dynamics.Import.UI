namespace RoushTech.Microsoft.Dynamics.Import.UI.Mapping
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    public class CsvReader
    {
        public static DataTable Read(string path)
        {
            try
            {
                var directoryPath = Path.GetDirectoryName(path);
                var fileName = Path.GetFileName(path);
                var sql = string.Format("SELECT * FROM [{0}]", fileName);
                using (var connection = new OleDbConnection(string.Format(
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Text;HDR=Yes\"",
                    directoryPath)))
                using (var command = new OleDbCommand(sql, connection))
                using (var adapter = new OleDbDataAdapter(command))
                {
                    var dataTable = new DataTable { Locale = CultureInfo.CurrentCulture };

                    // Stop automatically detecting my types! I want strings so I can handle types!
                    // EX: "Item Number" looks like an int and will be converted as one, but Dynamics stores it as a string, grr!
                    var tempDataTable = new DataTable();
                    adapter.Fill(tempDataTable);
                    foreach (DataColumn col in tempDataTable.Columns)
                    {
                        dataTable.Columns.Add(new DataColumn(col.ColumnName, typeof(string)));
                    }

                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2147467259)
                {
                    MessageBox.Show(
                        @"The selected file is currently open in another application, please close the file and try again.");
                    return null;
                }

                throw;
            }
        }
    }
}
