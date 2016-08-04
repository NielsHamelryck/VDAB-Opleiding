using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AdoGemeenschap
{
    public class Bank2DbManager
    {
        private static ConnectionStringSettings conBank2Settings=
            ConfigurationManager.ConnectionStrings["Bank2"];

        private static DbProviderFactory Factory =
            DbProviderFactories.GetFactory(conBank2Settings.ProviderName);

        public DbConnection GetConnection()
        {
            var conBank = Factory.CreateConnection();
            conBank.ConnectionString = conBank2Settings.ConnectionString;
            return conBank;
        }

    }
}
