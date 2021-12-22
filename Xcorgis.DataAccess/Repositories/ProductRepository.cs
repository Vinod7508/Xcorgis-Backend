using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCorgis.Domain.Entities;
using XCorgis.Domain.Interfaces;

namespace Xcorgis.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        { }
        public IEnumerable<Product> ProductsByDepartment(int productid)
        {
            return Find(a => a.ProductId.Equals(productid)).ToList();
        }
    }
}
