using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDAL
    {
        public async Task<List<Category>> GetCategoriesWithSubCategoriesAsync()
        {
            var context = new ApplicationDbContext();
            return await context.Category.Include(I => I.SubCategories).ToListAsync();
        }

        public async Task<Category> GetCategoriesWithSubCategoriesUsingIdAsync(int id)
        {
            var context = new ApplicationDbContext();
            return await context.Category.Include(I => I.SubCategories).Where(I=>I.Id==id).FirstOrDefaultAsync();
        }
    }
}
