using Application.Common.Dto.Product;
using Application.Features.Products.Commands.CreateProduct;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
