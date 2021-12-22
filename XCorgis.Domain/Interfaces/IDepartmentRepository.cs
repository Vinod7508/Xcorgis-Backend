using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCorgis.Domain.Entities;

namespace XCorgis.Domain.Interfaces
{
   public interface IDepartmentRepository : IGenericRepository<Department>
    {
        //GET all details of single department

        Department GetAllDetailsofDepartment(int deptid);
    }
}
