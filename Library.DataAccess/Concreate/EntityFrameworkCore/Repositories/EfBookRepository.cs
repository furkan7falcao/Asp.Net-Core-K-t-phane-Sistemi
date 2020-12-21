using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using OurProject.LibrarySystem.DataAccess.Concreate.EntityFrameworkCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfBookRepository : EfGenericRepository<Book>, IBookDAL
    {
        public async Task<List<Book>> GetBooksOfAuthorAsync(int authorId)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I => I.Author).Where(I => I.AuthorId == authorId).ToListAsync();
        }

        public async Task<List<Book>> GetBooksOfMemberWithAllAsync(int memberId)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I=>I.Requests).Include(I=>I.Author).Include(I=>I.BaseCategory).Include(I => I.SubCategory).Where(I => I.MemberId == memberId).ToListAsync();
        }

        public async Task<Book> GetBooksWithAllByIdAsync(int id)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I => I.Author).Include(I => I.SubCategory).Include(I => I.BaseCategory).Where(I => I.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBooksWithAuthorsAsync()
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I => I.Author).ToListAsync();
        }

        public async Task<List<Book>> GetBooksWithBaseCategoryIdAsync(int BaseCategoryId)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I => I.BaseCategory).Where(I => I.BaseCategoryId == BaseCategoryId).ToListAsync();
        }

        public async Task<List<Book>> GetBooksWithSubCategoryIdAsync(int SubCategoryId)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I => I.SubCategory).Where(I => I.SubCategoryId == SubCategoryId).ToListAsync();
        }       

        public List<Book> GetIndexPageBooks(out int toplamSayfa, string aranacakKelime, int aktifSayfa)
        {
            var context = new ApplicationDbContext();

            var result = context.Book.Include(I=>I.Author).Include(I=>I.BaseCategory).Include(I=>I.SubCategory).Where(I=>I.MemberId == 1).AsQueryable();

            toplamSayfa = (int)Math.Ceiling((double)result.Count() / 6);

            if (!String.IsNullOrWhiteSpace(aranacakKelime))
            {
                result = result.Where(I => I.Author.FullName.ToLower().Contains(aranacakKelime.ToLower()) ||
                    I.Name.ToLower().Contains(aranacakKelime.ToLower()) ||
                    I.BaseCategory.Name.ToLower().Contains(aranacakKelime.ToLower()) ||
                    I.SubCategory.Name.ToLower().Contains(aranacakKelime.ToLower()));

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 6);
            }

            result = result.Skip((aktifSayfa - 1) * 6).Take(6);

            return result.ToList();
        }
    }
}

