namespace RoushTech.Microsoft.Dynamics.Import.UI.Config
{
    using System;
    using System.Collections.Generic;

    public interface IMapperTable
    {
        Type MappingType { get; }

        List<IMapperColumn> ColumnMappings { get; }
    }
}
