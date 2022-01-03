using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.Entities
{
    public class Stock
    {
        public int id { get; set; }
        public int stock_Location_Code { get; set; }
        public int stock_item_id { get; set; }
        public int Availablestockcount { get; set; }

        //this field will decreased with order
        public int allocated_stock { get; set; }
    }
}
