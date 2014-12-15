namespace RoushTech.Microsoft.Dynamics.Import.UI.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class DataMapper
    {
        public Dictionary<Type, List<object>> MapData(DataTable dataTable)
        {
            var results = new Dictionary<Type, List<object>>(); 
            var mappers = new StaticMapping().Mapping();
            foreach (var mapping in mappers)
            {
                var list = new List<dynamic>();
                results.Add(mapping.MappingType, list);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var table = Activator.CreateInstance(mapping.MappingType);
                    foreach (var columnMapping in mapping.ColumnMappings)
                    {
                        columnMapping.MapValue(dataRow, table);
                    }

                    list.Add(table);
                }
            }

            return results;
        }
    }
}
