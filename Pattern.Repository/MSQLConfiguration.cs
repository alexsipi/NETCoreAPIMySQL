namespace Pattern.Repository
{
    public class MSQLConfiguration
    {
        public string connectionString { get; set; }

        public MSQLConfiguration(string connectionString) => this.connectionString = connectionString;
    }
}
