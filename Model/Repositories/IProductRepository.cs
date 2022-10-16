using NetCoreAPIMySQL.Core.Entities;

namespace NetCoreAPIMySQL.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public void SetDatabase();
        public int GetStockProduct();
    }
}
