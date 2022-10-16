using System;
using System.Collections.Generic;
using System.Text;
using Repository.Pattern.Model;

namespace Repository.Pattern.Data
{
    internal interface IProductRepository : IRepository<Product>
    {
        internal int GetStockProduct();
    }
}
