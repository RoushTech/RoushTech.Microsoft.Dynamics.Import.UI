using System;
using System.Windows.Forms;

namespace RoushTech.Microsoft.Dynamics.Import.UI
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    using RoushTech.Microsoft.Dynamics.Data;
    using RoushTech.Microsoft.Dynamics.Import.UI.Config;

    static class Program
    {
        public static List<Type> ImportTypes { get; set; }

        public static DataTable ImportDataTable { get; set; }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            LoadTypes();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Import());
        }

        private static void LoadTypes()
        {
            ImportTypes = new List<Type>();
            foreach (var type in
                Assembly.GetAssembly(typeof(DynamicsContext))
                    .GetTypes()
                    .Where(t => t.FullName.Contains("RoushTech.Microsoft.Dynamics.Data.Inventory")))
            {
                ImportTypes.Add(type);
            }
        }
    }
}
