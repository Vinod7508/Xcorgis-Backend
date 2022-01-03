using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.Entities
{
   public class StockLocations
    {
        public int stocklocationcode { get; set; }
        public string locationName { get; set; }
        public bool isActive { get; set; }
    }
}
