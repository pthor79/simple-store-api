using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Api.Contracts;
using SimpleStore.Api.Data;
using SimpleStore.Api.Models;

namespace SimpleStore.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IMapper mapper, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDto>>> GetProducts()
        {
            var products = await _productsRepository.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<GetProductDto>>(products);

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productsRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<GetProductDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);

            try
            {
                await _productsRepository.AddAsync(product);

                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto updateProductDto)
        {

            if (id != updateProductDto.Id)
            {
                return BadRequest();
            }

            var foundProduct = await _productsRepository.GetByIdAsync(id);

            if (foundProduct is null)
            {
                return NotFound();
            }

            _mapper.Map(updateProductDto, foundProduct);

            try
            {
                await _productsRepository.UpdateAsync(foundProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private async Task<bool> ProductExists(int id)
        {
            return await _productsRepository.Exists(id);
        }
    }
}
