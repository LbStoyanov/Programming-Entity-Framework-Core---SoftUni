﻿using AutoMapper;
using FastFood.Data;
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
        public void AddCategory(CreateCategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public ICollection<ListCategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}