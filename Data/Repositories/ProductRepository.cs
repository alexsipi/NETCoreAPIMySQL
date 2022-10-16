using NetCoreAPIMySQL.Core.Entities;
using NetCoreAPIMySQL.Core.Repositories;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ProductRepository(MySQLConfiguration connectionString) {
            _connectionString = connectionString;
            SetDatabase();
        }

        protected MySqlConnection dbConnection() {
            return new MySqlConnection(_connectionString.Connectionstring);
        }

        public void SetDatabase() {
            var db = dbConnection();
            db.Execute(@"CREATE DATABASE IF NOT EXISTS testdb");
            db.Execute("USE testdb");

            var query = @"CREATE TABLE IF NOT EXISTS products(
                        id INT PRIMARY KEY NOT NULL,
                        name TEXT NOT NULL,
                        price DECIMAL(5,2)
                    )";
            db.Execute(query);
        }

        public async Task<bool> Insert(Product product) {
            var db = dbConnection();
            var query = @"INSERT INTO products(id, name, price)
                        VALUES(@id, @name, @price)";
            var result = await db.ExecuteAsync(query, new { product.id, product.Name, product.Price });

            return result > 0;
        }

        public async Task<bool> Delete(int id) {
            var db = dbConnection();
            var query = @"DELETE FROM products WHERE id= @Id";
            var result = await db.ExecuteAsync(query, new { Id = id });

            return result > 0;
        }

        public async Task<Product> Get(int id) {
            var db = dbConnection();
            var query = @"SELECT id, name, price FROM products WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task<IEnumerable<Product>> GetAll() {
            var db = dbConnection();
            var query = @"SELECT id, name, price FROM products";
            return await db.QueryAsync<Product>(query);
        }

        public async Task<bool> Update(Product product) {
            var db = dbConnection();
            var query = @"UPDATE products SET name = @name, price = @price WHERE id = @Id";
            var result = await db.ExecuteAsync(query, new { product.Name, product.Price, product.id });

            return result > 0;
        }

        public async Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate) {
            var db = dbConnection();
            var query = @"SELECT id, name, price FROM products";
            return await db.QueryAsync<Product>(query);
        }

        public int GetStockProduct() {
            throw new NotImplementedException();
        }
    }
}
