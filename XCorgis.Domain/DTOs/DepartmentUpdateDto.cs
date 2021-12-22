using System;
using System.Collections.Generic;
using System.Text;

namespace XCorgis.Domain.DTOs
{
  public class DepartmentUpdateDto
    {
        public string DepartmentName { get; set; }
        public string AdditionalInformation { get; set; }
        public bool isActive { get; set; }
    }
}
