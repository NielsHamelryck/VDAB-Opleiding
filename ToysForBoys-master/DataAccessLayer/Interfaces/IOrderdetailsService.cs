using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderdetailsService
    {
        void Insert(Orderdetail orderdetail);
        void Delete(Orderdetail orderdetail);

        void Edit(Orderdetail orderdetail);

        IEnumerable<Orderdetail> GetAll();

        Orderdetail GetById(int orderdetailID, int productID);

        IEnumerable<Orderdetail> CreateOrderDetails(Order order, List<OrderedProduct> orderedProducts);


    }
}
