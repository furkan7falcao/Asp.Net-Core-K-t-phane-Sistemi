using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class CategoryManager : GenericManager<Category> , ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL) : base(categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public async Task<List<Category>> GetCategoriesWithSubCategoriesAsync()
        {
            return await _categoryDAL.GetCategoriesWithSubCategoriesAsync();
        }

        public async Task<Category> GetCategoriesWithSubCategoriesUsingIdAsync(int id)
        {
            return await _categoryDAL.GetCategoriesWithSubCategoriesUsingIdAsync(id);
        }
    }
}
