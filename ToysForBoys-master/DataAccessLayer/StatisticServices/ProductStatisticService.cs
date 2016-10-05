using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Queries;
using System.Data.SqlClient;

namespace DataAccessLayer.Services
{
    public class ProductStatisticService : IProductStatisticService
    {
        public List<Product> GetProductStatistics(ProductQuery productQuery)
        {
            var queryString = new StringBuilder();
            queryString.Append("from product in entities.products where ");


            if (productQuery.SortQuantity!=null)
            {
                switch ((int)productQuery.SortQuantity)
                {
                    case 0:
                        queryString.Append("product.quantityInStock ");
                        break;
                    case 1:
                        queryString.Append("product.quantityInOrder ");
                        break;
                }
            }

            bool quantityUsed = false;
            if (productQuery.minimumQuantity!=null)
            {
                queryString.Append("> " + productQuery.minimumQuantity + " ");
                quantityUsed = true;
            }

            if (productQuery.maximumQuantity!=null)
            {
                queryString.Append("< " + productQuery.maximumQuantity + " ");
                quantityUsed = true;
            }

            bool minPriceUsed = false;
            if (productQuery.minPrice!=null)
            {
                if (quantityUsed)
                {
                    queryString.Append("and where ");
                }
                queryString.Append("product.buyPrice > " + productQuery.minPrice + " ");
                minPriceUsed = true;
            }

            bool maxPriceUsed = false;
            if (productQuery.maxPrice!=null)
            {
                if (quantityUsed || minPriceUsed)
                {
                    queryString.Append("and where ");
                }

                queryString.Append("product.buyPrice < " + productQuery.maxPrice + " ");
                maxPriceUsed = true;
            }

            if (productQuery.active!=null)
            {
                if (maxPriceUsed || minPriceUsed || quantityUsed)
                {
                    queryString.Append("and where ");
                }

                queryString.Append("product.active == " + productQuery.active + " ");
            }
            queryString.Append("select product");

            using (var entities = new toysforboysEntities())
            {
                var cmd = new SqlCommand(queryString.ToString());
                var products = new List<Product>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Int32 idPos = reader.GetOrdinal("id");
                    Int32 namePos = reader.GetOrdinal("name");
                    Int32 scalePos = reader.GetOrdinal("scale");
                    Int32 descPos = reader.GetOrdinal("description");
                    Int32 qisPos = reader.GetOrdinal("quantityInStock");
                    Int32 qioPos = reader.GetOrdinal("quantityInOrder");
                    Int32 buyPricePos = reader.GetOrdinal("buyPrice");
                    Int32 productlineIdPos = reader.GetOrdinal("productlineId");
                    Int32 activePos = reader.GetOrdinal("active");

                    while (reader.Read())
                    {
                        var product = new Product();
                        product.id = Convert.ToInt32(reader.GetInt32(idPos));
                        product.name = reader.GetString(namePos);
                        product.scale = reader.GetString(scalePos);
                        product.description = reader.GetString(descPos);
                        product.quantityInStock = reader.GetInt32(qisPos);
                        product.quantityInOrder = reader.GetInt32(qioPos);
                        product.buyPrice = reader.GetDecimal(buyPricePos);
                        product.productlineId = reader.GetInt32(productlineIdPos);
                        product.active = reader.GetBoolean(activePos);
                        products.Add(product);
                    }
                }
                return products;
            }
            


        }

        
    }
}
