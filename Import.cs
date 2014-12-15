namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using RoushTech.Microsoft.Dynamics.Data;
    using RoushTech.Microsoft.Dynamics.Import.UI.Mapping;

    public partial class Import : Form
    {
        public Import()
        {
            this.InitializeComponent();
        }

        private void ChangeButtonEnabledStatus(bool isEnabled)
        {
            this.ExecuteButton.Enabled = this.TrialButton.Enabled = isEnabled;
        }

        private void DatabaseUpdate(bool commit, out int updates, out int inserts, out int skipped)
        {
            var mappedDataTables = new DataMapper().MapData(Program.ImportDataTable);
            this.TrialResultsGridView.Rows.Clear();

            updates = 0;
            inserts = 0;
            skipped = 0;
            using (var context = new DynamicsContext("DynamicsDb"))
            {
                
                foreach (var mappedDataTable in mappedDataTables.Keys)
                {
                    var mappedDataRows = mappedDataTables[mappedDataTable];
                    var tableAttribute =
                        (TableAttribute)Attribute.GetCustomAttribute(mappedDataTable, typeof(TableAttribute));
                    var keyProperty =
                        mappedDataTable.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(
                                p => p.CustomAttributes.Any(a => a.AttributeType == typeof(KeyAttribute))).ToArray();
                    if (!keyProperty.Any())
                    {
                        throw new Exception(string.Format("Missing primary key from type {0}.", mappedDataTable));
                    }

                    var databaseTableSet = context.Set(mappedDataTable);
                    foreach (var mappedData in mappedDataRows)
                    {
                        var data = mappedData;
                        var primaryKeys = keyProperty.Select(kp => kp.GetValue(data)).ToArray();
                        var lookupResult = databaseTableSet.Find(primaryKeys);
                        string action;
                        if (lookupResult == null)
                        {
                            inserts++;
                            action = "Insert";
                            if (commit)
                            {
                                databaseTableSet.Add(mappedData);
                            }
                        }
                        else
                        {
                            if (this.CompareObjects(lookupResult, mappedData))
                            {
                                skipped++;
                                action = "Skipped";
                            }
                            else
                            {
                                updates++;
                                action = "Updated";
                                if (commit)
                                {
                                    this.CopyDifferentValues(lookupResult, mappedData);
                                }
                            }
                        }

                        this.TrialResultsGridView.Rows.Add(tableAttribute.Name, mappedDataTable.Name, primaryKeys.Aggregate((i, j) => i + ", " + j), action);
                    }
                }

                if (!commit)
                {
                    return;
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var validationError in exception.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors))
                    {
                        MessageBox.Show(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
            }
        }

        private bool CompareObjects(object target, object source)
        {
            if (target.GetType() != source.GetType())
            {
                return false;
            }

            foreach (var propertyInfo in target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (propertyInfo.GetValue(source) == null)
                {
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(string))
                {
                    var str1 = (string)propertyInfo.GetValue(target);
                    var str2 = (string)propertyInfo.GetValue(source);
                    if (!str1.Trim().Equals(str2.Trim()))
                    {
                        return false;
                    }

                    continue;
                }

                if (!propertyInfo.GetValue(target).Equals(propertyInfo.GetValue(source)))
                {
                    return false;
                }
            }

            return true;
        }

        private void CopyDifferentValues(object target, object source)
        {
            if (target.GetType() != source.GetType())
            {
                throw new Exception("Cannot swap different values of different types.");
            }

            foreach (var propertyInfo in target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (propertyInfo.GetValue(source) == null)
                {
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(string))
                {
                    var str1 = (string)propertyInfo.GetValue(target);
                    var str2 = (string)propertyInfo.GetValue(source);
                    if (!str1.Trim().Equals(str2.Trim()))
                    {
                        propertyInfo.SetValue(target, str2);
                    }

                    continue;
                }

                if (!propertyInfo.GetValue(target).Equals(propertyInfo.GetValue(source)))
                {
                    propertyInfo.SetValue(target, propertyInfo.GetValue(source));
                }
            }
        }

        // ReSharper disable InconsistentNaming
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

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            this.ToolStripStatusLabel.Text = @"Executing update...";
            int updates;
            int inserts;
            int skipped;
            this.DatabaseUpdate(true, out updates, out inserts, out skipped);

            this.ToolStripStatusLabel.Text = string.Format("Update completed, {0} updates, {1} inserts, {2} skipped.", updates, inserts, skipped);
        }

        private void Import_Load(object sender, EventArgs e)
        {
            this.ChangeButtonEnabledStatus(false);
        }

        private void TrialButton_Click(object sender, EventArgs e)
        {
            this.ToolStripStatusLabel.Text = @"Running trial...";
            int updates;
            int inserts;
            int skipped;
            this.DatabaseUpdate(false, out updates, out inserts, out skipped);

            this.ToolStripStatusLabel.Text = string.Format("Trial completed, {0} updates, {1} inserts, {2} skipped.", updates, inserts, skipped);
        }
        // ReSharper restore InconsistentNaming
    }
}
