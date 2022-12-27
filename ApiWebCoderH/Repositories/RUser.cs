using Microsoft.AspNetCore.Hosting.Server;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ApiWebCoderH.Models;

namespace ApiWebCoderH.Repositories
{
    public class RUser
    {
        public static User LogIn(string userName, string password)
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from Usuario " +
                "where NombreUsuario = @NombreUsuario " +
                "and Contraseña = @Contraseña";
            User user = new User();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = userName });
                    sqlCommand.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = password });
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    user = User.GetUser(reader);
                    reader.Close();
                }
                connection.Close();
            }
            return user;
        }

        public static User SelectUser(long id)
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from Usuario where Id = @Id";
            User user = new User();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = id });
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    user = User.GetUser(reader);
                    reader.Close();
                }
                connection.Close();
            }
            return user;
        }

        public static User SelectUsername(string username)
        {
            DBConnection newConnection = new DBConnection();
            string query = "select * from Usuario where NombreUsuario = @NombreUsuario";
            User user = new User();
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = username });
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    reader.Read();
                    user = User.GetUser(reader);
                    reader.Close();
                }
                connection.Close();
            }
            return user;
        }
        public static List<User> SelectUsers() 
        {
            DBConnection newConnection = new DBConnection();
            string query = $"select * from Usuario";
            List<User> userList = new List<User>();
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
                            userList.Add(User.GetUser(reader));
                        }

                    }
                    reader.Close();
                }
                connection.Close();
            }
            return userList;
        }

        public static int DeleteUser(long id) {
            DBConnection newConnection = new DBConnection();
            string query = "Delete from Usuario where Id = @Id";
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

        public static int InsertUser(User user)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Insert into Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) " +
                "values (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail);";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = user.Name });
                    command.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = user.LastName });
                    command.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = user.UserName });
                    command.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = user.Password });
                    command.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = user.Mail });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }

        public static int UpdateUser(User user)
        {
            DBConnection newConnection = new DBConnection();
            string query = "Update Usuario " +
                "set Nombre = @Nombre," +
                    "Apellido = @Apellido," +
                    "NombreUsuario = @NombreUsuario, " +
                    "Contraseña = @Contraseña," +
                    "Mail = @Mail " +
                "where Id = @Id";
            int rowsAffected;
            using (SqlConnection connection = newConnection.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = user.Id });
                    command.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = user.Name });
                    command.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = user.LastName });
                    command.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = user.UserName });
                    command.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = user.Password });
                    command.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = user.Mail });
                    rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
            return rowsAffected;
        }
    }
}
