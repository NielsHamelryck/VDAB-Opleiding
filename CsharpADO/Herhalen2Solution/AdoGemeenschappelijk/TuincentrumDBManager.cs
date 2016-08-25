using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class TuincentrumDBManager
    {

        private static ConnectionStringSettings conTuincSettings =
            ConfigurationManager.ConnectionStrings["Tuincentrum"];

        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory(conTuincSettings.ProviderName);

        public DbConnection GetConnection()
        {
            var conTuincentrum = factory.CreateConnection();
            conTuincentrum.ConnectionString = conTuincSettings.ConnectionString;
            return conTuincentrum;
        }
    }
}
