using MySql.Data.MySqlClient;

namespace ProductApi.Model
{
    public class Connect
    {
        public MySqlConnection Connection;
        public string MysqlConnectionString;


        private string Host;
        private string Database;
        private string User;
        private string Password;

        public Connect()
        {
            Host= "localhost";
            Database = "shop";
            User= "root";
            Password= "";
        }
    }
}
