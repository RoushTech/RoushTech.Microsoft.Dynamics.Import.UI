namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Validation;
    using System.Data.OleDb;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using RoushTech.Microsoft.Dynamics.Data;
    using RoushTech.Microsoft.Dynamics.Data.Inventory;

    public partial class Import : Form
    {
        public Import()
        {
            InitializeComponent();
        }

        private void ChangeButtonEnabledStatus(bool isEnabled)
        {
            this.ExecuteButton.Enabled = this.TrialButton.Enabled = isEnabled;
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
            int updates;
            int inserts;
            int skipped;
            this.DatabaseUpdate(false, out updates, out inserts, out skipped);

            this.ToolStripStatusLabel.Text = string.Format("Trial completed, {0} updates, {1} inserts, {2} skipped.", updates, inserts, skipped);
        }

        private void DatabaseUpdate(bool commit, out int updates, out int inserts, out int skipped)
        {
            var itemCurrencyMasterList = new List<ItemCurrencyMaster>();
            var itemPriceListList = new List<ItemPriceList>();
            var itemPriceListOptionsList = new List<ItemPriceListOptions>();

            foreach (DataRow row in Program.ImportDataTable.Rows)
            {
                var itemCurrencyMaster = new ItemCurrencyMaster();
                var itemPriceList = new ItemPriceList();
                var itemPriceListOptions = new ItemPriceListOptions();

                itemCurrencyMaster.ItemNumber = row["Item Number"].ToString();
                itemCurrencyMaster.CurrencyId = row["Currency ID"].ToString();
                itemCurrencyMaster.CurrencyIndex = 1007;
                itemCurrencyMaster.DecimalPlacesInCurrency = 6;
                itemCurrencyMaster.ListPrice = decimal.Parse(row["Price"].ToString());

                itemPriceList.ItemNumber = itemCurrencyMaster.ItemNumber;
                itemPriceList.CurrencyId = itemCurrencyMaster.CurrencyId;
                itemPriceList.FromQuantity = 1m;
                itemPriceList.PriceLevel = row["Price Level & Default Price Level"].ToString();
                itemPriceList.QuantityInBaseUnitOfMeasure = 1m;
                itemPriceList.ToQuantity = 999999999999m;
                itemPriceList.UnitOfMeasure = row["Default Selling U of M & U of M"].ToString();
                itemPriceList.UnitOfMeasurePrice = itemCurrencyMaster.ListPrice;

                itemPriceListOptions.ItemNumber = itemCurrencyMaster.ItemNumber;
                itemPriceListOptions.CurrencyId = itemCurrencyMaster.CurrencyId;
                itemPriceListOptions.PriceLevel = itemPriceList.PriceLevel;
                itemPriceListOptions.QuantityInBaseUnitOfMeasure = itemPriceList.QuantityInBaseUnitOfMeasure;
                itemPriceListOptions.RoundHow = 0;
                itemPriceListOptions.RoundTo = 1;
                itemPriceListOptions.RoundingAmount = 0;
                itemPriceListOptions.UnitOfMeasure = itemPriceList.UnitOfMeasure;
                itemPriceListOptions.UnitOfMeasureSalesOptions = 2;

                itemCurrencyMasterList.Add(itemCurrencyMaster);
                itemPriceListList.Add(itemPriceList);
                itemPriceListOptionsList.Add(itemPriceListOptions);
            }

            updates = 0;
            inserts = 0;
            skipped = 0;
            using (var context = new DynamicsContext("DynamicsDb"))
            {
                foreach (var item in itemCurrencyMasterList)
                {
                    var searchedItem =
                        context.ItemCurrencyMaster.FirstOrDefault(icm => icm.ItemNumber == item.ItemNumber);
                    if (searchedItem == null)
                    {
                        if (commit)
                        {
                            context.ItemCurrencyMaster.Add(item);
                        }
                        inserts++;
                    }
                    else
                    {
                        if (!this.CompareObjects(item, searchedItem))
                        {
                            this.CopyDifferentValues(searchedItem, item);
                            updates++;
                        }
                        else
                        {
                            skipped++;
                        }
                    }
                }

                foreach (var item in itemPriceListList)
                {
                    var searchedItem = context.ItemPriceList.FirstOrDefault(ipl => ipl.ItemNumber == item.ItemNumber);
                    if (searchedItem == null)
                    {
                        if (commit)
                        {
                            context.ItemPriceList.Add(item);
                        }
                        inserts++;
                    }
                    else
                    {
                        if (!this.CompareObjects(item, searchedItem))
                        {
                            this.CopyDifferentValues(searchedItem, item);
                            updates++;
                        }
                        else
                        {
                            skipped++;
                        }
                    }
                }

                foreach (var item in itemPriceListOptionsList)
                {
                    var searchedItem =
                        context.ItemPriceListOptions.FirstOrDefault(iplo => iplo.ItemNumber == item.ItemNumber);
                    if (searchedItem == null)
                    {
                        if (commit)
                        {
                            context.ItemPriceListOptions.Add(item);
                        }
                        inserts++;
                    }
                    else
                    {
                        if (!this.CompareObjects(item, searchedItem))
                        {
                            this.CopyDifferentValues(searchedItem, item);
                            updates++;
                        }
                        else
                        {
                            skipped++;
                        }
                    }
                }

                if (commit)
                {
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
        }

        private bool CompareObjects(object obj1, object obj2)
        {
            if (obj1.GetType() != obj2.GetType())
            {
                return false;
            }

            foreach (var propertyInfo in obj1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    var str1 = (string)propertyInfo.GetValue(obj1);
                    var str2 = (string)propertyInfo.GetValue(obj2);
                    if (!str1.Trim().Equals(str2.Trim()))
                    {
                        return false;
                    }

                    continue;
                }

                /*
                MessageBox.Show(
                    string.Format(
                        "{0}: '{1}' == '{2}' ({3}) {4}",
                        propertyInfo.Name,
                        propertyInfo.GetValue(obj1),
                        propertyInfo.GetValue(obj2),
                        propertyInfo.GetValue(obj1).Equals(propertyInfo.GetValue(obj2)),
                        propertyInfo.PropertyType));
                */

                if (!propertyInfo.GetValue(obj1).Equals(propertyInfo.GetValue(obj2)))
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

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            this.ToolStripStatusLabel.Text = "Executing update...";
            int updates;
            int inserts;
            int skipped;
            this.DatabaseUpdate(true, out updates, out inserts, out skipped);

            this.ToolStripStatusLabel.Text = string.Format("Update completed, {0} updates, {1} inserts, {2} skipped.", updates, inserts, skipped);
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
