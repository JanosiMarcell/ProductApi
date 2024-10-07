using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProductApi.Model;
using static ProductApi.DTOs.Dto;

namespace ProductApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private Connect conn = new();

        [HttpGet]
        public List<Product> Get()
        {
            List<Product> products = new();
            string sql = "SELECT * FROM products";

            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            do
            {
                var result = new Product
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2),
                    CreatedTime = reader.GetDateTime(3)
                };

                products.Add(result);
            }
            while (reader.Read());

            conn.Connection.Close();

            return products;
        }

        [HttpPost]
       public ActionResult<Product> Post(CreateProductDto product)
        {
            var result = new Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price=product.Price,
                CreatedTime=DateTime.Now
            };
            string sql = $"INSERT INTO `products`(`id`, `Name`, `Price`, `CreatedTime`) VALUES ('{result.Id}','{result.Name}','{result.Price}','{result.CreatedTime}')";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            conn.Connection.Close() ;
            return StatusCode(281,result);
        }
    }
}
