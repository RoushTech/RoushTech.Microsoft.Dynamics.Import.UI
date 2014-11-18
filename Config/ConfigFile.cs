namespace RoushTech.Microsoft.Dynamics.Import.UI.Config
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public class ConfigFile
    {
        private const string FILENAME = "config.xml";

        public List<MapperConfig> MapperConfigs { get; set; }
        
        public ConfigFile()
        {
            this.MapperConfigs = new List<MapperConfig>();
        }

        public XmlSerializer GetSerializer()
        {
            return new XmlSerializer(typeof(ConfigFile));
        }

        public ConfigFile Load()
        {
            if (!File.Exists(FILENAME))
            {
                return new ConfigFile();
            }

            using (var streamReader = new StreamReader(FILENAME))
            {
                return (ConfigFile)this.GetSerializer().Deserialize(streamReader);
            }
        }

        public void Save()
        {
            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                this.GetSerializer().Serialize(memoryStream, this);
                data = memoryStream.ToArray();
            }

            File.WriteAllBytes(FILENAME, data);
        }
    }
}
