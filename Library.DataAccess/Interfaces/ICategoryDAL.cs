using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface ICategoryDAL : IGenericDAL<Category>
    {
        Task<List<Category>> GetCategoriesWithSubCategoriesAsync();
        Task<Category> GetCategoriesWithSubCategoriesUsingIdAsync(int id);

    }
}
