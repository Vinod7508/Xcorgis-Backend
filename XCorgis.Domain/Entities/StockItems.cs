using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.Entities
{
   public class StockItems
    {
        public int id { get; set; }
        public int product_code { get; set;}
        public int Stockitemcode { get; set; }
        public char barcode { get; set; }
    }
}
