using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class SubCategoryManager : GenericManager<SubCategory> , ISubCategoryService
    {
        private readonly ISubCategoryDAL _subCategoryDAL;
        public SubCategoryManager(ISubCategoryDAL subCategoryDAL) : base(subCategoryDAL)
        {
            _subCategoryDAL = subCategoryDAL;
        }

        public async Task<List<SubCategory>> GetSubCategoriesOfBaseCategoryWithIdAsync(int id)
        {
            return await _subCategoryDAL.GetSubCategoriesOfBaseCategoryWithIdAsync(id);
        }

        public async Task<SubCategory> GetSubCategoryWithIdAsync(int id)
        {
            return await _subCategoryDAL.GetSubCategoryWithIdAsync(id);
        }
    }
}
