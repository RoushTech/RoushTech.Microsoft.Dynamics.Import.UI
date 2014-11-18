namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    using RoushTech.Microsoft.Dynamics.Data;

    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }

        private void ChangeButtonEnabledStatus(bool isEnabled)
        {
            this.MappingsButton.Enabled = this.ExecuteButton.Enabled = this.TrialButton.Enabled = isEnabled;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            this.OpenFileDialog.Filter = @"CSV Files (.csv)|*.csv";
            if (this.OpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Program.ImportDataTable = CsvReader.Read(this.OpenFileDialog.FileName);
            this.DataGridView.DataSource = Program.ImportDataTable;
            var validDataTable = Program.ImportDataTable != null;
            this.ChangeButtonEnabledStatus(validDataTable);
        }

        private void TrialButton_Click(object sender, EventArgs e)
        {
            this.ToolStripStatusLabel.Text = "Running trial...";
            using (var context = new DynamicsContext())
            {
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {

        }

        private void MappingsButton_Click(object sender, EventArgs e)
        {
            new Mapping().Show();
        }

        private void Import_Load(object sender, EventArgs e)
        {
            this.ChangeButtonEnabledStatus(false);
        }
    }
}
