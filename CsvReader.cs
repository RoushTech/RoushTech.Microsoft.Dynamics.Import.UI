namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    class CsvReader
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
