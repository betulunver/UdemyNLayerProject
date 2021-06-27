﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Entities;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        //api/products şeklinde get isteği atarsak buraya düşecektir. best practice açısından entity isimleri olmalı 
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto ProductDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(ProductDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(product));
        }
        [HttpPut]
        public IActionResult Update(ProductDto ProductDto)
        {
            var product = _productService.Update(_mapper.Map<Product>(ProductDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByProductId(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }
    }
}
