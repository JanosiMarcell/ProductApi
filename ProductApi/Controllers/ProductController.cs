using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProductApi.Model;

namespace ProductApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private Connect conn = new();
        [HttpGet]
        public List<Product> Get() {
            List<Product> products = new();
            string sql="SELECT * FROM products";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            do
            {
                var result = new Product
                {
                    id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2),
                    CreatedTime = reader.GetDateTime(3)

                };
            }
            while (reader.Read());
            conn.Connection.Close();
            return products;
        }
        [HttpPost]
        public object Post(Product product)
        {
            conn.Connection.Open();
            string sql = $"INSERT INTO `products`(`id`, `Name`, `Price`, `CreatedTime`) VALUES ('{product.id}','{product.Name}','{product.Price}','{product.CreatedTime}')";
            MySqlCommand cmd=new MySqlCommand(sql,conn.Connection);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return new { message = "Új rekord felvéve" };
        }
    }
}
