using FastFood.Services.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(CreateCategoryDTO categoryDTO);

        ICollection<ListCategoryDTO> GetAll();
    }
}
