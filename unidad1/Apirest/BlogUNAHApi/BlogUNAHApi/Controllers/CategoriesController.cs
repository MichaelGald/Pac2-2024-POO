using BlogUNAHApi.Database.Entities;
using BlogUNAHApi.Dtos.Categories;
using BlogUNAHApi.Services.Interdaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogUNAHApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesServices _categoriesServices;

        public CategoriesController(ICategoriesServices categoriesServices) 
        {
            this._categoriesServices = categoriesServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _categoriesServices.GetCategoriesListAsync());
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var category = await _categoriesServices.GetCategoryByIdAsync(id);

            if (category == null) 
            {
                return NotFound(new { Message = $"No se encontro la categoria: {id}"});
            }

            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult> Create(CategoryCreateDto dto) 
        {
            await _categoriesServices.CreateAsync(dto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(CategoryEditDto dto,Guid id) 
        {
            var result = await _categoriesServices.EditAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) 
        {
            var category = await _categoriesServices.GetCategoryByIdAsync(id);

            if (category is null )
            {
                return NotFound();
            }

            await _categoriesServices.DeleteAsync(id);
            return Ok();
        }
     }
}
