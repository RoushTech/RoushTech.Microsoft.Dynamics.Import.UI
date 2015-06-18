namespace RoushTech.Microsoft.Dynamics.Import.UI.Mapping
{
    using System;
    using System.Collections.Generic;

    using RoushTech.Microsoft.Dynamics.Data.Inventory;
    using RoushTech.Microsoft.Dynamics.Import.UI.Config;

    public class StaticMapping
    {
        public IList<IMapperTable> Mapping()
        {
            return new List<IMapperTable>
                       {
                           ItemMaster(),
                           ItemCurrencyMaster(),
                           ItemPriceList(),
                           ItemPriceListOptions(),
                           ItemVendorMaster(),
                           ItemPurchasing()
                       };
        }

        private static MapperTable<ItemCurrencyMaster> ItemCurrencyMaster()
        {
            var mapperTable = new MapperTable<ItemCurrencyMaster>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, string>("Currency ID", (c, r) => c.CurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, short>((c, r) => c.CurrencyIndex = 1007));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, short>((c, r) => c.DecimalPlacesInCurrency = 6));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemCurrencyMaster, decimal>("Price", (c, r) => c.ListPrice = r));
            return mapperTable;
        }

        private static MapperTable<ItemMaster> ItemMaster()
        {
            var mapperTable = new MapperTable<ItemMaster>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Description", (c, r) => c.ItemDescription = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, decimal>((c, r) => c.NoteIndex = 0m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Short Description", (c, r) => c.ItemShortName = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>("Item Type", (c, r) => c.ItemType = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Generic Description", (c, r) => c.ItemGenericDescription = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, decimal>((c, r) => c.StandardCost = 0m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, decimal>("Current Cost", (c, r) => c.CurrentCost = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.ItemShippingWeight = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.DecimalPlacesQuantities = 4));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.DecimalPlacesCurrency = 6));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.ItemTaxScheduleId = ""));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>("Sales Tax Option", (c, r) => c.TaxOptions = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvIvIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvIvOffsetIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvSalesIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvSalesDiscountsIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvSalesReturnsIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvInUseIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvInServiceIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvDamagedIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IvVariancesIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.DropShipIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.PurchasePriceVarianceIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.UnrealizedPurchasePriceVarianceIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.InventoryReturnsIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.AssemblyVarianceIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("Class ID", (c, r) => c.ItemClassCode = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.ItemTrackingOption = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.LotType = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.KeepPeriodHistory = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.KeepTrxHistory = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.KeepCalendarHistory = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.KeepDistributionHistory = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.AllowBackOrders = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.ValuationMethod = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>("U of M Schedule ID", (c, r) => c.UnitOfMeasureSchedule = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.AlternateItem1 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.AlternateItem2 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.UserCategoryValues1 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.UserCategoryValues2 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.UserCategoryValues3 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.UserCategoryValues4 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.UserCategoryValues5 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.UserCategoryValues6 = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.MasterRecordType = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, DateTime>((c, r) => c.ModifiedDate = new DateTime(1900, 1, 1, 0, 0, 0)));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, DateTime>((c, r) => c.CreatedDate = new DateTime(1900, 1, 1, 0, 0, 0)));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.WarrantyDays = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.PriceLevel = "CONSUMER"));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.LocationCode = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.PurchInflationIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.PurchMonetaryCorrectionIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.InventoryInflationIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.InventoryMonetaryCorrectionIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.COGSInflationIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.COGSMonetaryCorrectionIndex = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.ItemCode = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.TaxCommodityCode = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.PriceGroup = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.PriceMethod = 1));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.PurchasingUnitOfMeasure = "EA"));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.SellingUnitOfMeasure = "EA"));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.KitCOGSAccountSource = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.LastGeneratedSerialNumber = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.ABCCode = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.RevalueInventory = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.TolerancePercentage = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.PurchaseItemTaxScheduleId = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>("Purchase Tax Option", (c, r) => c.PurchaseTaxOptions = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.ItemPlanningType = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.StatisticalValuePercentage = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.CountryOrigin = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.Inactive = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.MinShelfLife1 = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.MinShelfLife2 = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.IncludeInDemandPlanning = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, byte>((c, r) => c.LotExpireWarning = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, short>((c, r) => c.LotExpireWarningDays = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, string>((c, r) => c.LastGeneratedLotNumber = string.Empty));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.LotSplitQuantity = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.UseQuantityOverageTolerance = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.UseQuantityShortageTolerance = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.QuantityOverTolerancePercent = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.QuantityShortTolerancePercent = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemMaster, int>((c, r) => c.IVSCRVIX = 0));
            return mapperTable;
        }

        private static MapperTable<ItemPriceList> ItemPriceList()
        {
            var mapperTable = new MapperTable<ItemPriceList>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Currency ID", (c, r) => c.CurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Price Level & Default Price Level", (c, r) => c.PriceLevel = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, string>("Default Selling U of M & U of M", (c, r) => c.UnitOfMeasure = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>((c, r) => c.ToQuantity = 999999999999.999m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>((c, r) => c.FromQuantity = 0.001m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>("Price", (c, r) => c.UnitOfMeasurePrice = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceList, decimal>((c, r) => c.QuantityInBaseUnitOfMeasure = 1m));
            return mapperTable;
        }

        private static MapperTable<ItemPriceListOptions> ItemPriceListOptions()
        {
            var mapperTable = new MapperTable<ItemPriceListOptions>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Currency ID", (c, r) => c.CurrencyId = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Price Level & Default Price Level", (c, r) => c.PriceLevel = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, string>("Default Selling U of M & U of M", (c, r) => c.UnitOfMeasure = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, decimal>((c, r) => c.RoundingAmount = 0m));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, int>((c, r) => c.RoundHow = 0));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, int>((c, r) => c.RoundTo = 1));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, int>((c, r) => c.UnitOfMeasureSalesOptions = 2));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPriceListOptions, decimal>((c, r) => c.QuantityInBaseUnitOfMeasure = 1m));
            return mapperTable;
        }

        private static MapperTable<ItemPurchasing> ItemPurchasing()
        {
            var mapperTable = new MapperTable<ItemPurchasing>();
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPurchasing, string>("Item Number", (c, r) => c.ItemNumber = r));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPurchasing, string>((c, r) => c.UnitOfMeasure = "EA"));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPurchasing, string>((c, r) => c.UnitOfMeasurePurchasesOptions = 2));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemPurchasing, string>((c, r) => c.QuantityInBaseUnitOfMeasure = 1));
            return mapperTable;
        }

        private static MapperTable<ItemVendorMaster> ItemVendorMaster()
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
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, short>((c, r) => c.FreeOnBoard = 2));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, short>((c, r) => c.CurrencyIndex = 2044));
            mapperTable.ColumnMappings.Add(new MapperColumn<ItemVendorMaster, short>((c, r) => c.ItemVendorType = 1));
            return mapperTable;
        }
    }
}
