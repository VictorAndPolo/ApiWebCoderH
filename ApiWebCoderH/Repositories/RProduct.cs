using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ApiWebCoderH.Models;

namespace ApiWebCoderH.Repositories
{
    public class RProduct
    {
        public static List<Product> SelectProduct(long userId)
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from Producto where idUsuario = @idUsuario";
            List<Product> productsList = new List<Product>();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("idUsuario", SqlDbType.BigInt) { Value = userId });
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            productsList.Add(Product.GetProduct(reader));
                        }
                    }
                    reader.Close();
                }
                connection.Close();
            }   
            return productsList;
        }

        public static List<Product> SelectProducts()
        {
            DBConnection newConnection = new DBConnection();
            string query = $"select * from Producto";
            List<Product> productsList = new List<Product>();
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
                            productsList.Add(Product.GetProduct(reader));
                        }
                    }
                    reader.Close();
                }
                connection.Close();
            }
            return productsList;
        }

        public static int DeleteProduct(long id)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Delete from Producto where Id = @Id";
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

        public static int InsertProduct(Product product)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Insert into Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) " +
                "values (@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario);";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = product.Description });
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = product.Cost });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = product.SalePrice });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = product.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = product.UserID });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }

        public static int UpdateProduct(Product product)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Update Producto " +
                "set Descripciones = @Descripciones," +
                    "Costo = @Costo," +
                    "PrecioVenta = @PrecioVenta, " +
                    "Stock = @Stock," +
                    "IdUsuario = @IdUsuario " +
                "where Id = @Id";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = product.Id });
                    command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = product.Description });
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = product.Cost });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = product.SalePrice });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = product.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = product.UserID });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }
    }
}
