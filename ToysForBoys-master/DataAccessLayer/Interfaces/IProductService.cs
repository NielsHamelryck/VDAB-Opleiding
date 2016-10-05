using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IProductService
    {
        void Insert(Product product);

        void Delete(Product product);

        void Edit(Product product);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string includes);
        IEnumerable<Product> GetAll(Func<Product, bool> predicate, string includes);

        Product GetById(int productID);
        Product GetById(int productID, string includes);

        OrderedProduct CreateOrderedProduct(string productName, int quantityOrdered, decimal priceEach);


    }
}
