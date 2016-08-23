using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class BierenDbManager
    {
        private static ConnectionStringSettings connectionBierenSetting =
            ConfigurationManager.ConnectionStrings["Bieren"];

        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory(connectionBierenSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conBier = factory.CreateConnection();
            conBier.ConnectionString = connectionBierenSetting.ConnectionString;
            return conBier;
        }
    }
}
