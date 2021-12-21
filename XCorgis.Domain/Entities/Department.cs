using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XCorgis.Domain.Entities
{

    [Table("Departments")]
    public class Department
    {

        [Column("DepartmentId")]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string AdditionalInformation { get; set; }
        public bool isActive { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
