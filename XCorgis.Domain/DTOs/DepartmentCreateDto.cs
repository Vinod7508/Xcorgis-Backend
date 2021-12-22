using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.DTOs
{
   public class DepartmentCreateDto
    {
       
        public string DepartmentName { get; set; }
        public string AdditionalInformation { get; set; }
        public bool isActive { get; set; }

    }
}
