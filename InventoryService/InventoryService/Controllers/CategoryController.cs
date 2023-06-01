using InventoryService.Auth;
using InventoryService.Models;
using InventoryService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    //[Authorize(Roles = Roles.Admin)]
    //[Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    // [ApiVersion("1.1")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }



        // GET: api/<CategoryController>
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryRepo.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{Id}")]
        public async Task<Category> Get(int Id)
        {
            return await _categoryRepo.GetCategoryById(Id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category Category)
        {
            await _categoryRepo.AddCategory(Category);
            return CreatedAtAction(nameof(Get),
                         new { id = Category.CategoryId }, Category);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] string CategoryName)
        {
            var result = await _categoryRepo.UpdateCategory(Id, CategoryName);
            return CreatedAtAction(nameof(Get),
                         new { id = result.CategoryId }, result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await _categoryRepo.DeleteCategory(Id))
                return new OkResult();
            else
                return new BadRequestResult();
        }
    }
}