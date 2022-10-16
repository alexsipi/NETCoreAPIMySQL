using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Repository.Pattern.Domain;
using Repository.Pattern.Model;

namespace Repository.Pattern.Data
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        internal MyContext MyContext
        {
            get { return Context as MyContext}
        }

        internal ProductRepository(MyContext context)
            : base(context) { }

        internal int GetStockProduct() {
            return 0;
        }
    }
}
