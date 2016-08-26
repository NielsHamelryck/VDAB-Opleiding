using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class VideoDBManager
    {
        private static ConnectionStringSettings conVideoSettings =
            ConfigurationManager.ConnectionStrings["Videos"];

        private static DbProviderFactory factory =
            DbProviderFactories.GetFactory(conVideoSettings.ProviderName);

        public DbConnection GetConnection()
        {
            var conVideos = factory.CreateConnection();
            conVideos.ConnectionString = conVideoSettings.ConnectionString;
            return conVideos;
        }

    }
}
