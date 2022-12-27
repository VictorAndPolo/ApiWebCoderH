using System.Data.SqlClient;

namespace ApiWebCoderH.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public string Comments { get; set; }

        public Sale() { }

        public Sale(string comments)
        {
            Comments = comments;
        }

        public Sale(long id, string comments)
        {
            Id = id;
            Comments = comments;
        }

        public static Sale GetSale(SqlDataReader reader)
        {
            Sale sale = new Sale();
            sale.Id = Convert.ToInt64(reader["Id"]);
            sale.Comments = reader["Comentarios"].ToString();

            return sale;
        }
    }
}
