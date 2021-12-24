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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _unitOfWork.Products.GetAll();
                var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);
                return Ok(productsResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("{Productid}")]
        public IActionResult GetProductById(int Productid)
        {
            try
            {
                var singleproduct = _unitOfWork.Products.GetById(Productid);
                if (singleproduct == null)
                {
                    return NotFound();
                }
                else
                {
                    var singleProductResult = _mapper.Map<ProductDto>(singleproduct);
                    return Ok(singleProductResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDto newproduct)
        {
            try
            {
                if (newproduct == null)
                {
                    return BadRequest("Product object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var productEntity = _mapper.Map<Product>(newproduct);
                _unitOfWork.Products.Add(productEntity);
                _unitOfWork.Complete();

                var createdproduct = _mapper.Map<ProductDto>(productEntity);
                return Ok(createdproduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpDelete("{prodid}")]
        public IActionResult DeleteProduct(int prodid)
        {
            try
            {
                var product = _unitOfWork.Products.GetById(prodid);
                if (product == null)
                {
                    return NotFound();
                }

                _unitOfWork.Products.Remove(product);
                _unitOfWork.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{ProdId}")]
        public IActionResult UpdateProduct(int ProdId, [FromBody] ProductUpdateDto product)
        {
            try
            {
                if (product == null)
                {

                    return BadRequest("Product object is null");
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest("Invalid model object");
                }
                //getting entity from dabatabase
                var productEntity = _unitOfWork.Products.GetById(ProdId);
                if (productEntity == null)
                {
                    return NotFound();
                }
                //mapping incoming productupdatedto to database record
                _mapper.Map(product , productEntity);
                _unitOfWork.Products.Update(productEntity);
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
