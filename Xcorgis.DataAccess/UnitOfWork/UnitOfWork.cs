using System;
using System.Collections.Generic;
using System.Text;
using Xcorgis.DataAccess.Repositories;
using XCorgis.Domain.Interfaces;

namespace Xcorgis.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Departments = new DepartmentRepository(_context);
            Products = new ProductRepository(_context);

        }
        public IDepartmentRepository Departments { get; private set; }
        public IProductsRepository Products { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
