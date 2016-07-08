using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace AdoGemeenschap
{
    public class TuincentrumDbManager
    {
        private static ConnectionStringSettings conTuincentrumSettings =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];

        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory(conTuincentrumSettings.ProviderName);

        public DbConnection GetConnection()
        {
            var conTuin = factory.CreateConnection();
            conTuin.ConnectionString = conTuincentrumSettings.ConnectionString;
            return conTuin;
        }
    }
}
