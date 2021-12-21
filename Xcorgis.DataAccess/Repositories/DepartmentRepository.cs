using System;
using System.Collections.Generic;
using System.Text;
using XCorgis.Domain.Entities;
using XCorgis.Domain.Interfaces;

namespace Xcorgis.DataAccess.Repositories
{
  public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {

        public DepartmentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
