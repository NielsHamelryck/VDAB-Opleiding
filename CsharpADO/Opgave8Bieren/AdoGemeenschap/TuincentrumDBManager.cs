using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class TuincentrumDBManager
    {
        private static ConnectionStringSettings connectionStringSettingsTuincentrum =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];

        private static DbProviderFactory Factory =
            DbProviderFactories.GetFactory(connectionStringSettingsTuincentrum.ProviderName);

        public DbConnection GetConnection()
        {
            
                var conTuin = Factory.CreateConnection();
                conTuin.ConnectionString = connectionStringSettingsTuincentrum.ConnectionString;
                return conTuin;
            
           

        }

    }
}
