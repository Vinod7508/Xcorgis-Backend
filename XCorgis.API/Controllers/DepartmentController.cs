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
        public IActionResult GetAllDepartment()
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

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentCreateDto newdepartment)
        {
            try
            {
                if (newdepartment == null)
                {
                    
                    return BadRequest("department object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var departmentEntity = _mapper.Map<Department>(newdepartment);
                _unitOfWork.Departments.Add(departmentEntity);
                _unitOfWork.Complete();

                var createddepartment = _mapper.Map<DepartmentDto>(departmentEntity);
                return Ok(createddepartment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{deptid}/products")]
        public IActionResult GetProductDetails(int deptid)
        {
            try
            {
                var department = _unitOfWork.Departments.GetAllDetailsofDepartment(deptid);
                if (department == null)
                {
                    return NotFound();
                }
                else
                {
                    var deptResult = _mapper.Map<DepartmentDto>(department);
                    return Ok(deptResult);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{Deptid}")]
        public IActionResult UpdateDepartment(int Deptid, [FromBody] DepartmentUpdateDto department)
        {
            try
            {
                if (department == null)
                {
                   
                    return BadRequest("Department object is null");
                }
                if (!ModelState.IsValid)
                {
                   
                    return BadRequest("Invalid model object");
                }
                var deptEntity = _unitOfWork.Departments.GetById(Deptid);
                if (deptEntity == null)
                {
                  
                    return NotFound();
                }
                _mapper.Map(department, deptEntity);
                _unitOfWork.Departments.Update(deptEntity);
                _unitOfWork.Complete();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }






        [HttpDelete("{deptid}")]
        public IActionResult DeleteDepartment(int deptid)
        {
            try
            {
                var department = _unitOfWork.Departments.GetById(deptid);
                if (department == null)
                {
                    return NotFound();
                }

                if (_unitOfWork.Products.ProductsByDepartment(deptid).Any())
                {
                    return BadRequest("Cannot delete department. It has related products. Delete those products first");
                }

                _unitOfWork.Departments.Remove(department);
                _unitOfWork.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, "Internal server error");
            }
        }



    }
}
