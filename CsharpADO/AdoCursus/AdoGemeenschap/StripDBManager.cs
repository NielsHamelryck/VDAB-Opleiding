using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class StripDBManager
    {
        private static ConnectionStringSettings connectionStripSetting =
            ConfigurationManager.ConnectionStrings["Strips"];

        private static DbProviderFactory Factory =
            DbProviderFactories.GetFactory(connectionStripSetting.ProviderName);

        public DbConnection GetConnection()
        {
            var conStrip = Factory.CreateConnection();
            conStrip.ConnectionString = connectionStripSetting.ConnectionString;
            return conStrip;
        }
    }
}
