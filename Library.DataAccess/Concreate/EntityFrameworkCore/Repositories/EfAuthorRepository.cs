using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfAuthorRepository : EfGenericRepository<Author>, IAuthorDAL
    {
        public async Task<List<Author>> GetAuthorsWithBooksAsync()
        {
            var context = new ApplicationDbContext();
            return await context.Author.Include(I => I.Books).ToListAsync();
        }
    }
}
