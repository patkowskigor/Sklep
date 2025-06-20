using Azure;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shop.Library.Models;
using Shop.Library.Responses;
using System.Diagnostics.Eventing.Reader;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync() => Ok(await productService.GetProductsAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {

            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound("Product not found");
            else
                return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse>> DeleteProducASync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(product);

            var response = await productService.DeleteProductAsync(product.Id);
            return Ok(response);

        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse>> UpdateProductAsync(Product product)
        {
            var result = await productService.GetProductByIdAsync(product.Id);
            if (result == null)
                return NotFound("Product not found");

            var response = await productService.UpdateProductAsync(product);
            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProductAsync(Product product)
        {
            if (product is null)
                return BadRequest("Bad request");

            var result = await productService.AddProductAsync(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }

}

