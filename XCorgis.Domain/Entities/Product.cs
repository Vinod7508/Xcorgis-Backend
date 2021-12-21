using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XCorgis.Domain.Entities
{
    [Table("Products")]
    public class Product
    {

        [Column("ProductCode")]
        public int ProductId { get; set; }
        public string ProductDesc { get; set; }
        public double Price { get; set; }
        public bool Allow_Web_Sales { get; set; }
        public bool isActive { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
