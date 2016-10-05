using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Queries;

namespace DataAccessLayer.Interfaces
{
    public interface IProductStatisticService
    {
        List<Product> GetProductStatistics(ProductQuery productQuery);
    }
}
