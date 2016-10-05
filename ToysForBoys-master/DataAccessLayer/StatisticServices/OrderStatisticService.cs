using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using System.Windows;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.SqlClient;

namespace DataAccessLayer.Services
{
    public class OrderStatisticService : IOrderStatisticService
    {
       public List<Order> GetByDistinctYear(SortDateEnum sortDate, int year)
        {
            var service = new OrderService();
            var orders = (List<Order>)service.GetAll();
            var ordersOfYear = new List<Order>();

            foreach (var ord in orders)
            {
                switch ((int)sortDate)
                {
                    case 0:
                        if (ord.orderDate.Value.Year == year)
                        {
                            ordersOfYear.Add(ord);
                        }
                        break;

                    case 1:
                        if (ord.requiredDate.Value.Year == year)
                        {
                            ordersOfYear.Add(ord);
                        }
                        break;

                    case 2:
                        if (ord.shippedDate.Value.Year == year)
                        {
                            ordersOfYear.Add(ord);
                        }
                        break;
                }

            }
            return orders;
           
        }

        public List<Order> GetFilteredOrderStatistics(List<Order> orders, SortDateEnum SortDateCompareLeft, char DateCompareMode, SortDateEnum SortDateCompareRight)
        {
            var filteredOrders = new List<Order>();
            var datesLeft = GetDateTimes(SortDateCompareLeft, orders);
            var datesRight = GetDateTimes(SortDateCompareRight, orders);

            //Checken welke operator er wordt gebruikt (=, > of <)
            for (int i = 0; i < orders.Count; i++)
            {
                switch (DateCompareMode)
                {
                    case '=':
                        if (datesLeft[i] == datesRight[i])
                        {
                            filteredOrders.Add(orders[i]);
                        }
                        break;
                    case '<':
                        if (datesLeft[i]<datesRight[i])
                        {
                            filteredOrders.Add(orders[i]);
                        }
                        break;
                    case '>':
                        if (datesLeft[i]>datesRight[i])
                        {
                            filteredOrders.Add(orders[i]);
                        }
                        break;
                }
            }

            return filteredOrders;
        }

        public List<Order> GetLateShippingDates()
        {
            var service = new OrderService();
            var orders = (List<Order>)service.GetAll();

            foreach (var ord in orders)
            {
                if (ord.shippedDate<ord.requiredDate)
                {
                    orders.Add(ord);
                }
            }

            return orders;
        }

        public List<Order> GetOrderStatistics(OrderQuery orderQuery)
        {

            var queryString = new StringBuilder();
            queryString.Append("from order in entities.orders where ");

            //toevoegen kiezen van soort datum uit enum als deze megegeven wordt als parameter
            if (orderQuery.SortDateRange != null)
            {
                switch ((int)orderQuery.SortDateRange)
                {
                    case 0:
                        queryString.Append("order.orderDate ");
                        break;
                    case 1:
                        queryString.Append("order.requiredDate ");
                        break;
                    case 2:
                        queryString.Append("order.shippedDate ");
                        break;

                    default:
                        break;
                }
            }

            //checken of DateRangeStart is ingevuld
            bool DateRangeUsed = false;
            if (orderQuery.DateRangeStart != null)
            {
                queryString.Append("> " + orderQuery.DateRangeStart.ToString() + " ");
                DateRangeUsed = true;
            }

            if (orderQuery.DateRangeEnd != null)
            {
                queryString.Append("< " + orderQuery.DateRangeEnd.ToString() + " ");
                DateRangeUsed = true;
            }

            //checken of customer ID is ingevuld
            bool customerIdUsed = false;
            if (orderQuery.CustomerId != null)
            {
                if (DateRangeUsed == true)
                {
                    queryString.Append("and where ");
                }

                queryString.Append("order.customerId == " + orderQuery.CustomerId +" ");
                customerIdUsed = true;
            }

            //Checken of status is ingevuld
            if (orderQuery.Status != string.Empty)
            {
                if (DateRangeUsed == true || customerIdUsed == true)
                {
                    queryString.Append("and where ");
                }

                queryString.Append("order.status == " + orderQuery.Status + " ");
            }


            //effectieve query uitvoeren en list van orders teruggeven
            queryString.Append("select order");

            using (var entities = new toysforboysEntities())
            {
                var cmd = new SqlCommand(queryString.ToString());
                var orders = new List<Order>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Int32 orderIdPos = reader.GetOrdinal("id");
                    Int32 orderDatePos = reader.GetOrdinal("orderDate");
                    Int32 requiredDatePos = reader.GetOrdinal("requiredDate");
                    Int32 shippedDatePos = reader.GetOrdinal("shippedDate");
                    Int32 commentsPos = reader.GetOrdinal("comments");
                    Int32 customerIdPos = reader.GetOrdinal("customerId");
                    Int32 status = reader.GetOrdinal("status");
                    
                    while (reader.Read())
                    {
                        var order = new Order();
                        order.id = Convert.ToInt32(reader.GetInt32(orderIdPos));
                        order.orderDate = Convert.ToDateTime(reader.GetString(orderDatePos));
                        order.requiredDate = Convert.ToDateTime(reader.GetString(requiredDatePos));
                        order.shippedDate = Convert.ToDateTime(reader.GetString(shippedDatePos));
                        order.comments = Convert.ToString(reader.GetString(commentsPos));
                        order.customerId = Convert.ToInt32(reader.GetInt32(customerIdPos));
                        order.status = Convert.ToString(reader.GetString(status));
                        orders.Add(order);
                    }

                    return orders;
                }
                
                
            }
        }

        public List<Order> GetUrgentShippingDates(int days)
        {
            var service = new OrderService();
            var orders = (List<Order>)service.GetAll();

            foreach (var ord in orders)
            {
                if (ord.shippedDate.Value-DateTime.Now <= TimeSpan.FromDays(days))
                {
                    orders.Add(ord);
                }
            }

            return orders;
        }

        //Switch method
        private List<DateTime> GetDateTimes(SortDateEnum sortDateEnum, List<Order> orders)
        {
            List<DateTime> datetime = new List<DateTime>();

            foreach (var order in orders)
            {
                switch (sortDateEnum)
                {
                    case SortDateEnum.orderDate: datetime.Add(Convert.ToDateTime(order.orderDate));
                        break;
                    case SortDateEnum.requiredDate: datetime.Add(Convert.ToDateTime(order.requiredDate));
                        break;
                    case SortDateEnum.shippedDate: datetime.Add(Convert.ToDateTime(order.shippedDate));
                        break;                   
                }
            }
            return datetime;
        }
    }
}
