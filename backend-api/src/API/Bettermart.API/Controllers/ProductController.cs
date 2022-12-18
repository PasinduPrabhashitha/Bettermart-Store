﻿using Bettermart_Application.DTOs.Products;
using Bettermart_Application.Features.Products.Commands;
using Bettermart_Application.Features.Products.Queries;
using Bettermart_Application.Responses;
using MediatR; 
using Microsoft.AspNetCore.Mvc;

namespace Bettermart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<BaseResponse<List<GetProductDto>>> GetProducts()
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return products;
        }

        [HttpGet("{productId}")] 
        public async Task<BaseResponse<GetProductDto>> GetProductById(string productId)
        {
            var product = await _mediator.Send(new GetProductQuery { ProductId = productId});
            return product;
        }

        [HttpPost]
        public async Task<BaseResponse<List<GetProductDto>>> CreateProduct(CreateProductDto product)
        {
            var products = await _mediator.Send(new CreateProductCommand { Product = product});
            return products;
        }
    }
}
