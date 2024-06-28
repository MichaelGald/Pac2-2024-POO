using BlogUNAHApi.Database.Entities;
using BlogUNAHApi.Dtos.Categories;
using BlogUNAHApi.Services.Interdaces;
using Newtonsoft.Json;

namespace BlogUNAHApi.Services
{
    public class CategoriesService : ICategoriesServices
    {
        public readonly string _JSON_FILE;

        public CategoriesService() 
        {
            _JSON_FILE = "seedData/categories.json";
        }
        public async Task<List<CategoryDto>> GetCategoriesListAsync()
        {
            return await ReadCategoriesFromFileAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
           var categories = await ReadCategoriesFromFileAsync();
            CategoryDto category = categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public async Task<bool> CreateAsync(CategoryCreateDto dto)
        {
            var categoriesDtos = await ReadCategoriesFromFileAsync();

            var categoryDto = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
            };

            categoriesDtos.Add(categoryDto);

            var categories = categoriesDtos.Select(x => new CategoryEntity
            {
                Id= x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);
            return true;
        }

        public async Task<bool> EditAsync(CategoryEditDto dto, Guid id)
        {
            var categoriesDto = await ReadCategoriesFromFileAsync();
            var existingCategory = categoriesDto.FirstOrDefault(category => category.Id == id);
            if (existingCategory is null) 
            {
                return false;
            }

            //TODO: Recorrer las cetgorias y actualizar la correspodiente de la lista
            for (int i = 0; i < categoriesDto.Count; i++)
            {
                if (categoriesDto[i].Id == id)
                {
                    categoriesDto[i].Name = dto.Name;
                    categoriesDto[i].Description = dto.Description;
                }
            }

            var categories = categoriesDto.Select(x => new CategoryEntity
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoriesDto = await ReadCategoriesFromFileAsync();
            var categoriesToDelete = categoriesDto.FirstOrDefault(x => x.Id == id);
            if (categoriesToDelete is null)
            {
                return false;
            }
            categoriesDto.Remove(categoriesToDelete);
            var categories = categoriesDto.Select(x => new CategoryEntity
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            await WriteCategoriesToFileAsync(categories);
            return true;
        }

        private async Task<List<CategoryDto>> ReadCategoriesFromFileAsync() 
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<CategoryDto>();
            }
           var json = await File.ReadAllTextAsync(_JSON_FILE);
           var categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(json);
            var dtos = categories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            return dtos; 
        }

        private async Task WriteCategoriesToFileAsync(List<CategoryEntity> categories)
        {
            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
         
            if (File.Exists(_JSON_FILE))
            {
                await File.WriteAllTextAsync(_JSON_FILE, json);
            }
        }

    }
}
