using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<List<Category>> GetCategoriesWithSubCategoriesAsync();
        Task<Category> GetCategoriesWithSubCategoriesUsingIdAsync(int id);
    }
}
