using AutoMapper;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async void AddCategory(CreateCategoryDTO categoryDTO)
        {
            Category category = this.mapper.Map<Category>(categoryDTO);

            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
        }

        public ICollection<ListCategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}