using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Services
{
    public class OrderService : IOrderService
    {
        public void Insert(Order order)
        {
            using (var entities = new toysforboysEntities())
            {
                entities.orders.Add(order);
                entities.SaveChanges();
            }
        }

        public void Delete(Order order)
        {
            using (var entities = new toysforboysEntities())
            {
                entities.orders.Attach(order);
                entities.orders.Remove(order);
                entities.SaveChanges();
            }
        }

        public void Edit(Order order)
        {

            using (var entities = new toysforboysEntities())
            {
                var originalOrder = entities.orders.Find(order.id);

                if (order.orderDate != null)
                    originalOrder.orderDate = order.orderDate;

                if (order.requiredDate != null)
                    originalOrder.requiredDate = order.requiredDate;

                if (order.shippedDate != null)
                    originalOrder.shippedDate = order.shippedDate;

                if (order.comments != string.Empty)
                    originalOrder.comments = order.comments;


                originalOrder.customerId = order.customerId;

                if (order.status != string.Empty)
                    originalOrder.status = order.status;

                entities.SaveChanges();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            List<Order> AllOrders = new List<Order>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var order in entities.orders)
                {
                    AllOrders.Add(order);
                }
            }

            return AllOrders;
        }

        public IEnumerable<Order> GetAll(string includes)
        {
            return GetAll(p => true, includes);
        }

        public IEnumerable<Order> GetAll(Func<Order, bool> predicate, string includes)
        {
            List<Order> Allorders = new List<Order>();
            using (var entities = new toysforboysEntities())
            {
                foreach (var order in (String.IsNullOrEmpty(includes) ? entities.orders : entities.orders.Include(includes)).Where(predicate))
                {
                    Allorders.Add((Order)order);
                }
            }

            return Allorders;
        }

        public Order GetById(int orderID)
        {
            return GetById(orderID, string.Empty);
        }

        public Order GetById(int orderID, string includes)
        {
            using (var entities = new toysforboysEntities())
            {
                var query = (from order in entities.orders
                             where order.id == orderID
                             orderby order.id
                             select order).Include(includes).First();

                return query;
            }
        }

        public IEnumerable<Orderdetail> GetOrderDetails(Order order)
        {
            var orderdetails = new List<Orderdetail>();

            using (var entities = new toysforboysEntities())
            {
                foreach (var od in entities.orderdetails)
                {
                    if (order.id == od.orderId)
                    {
                        orderdetails.Add(od);
                    }
                }
            }
            //using (var entities = new toysforboysEntities())
            //{
            //    var query = (from orderdetail in entities.orderdetails
            //                 where orderdetail.orderId == order.id
            //                 orderby orderdetail.productId
            //                 select orderdetail).Include("product");

            //    return query;
            //}

            return orderdetails;
        }

        public decimal GetTotalPrice(Order order)
        {
            var orderdetails = GetOrderDetails(order);
            decimal totalPrice = 0;

            foreach (var od in orderdetails)
            {
                totalPrice += (decimal)(od.quantityOrdered * od.priceEach);
            }

            return totalPrice;
        }

        public IEnumerable<Product> GetProducts(Order order)
        {
            var service = new ProductService();
            var products = new List<Product>();
            var orderdetails = GetOrderDetails(order);

            foreach (var orderdetail in orderdetails)
            {
                products.Add(service.GetById(orderdetail.productId));
            }

            return products;
        }
    }
}
