namespace RoushTech.Microsoft.Dynamics.Import.UI.Config
{
    using System;
    using System.Collections.Generic;

    public class MapperTable<T> : IMapperTable
    {
        public MapperTable()
        {
            this.ColumnMappings = new List<IMapperColumn>();
            this.MappingType = typeof(T);
        }

        public Type MappingType { get; private set; }
        
        public List<IMapperColumn> ColumnMappings { get; private set; }
    }
}
