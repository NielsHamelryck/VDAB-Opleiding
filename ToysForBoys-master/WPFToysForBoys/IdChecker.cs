using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToysForBoys
{
    public class CustomerCompare : IComparer<Customer>
    {
        public CustomerCompare(): base(){ }
        public int Compare(Customer x, Customer y)
        {
            if (x.id == y.id)
                return 0;
            else if (x.id < y.id)
                return -1;
            else
                return 1;
        }
    }

    public class IdChecker
    {
        public static bool IdCheck(List<Product> l, Product p)
        {
            bool b = false;
            foreach (Product product in l)
            {
                if (p.id == product.id)
                {
                    b = true;
                    if (p.name == product.name && p.buyPrice == product.buyPrice && p.description == product.description && p.productlineId == product.productlineId && p.quantityInOrder == product.quantityInOrder && p.quantityInStock == product.quantityInStock && p.scale == product.scale)
                        throw new ArgumentException();
                    break;
                }
            }
            return b;
        }

        public static bool IdCheck(List<Productline> l, Productline p)
        {
            bool b = false;
            foreach (Productline productline in l)
            {
                if (p.id == productline.id)
                {
                    b = true;
                    if (p.description == productline.description && p.name == productline.name)
                        throw new ArgumentException();
                    break;
                }
            }
            return b;
        }

        public static bool IdCheck(List<Customer> l, Customer c)
        {
            bool b = false;
            foreach (Customer customer in l)
            {
                if (c.id == customer.id)
                {
                    b = true;
                    if (c.city == customer.city && c.name == customer.name && c.countryId == customer.countryId && c.email == customer.email && c.password == customer.password && c.postalCode == customer.postalCode && c.state == customer.state && c.streetAndNumber == customer.streetAndNumber)
                        throw new ArgumentException();
                    break;
                }
            }
            return b;
        }

        public static bool IdCheck(List<Order> l, Order o)
        {
            bool b = false;
            foreach (Order order in l)
            {
                if (o.id == order.id)
                {
                    b = true;
                    if (o.comments == order.comments && o.customerId == order.customerId && o.orderDate == order.orderDate && o.requiredDate == order.requiredDate && o.shippedDate == order.shippedDate && o.status == order.status)
                        throw new ArgumentException();
                    break;
                }
            }
            return b;
        }

        public static bool IdCheck(List<Orderdetail> l, Orderdetail o)
        {
            bool b = false;
            foreach (Orderdetail orderdetail in l)
            {
                if (o.orderId == orderdetail.orderId && o.productId == orderdetail.productId)
                {
                    b = true;
                    if (o.priceEach == orderdetail.priceEach && o.quantityOrdered == orderdetail.quantityOrdered)
                        throw new ArgumentException();
                    break;
                }
            }
            return b;
        }
    }
}
