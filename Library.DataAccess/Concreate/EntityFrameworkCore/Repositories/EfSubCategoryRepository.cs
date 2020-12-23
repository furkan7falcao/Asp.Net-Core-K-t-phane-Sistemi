using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfSubCategoryRepository : EfGenericRepository<SubCategory>, ISubCategoryDAL
    {
        public async Task<List<SubCategory>> GetSubCategoriesOfBaseCategoryWithIdAsync(int id)
        {
            using var context = new ApplicationDbContext();

            return await context.SubCategory.Include(I => I.Category).Where(I => I.CategoryId == id).ToListAsync();
        }

        public async Task<SubCategory> GetSubCategoryWithIdAsync(int id)
        {
            using var context = new ApplicationDbContext();

            return await context.SubCategory.Where(I => I.Id == id).FirstOrDefaultAsync();
        }
    }
}
