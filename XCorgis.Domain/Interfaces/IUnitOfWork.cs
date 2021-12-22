using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Departments { get; }
        IProductsRepository Products { get; }
        int Complete();
    }
}
