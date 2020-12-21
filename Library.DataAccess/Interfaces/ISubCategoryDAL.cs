using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface ISubCategoryDAL : IGenericDAL<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoriesOfBaseCategoryWithIdAsync(int id);
        Task<SubCategory> GetSubCategoryWithIdAsync(int id);


    }
}
