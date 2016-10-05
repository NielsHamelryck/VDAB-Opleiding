using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrderService
    {
        void Insert(Order order);
        void Delete(Order order);

        void Edit(Order order);

        IEnumerable<Order> GetAll();
        
        IEnumerable<Order> GetAll(string includes);
        IEnumerable<Order> GetAll(Func<Order, bool> predicate, string includes);

        Order GetById(int orderID);
        Order GetById(int orderID, string includes);  
        

        IEnumerable<Orderdetail> GetOrderDetails(Order order);

        decimal GetTotalPrice(Order order);

        IEnumerable<Product> GetProducts(Order order);

        
        
    }
}
