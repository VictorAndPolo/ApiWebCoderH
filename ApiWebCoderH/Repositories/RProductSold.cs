using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ApiWebCoderH.Models;

namespace ApiWebCoderH.Repositories
{
    public class RProductSold
    {
        public static ProductSold SelectProductSold(long id)
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from ProductoVendido where Id = @Id";
            ProductSold productSold = new ProductSold();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    productSold = ProductSold.GetProductSold(reader);
                    reader.Close();
                }
                connection.Close();
            }
            return productSold;
        }

        public static List<ProductSold> SelectProductsSold()
        {
            DBConnection newConnection = new DBConnection();
            string query = $"select * from ProductoVendido";
            List<ProductSold> productsSoldList = new List<ProductSold>();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection)) 
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            productsSoldList.Add(ProductSold.GetProductSold(reader));
                        }
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return productsSoldList;
        }

        public static int DeleteProductSold(long id)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Delete from ProductoVendido where Id = @Id";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }

        public static int InsertProductSold(ProductSold productSold)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Insert into ProductoVendido (Stock,IdProducto,IdVenta) " +
                "values (@Stock,@IdProducto,@IdVenta);";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productSold.Stock });
                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productSold.ProductId });
                    command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productSold.SaleId });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }

        public static int UpdateProductSold(ProductSold productSold)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Update ProductoVendido " +
                "set Stock = @Stock," +
                    "IdProducto = @IdProducto," +
                    "IdVenta = @IdVenta " +
                "where Id = @Id";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = productSold.Id });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = productSold.Stock });
                    command.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.BigInt) { Value = productSold.ProductId });
                    command.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.BigInt) { Value = productSold.SaleId });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }
    }
}
