namespace RoushTech.Microsoft.Dynamics.Import.UI.Mapping
{
    using System.Collections.Generic;

    using RoushTech.Microsoft.Dynamics.Data.Inventory;
    using RoushTech.Microsoft.Dynamics.Import.UI.Config;

    public class StaticMapping
    {
        public IList<IMapperTable> Mapping()
        {
            return new List<IMapperTable>
                       {
                           this.ItemMaster(),
                           this.ItemCurrencyMaster(),
                           this.ItemPriceList(),
                           this.ItemPriceListOptions(),
                           this.ItemVendorMaster()
                       };
        }

        private MapperTable<ItemCurrencyMaster> ItemCurrencyMaster()
        {
            var mapperTable = new MapperTable<ItemCurrencyMaster>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, string>("Currency ID", (c, r) => c.CurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, short>((c, r) => c.CurrencyIndex = 1007));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, short>((c, r) => c.DecimalPlacesInCurrency = 6));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, decimal>("Price", (c, r) => c.ListPrice = r));
            return mapperTable;
        }

        private MapperTable<ItemMaster> ItemMaster()
        {
            var mapperTable = new MapperTable<ItemMaster>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Description", (c, r) => c.ItemDescription = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Short Description", (c, r) => c.ItemShortName = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>("Item Type", (c, r) => c.ItemType = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Generic Description", (c, r) => c.ItemGenericDescription = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, decimal>("Current Cost", (c, r) => c.CurrentCost = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.DecimalPlacesQuantities = 3));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.DecimalPlacesCurrency = 3));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>("Sales Tax Option", (c, r) => c.TaxOptions = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Class ID", (c, r) => c.ItemClassCode = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("U of M Schedule ID", (c, r) => c.UnitOfMeasureSchedule = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.PriceMethod = 1));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>("Purchase Tax Option", (c, r) => c.PurchaseTaxOptions = r));
            return mapperTable;
        }

        private MapperTable<ItemPriceList> ItemPriceList()
        {
            var mapperTable = new MapperTable<ItemPriceList>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Currency ID", (c, r) => c.CurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Price Level & Default Price Level", (c, r) => c.PriceLevel = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Default Selling U of M & U of M", (c, r) => c.UnitOfMeasure = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>((c, r) => c.ToQuantity = 999999999999.999m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>((c, r) => c.FromQuantity = 0.001m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>("Price", (c, r) => c.UnitOfMeasurePrice = r));
            return mapperTable;
        }

        private MapperTable<ItemPriceListOptions> ItemPriceListOptions()
        {
            var mapperTable = new MapperTable<ItemPriceListOptions>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Currency ID", (c, r) => c.CurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Price Level & Default Price Level", (c, r) => c.PriceLevel = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Default Selling U of M & U of M", (c, r) => c.UnitOfMeasure = r));
            return mapperTable;
        }

        private MapperTable<ItemVendorMaster> ItemVendorMaster()
        {
            var mapperTable = new MapperTable<ItemVendorMaster>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, string>("Vendor ID", (c, r) => c.VendorId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, string>("Vendor Item", (c, r) => c.VendorItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, decimal>("Minimum Order", (c, r) => c.MinimumOrderQuantity = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, string>("Vendor Description", (c, r) => c.VendorItemDescription = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, decimal>("Originating Invoice Cost", (c, r) => c.LastOriginatingCost = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, string>("Currency ID", (c, r) => c.LastCurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, decimal>("Order Multiple", (c, r) => c.OrderMultiple = r));
            return mapperTable;
        }
    }
}
