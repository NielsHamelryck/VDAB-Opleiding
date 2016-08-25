using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class StripsDBManager
    {
        private static ConnectionStringSettings conStripsSettings =
            ConfigurationManager.ConnectionStrings["strips"];

        private static DbProviderFactory Factory =
            DbProviderFactories.GetFactory(conStripsSettings.ProviderName);

        public DbConnection GetConnection()
        {
            var conStrips = Factory.CreateConnection();
            conStrips.ConnectionString = conStripsSettings.ConnectionString;
            return conStrips;
        }
    }
}
