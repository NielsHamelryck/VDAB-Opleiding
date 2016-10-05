using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ProductService : IProductService
    {
        public void Insert(Product product)
        {
            using (var entities = new toysforboysEntities())
            {
                entities.products.Add(product);
                entities.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (var entities = new toysforboysEntities())
            {
                entities.products.Attach(product);
                entities.products.Remove(product);
                entities.SaveChanges();
            }
        }

        public void Edit(Product product)
        {

            using (var entities = new toysforboysEntities())
            {
                var originalProduct = entities.products.Find(product.id);

                if(product.name!=string.Empty)
                    originalProduct.name = product.name;

                if(product.scale!=string.Empty)
                    originalProduct.scale = product.scale;

                if(product.description!=string.Empty)
                    originalProduct.description = product.description;

                if(product.quantityInStock!=null)
                    originalProduct.quantityInStock = product.quantityInStock;

                if(product.quantityInOrder!=null)
                    originalProduct.quantityInOrder = product.quantityInOrder;

                if(product.buyPrice!=null)
                    originalProduct.buyPrice = product.buyPrice;

                if (product.active != null)
                    originalProduct.active = product.active;

                originalProduct.productlineId = product.productlineId;

                entities.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> AllProducts = new List<Product>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var product in entities.products)
                {
                    AllProducts.Add(product);
                }
            }

            return AllProducts;
        }

        public Product GetById(int productID)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from product in entities.products
                             where product.id == productID
                             orderby product.id
                             select product).First();

                return query;
            }
        }

        public Product GetById(int productID, string includes)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from product in entities.products
                             where product.id == productID
                             orderby product.id
                             select product).Include(includes).First();

                return query;
            }
        }

        public IEnumerable<Product> GetAll(string includes)
        {
            return GetAll(p => true, includes);
        }

        public IEnumerable<Product> GetAll(Func<Product, bool> predicate, string includes)
        {
            List<Product> AllProducts = new List<Product>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var Product in (String.IsNullOrEmpty(includes) ? entities.products : entities.products.Include(includes)).Where(predicate))
                {
                    AllProducts.Add((Product)Product);
                }
            }

            return AllProducts;
        }

        public OrderedProduct CreateOrderedProduct(string productName, int quantityOrdered, decimal priceEach)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from product in entities.products
                            where product.name == productName
                            select product).FirstOrDefault();

                if (query==null)
                {
                    throw new Exception("Product not found");
                }
                else
                {
                    OrderedProduct op = (OrderedProduct)query;
                    op.quantityOrdered = quantityOrdered;
                    op.priceEach = priceEach;
                    return op;
                }

                
            }
            
        }


    }
}
