using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.DTOs
{
    public class ProductCreateDto
    {
        public string ProductDesc { get; set; }
        public double Price { get; set; }
        public bool Allow_Web_Sales { get; set; }
        public bool isActive { get; set; }
        public int DepartmentId { get; set; }
    }
}
