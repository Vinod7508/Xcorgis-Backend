using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.DTOs
{
   public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductDesc { get; set; }
        public double Price { get; set; }
        public bool Allow_Web_Sales { get; set; }
        public bool isActive { get; set; }
    }
}
