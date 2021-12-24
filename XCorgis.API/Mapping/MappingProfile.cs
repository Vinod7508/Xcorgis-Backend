using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCorgis.Domain.DTOs;
using XCorgis.Domain.Entities;

namespace XCorgis.API.Mapping
{
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto,Department>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();


        }
    }
}
