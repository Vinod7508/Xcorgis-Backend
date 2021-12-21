using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCorgis.Domain.DTOs;
using XCorgis.Domain.Entities;
using XCorgis.Domain.Interfaces;

namespace XCorgis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetDepartmentNames()
        {
            try
            {
                var deptnames = _unitOfWork.Departments.GetAll();
                var deptnamesResult = _mapper.Map<IEnumerable<DepartmentDto>>(deptnames);
                return Ok(deptnamesResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("{Deptid}")]

        public IActionResult GetDepartmentById(int Deptid)
        {
            try
            {
                var dept = _unitOfWork.Departments.GetById(Deptid);
                if (dept == null)
                {
                    return NotFound();
                }
                else
                {
                    var deptnamesResult = _mapper.Map<DepartmentDto>(dept);
                    return Ok(deptnamesResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }



    }
}
