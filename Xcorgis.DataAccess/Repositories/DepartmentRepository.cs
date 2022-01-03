using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCorgis.Domain.Entities;
using XCorgis.Domain.Interfaces;

namespace Xcorgis.DataAccess.Repositories
{
  public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {

        public DepartmentRepository(ApplicationContext context) : base(context)
        {}



        public Department GetAllDetailsofDepartment(int deptid)
        {
            return  _context.Departments
                     .Where(b => b.Id.Equals(deptid))
                     .Include(b => b.Products).FirstOrDefault();
      
        }
    }
}
