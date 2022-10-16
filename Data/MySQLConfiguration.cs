
namespace NetCoreAPIMySQL.Data
{
    public class MySQLConfiguration
    {
        public string Connectionstring { get; set; }

        public MySQLConfiguration(string connectionstring) {
            Connectionstring = connectionstring;
        }
    }
}
