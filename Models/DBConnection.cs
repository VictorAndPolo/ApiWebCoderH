using System.Data;
using System.Data.SqlClient;

namespace ApiWebCoderH.Models
{
    public class DBConnection
    {
        private string Server { get; set; }
        private string DataBase { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public DBConnection()
        {
            Server = "sql.bsite.net\\MSSQL2016";
            DataBase = "DBcoderH#";
            UserName = "victorandpolo_#";
            Password= "Micasita123";
        }

        public SqlConnection Connect()
        {
            string connectionString = $"Server = {Server}; " +
                $"Database = {DataBase}; " +
                $"User Id = {UserName}; " +
                $"Password = {Password}";
            try
            {
                return new SqlConnection(connectionString);
            }
            catch
            {
                throw new Exception("The Data Base was unable to connect to SQL Serverd");
            }
        }
    }
}
