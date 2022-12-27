using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ApiWebCoderH.Models;

namespace ApiWebCoderH.Repositories
{
    public class RSale
    {
        public static Sale SelectSale(long id)
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from Venta where Id = @Id";
            Sale sale = new Sale();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    sale = Sale.GetSale(reader);
                    reader.Close();
                }
                connection.Close();
            }
            return sale;
        }
        public static List<Sale> SelectSales()
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from Venta";
            List<Sale> salesList = new List<Sale>();
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
                            salesList.Add(Sale.GetSale(reader));
                        }
                    }
                }
                connection.Close();
            }
            return salesList;
        }

        public static int DeleteSale(long id)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Delete from Venta where Id = @Id";
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

        public static int InsertSale(Sale sale)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Insert into Venta (Comentarios) " +
                "values (@Comentarios);";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = sale.Comments });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }

        public static int UpdateSale(Sale sale)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Update Venta " +
                "set Comentarios = @Comentarios " +
                "where Id = @Id";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = sale.Id });
                    command.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = sale.Comments });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }
    }
}
