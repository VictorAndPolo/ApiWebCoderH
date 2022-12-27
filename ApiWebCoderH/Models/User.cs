using System.Data.SqlClient;

namespace ApiWebCoderH.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Mail { get; set; }

        public User() { }

        public User(string name, string lastName, string userName, string password, string mail)
        {
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Mail = mail;
        }

        public User(long id, string name, string lastName, string userName, string password, string mail)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Mail = mail;
        }

        public static User GetUser(SqlDataReader reader)
        {
            User user = new User();
            user.Id = Convert.ToInt64(reader["Id"]);
            user.Name = reader["Nombre"].ToString();
            user.LastName = reader["Apellido"].ToString();
            user.UserName = reader["NombreUsuario"].ToString();
            user.Password = reader["Contraseña"].ToString();
            user.Mail = reader["Mail"].ToString();

            return user;
        }
    }
}
