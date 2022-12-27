using System.Data.SqlClient;

namespace ApiWebCoderH.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public double? SalePrice { get; set; }
        public int? Stock { get; set; }
        public long UserID { get; set; }

        public Product() { }

        public Product(string description, double cost, double salePrice, int stock, long userID)
        {
            Description = description;
            Cost = cost;
            SalePrice = salePrice;
            Stock = stock;
            UserID = userID;
        }

        public Product(long id, string description, double cost, double salePrice, int stock, long userID)
        {
            Id = id;
            Description = description;
            Cost = cost;
            SalePrice = salePrice;
            Stock = stock;
            UserID = userID;
        }

        public static Product GetProduct(SqlDataReader reader)
        {
            Product product = new Product();
            product.Id = Convert.ToInt64(reader["Id"]);
            product.Description = reader["Descripciones"].ToString();
            product.Cost = Convert.ToInt32(reader["Costo"]);
            product.SalePrice = Convert.ToInt32(reader["PrecioVenta"]);
            product.Stock = Convert.ToInt16(reader["Stock"]);
            product.UserID = Convert.ToInt64(reader["IdUsuario"]);

            return product;
        }
    }
}
