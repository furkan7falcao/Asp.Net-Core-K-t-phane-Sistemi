using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface ISubCategoryService : IGenericService<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoriesOfBaseCategoryWithIdAsync(int id);
        Task<SubCategory> GetSubCategoryWithIdAsync(int id);


    }
}
