namespace RoushTech.Microsoft.Dynamics.Import.UI.Config
{
    using System.Data;

    public interface IMapperColumn
    {
        void MapValue(DataRow row, object tableObject);
    }
}
