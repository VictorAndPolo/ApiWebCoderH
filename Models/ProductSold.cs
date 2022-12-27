using System.Data.SqlClient;

namespace ApiWebCoderH.Models
{
    public class ProductSold
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public long Stock { get; set; }
        public long SaleId { get; set; }

        public ProductSold() { }

        public ProductSold(int productId, long stock, long saleId)
        {
            ProductId = productId;
            Stock = stock;
            SaleId = saleId;
        }

        public ProductSold(long id, int productId, long stock, long saleId)
        {
            Id = id;
            ProductId = productId;
            Stock = stock;
            SaleId = saleId;
        }

        public static ProductSold GetProductSold(SqlDataReader reader)
        {
            ProductSold productSold = new ProductSold();
            productSold.Id = Convert.ToInt64(reader["Id"]);
            productSold.ProductId = Convert.ToInt16(reader["IdProducto"]);
            productSold.Stock = Convert.ToInt64(reader["Stock"]);
            productSold.SaleId = Convert.ToInt64(reader["IdVenta"]);

            return productSold;
        }
    }
}
