namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    using RoushTech.Microsoft.Dynamics.Import.UI.Config;

    public partial class Mapping : Form
    {
        public Mapping()
        {
            InitializeComponent();
        }

        private string SelectedColumn { get { return this.TableValueBox.SelectedItem == null ? null : ((PropertyInfo)this.TableValueBox.SelectedItem).Name; } }

        private string TableType { get { return this.Mappers.SelectedItem == null ? null : ((Type)this.Mappers.SelectedItem).FullName; } }

        private MapperConfig GetConfig()
        {
           return
                Program.Config.MapperConfigs.FirstOrDefault(
                    mapperLookup =>
                    mapperLookup.TableType == this.TableType
                    && mapperLookup.Column == this.SelectedColumn);
        }

        private void Save()
        {
            if (this.SelectedColumn == null)
            {
                return;
            }

            var config = this.GetConfig();
            if (config == null)
            {
                config = new MapperConfig();
                Program.Config.MapperConfigs.Add(config);
            }

            config.Column = this.SelectedColumn;
            config.CsvHeader = this.CsvSourceBox.SelectedItem.ToString();
            config.Constant = this.ConstantTextbox.Text;
            config.TableType = this.TableType;
            Program.Config.Save();
        }

        private void Mapping_Load(object sender, EventArgs e)
        {
            Program.ImportTypes.ForEach(type => this.Mappers.Items.Add(type));

            this.CsvSourceBox.Items.Add(string.Empty);
            for (var i = 0; i < Program.ImportDataTable.Columns.Count; i++)
            {
                this.CsvSourceBox.Items.Add(Program.ImportDataTable.Columns[i].ColumnName);
            }

            this.Mappers.DisplayMember = "Name";
        }

        private void Mappers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = (Type)this.Mappers.SelectedItem;
            type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToList()
                .ForEach(property => this.TableValueBox.Items.Add(property));
            this.TableValueBox.DisplayMember = "Name";
        }

        private void SourceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Save();
        }

        private void ConstantTextbox_TextChanged(object sender, EventArgs e)
        {
            this.Save();
        }

        private void TableValueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = this.GetConfig();
            if (config == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(config.CsvHeader))
            {
                for (var i = 0; i < this.CsvSourceBox.Items.Count; i++)
                {
                    if (string.Equals(this.CsvSourceBox.Items[i].ToString(), config.CsvHeader))
                    {
                        this.CsvSourceBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            this.ConstantTextbox.Text = config.Constant;
        }
    }
}
