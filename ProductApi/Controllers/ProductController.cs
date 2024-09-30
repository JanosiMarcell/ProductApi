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
            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            return products;
        }
    }
}
