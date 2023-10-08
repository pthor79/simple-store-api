using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Api.Contracts;
using SimpleStore.Api.Models;

namespace SimpleStore.Api.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {       
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {           
            _productsRepository = productsRepository;
        }

        /// <summary>
        /// Returns a paged list of products
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResult<GetProductDto>>> GetPagedProducts([FromQuery] QueryParameters queryParameters)
        {
            var pagedProductsResult = await _productsRepository.GetAllAsync<GetProductDto>(queryParameters);
            return Ok(pagedProductsResult);
        }
    }
}
