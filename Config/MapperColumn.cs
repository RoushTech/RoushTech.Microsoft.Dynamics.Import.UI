namespace RoushTech.Microsoft.Dynamics.Import.UI.Config
{
    using System;
    using System.Data;

    public class MapperColumn<T, TC> : IMapperColumn
    {
        public MapperColumn(Action<T, TC> mapperFunc)
        {
            this.MapperFunction = mapperFunc;
        }

        public MapperColumn(string source, Action<T, TC> mapperFunc)
            : this(mapperFunc)
        {
            this.SourceColumn = source;
        }
        
        public string SourceColumn { get; set; }

        public Action<T, TC> MapperFunction { get; set; }

        public void MapValue(DataRow row, object tableObject)
        {
            if (tableObject.GetType() != typeof(T))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Unable to map value to row, expected table object of type {0}, got object of type {1}.",
                        typeof(T),
                        tableObject.GetType()));
            }

            if (this.SourceColumn == null)
            {
                this.MapperFunction((T)tableObject, default(TC));
                return;
            }

            dynamic rowObject = row[this.SourceColumn];
            if (rowObject is DBNull)
            {
                return;
            }

            TC rowValue;
            switch (typeof(TC).Name)
            {
                case "String":
                    rowValue = rowObject;
                    break;
                case "Int16":
                    rowValue = short.Parse(rowObject);
                    break;
                case "Decimal":
                    rowValue = decimal.Parse(rowObject);
                    break;
                default:
                    throw new Exception(
                        string.Format("Type of {0} not supported for automatic mapping.", typeof(TC).FullName));
            }

            this.MapperFunction((T)tableObject, rowValue);
        }
    }
}
