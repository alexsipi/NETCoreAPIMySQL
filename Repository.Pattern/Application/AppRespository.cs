using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.Pattern.Application
{
    public class AppRepository
    {
        static string connectionString = "Server=localhost;User=root;Password=admin;GuidFormat=LittleEndianBinary16;SslMode=None;";
        static MySqlConnection connection = new MySqlConnection(connectionString);
  
        using(connection)
        {
            connection.Open();
            System.Console.WriteLine("Connection is " + connection.State.ToString());
        }
    }
}
