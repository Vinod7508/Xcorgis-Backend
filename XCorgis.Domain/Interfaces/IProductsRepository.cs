using System;
using System.Collections.Generic;
using System.Text;
using XCorgis.Domain.Entities;

namespace XCorgis.Domain.Interfaces
{
   public interface IProductsRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> ProductsByDepartment(int productid);

    }
}
