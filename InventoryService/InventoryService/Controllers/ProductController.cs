using InventoryService.Models;
using InventoryService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/<ProductController>
        [HttpGet]
        // [MapToApiVersion("2.0")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepo.GetProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{Id}")]
        public async Task<Product> Get(int Id)
        {
            return await _productRepo.GetProduct(Id);
        }

        // POST api/<ProductController>
        [HttpPost("{Id}")]
        public async Task<IActionResult> Post(long Id, [FromBody] Product Product)
        {
            await _productRepo.AddProduct(Product, Id);
            return CreatedAtAction(nameof(Get),
                         new { id = Product.ProductId }, Product);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] long Cost)
        {
            var result = await _productRepo.UpdateProduct(Id, Cost);
            return CreatedAtAction(nameof(Get),
                         new { id = result.ProductId }, result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await _productRepo.DeleteProduct(Id))
                return new OkResult();
            else
                return new BadRequestResult();
        }

    }
}