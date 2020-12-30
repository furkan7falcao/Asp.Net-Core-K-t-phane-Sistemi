using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfBookRepository : EfGenericRepository<Book>, IBookDAL
    {
        public List<DualHelper> GetMostReadBook()
        {
            var context = new ApplicationDbContext();
            return context.MemberBook.Include(I => I.Book).Where(I => I.isRead == true && I.Member != null)
                .GroupBy(I => I.Book.Name).OrderByDescending(I => I.Count()).Take(3).Select(I => new DualHelper
                {
                    Name = I.Key,
                    NumberOfBooks = I.Count()
                }).ToList();
        }

        public async Task<Book> FindByNameAsync(string bookName)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Where(I => I.Name == bookName).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBooksOfAuthorAsync(int authorId)
        {
            var context = new ApplicationDbContext();
            return await context.Book.Include(I => I.Author).Where(I => I.AuthorId == authorId).ToListAsync();
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
        

        public async Task<MemberBook> GetMemberBookByBookIdAsync(int bookId)
        {
            var context = new ApplicationDbContext();
            return await context.MemberBook.Where(I => I.BookId == bookId).FirstOrDefaultAsync();
        }

        public async Task<List<MemberBook>> GetBooksOfMemberWithAllAsync(int memberId)
        {
            var context = new ApplicationDbContext();
            //return await context.Book.Include(I=>I.Requests).Include(I=>I.Author).Include(I=>I.BaseCategory).Include(I => I.SubCategory).Where(I => I.MemberId == memberId).ToListAsync();
            return await context.MemberBook.Include(I => I.Book).ThenInclude(I => I.Requests)
                                            .Include(I => I.Book).ThenInclude(I => I.Author)
                                            .Include(I => I.Book).ThenInclude(I => I.BaseCategory)
                                            .Include(I => I.Book).ThenInclude(I => I.SubCategory)
                                            .Where(I => I.Member.Id == memberId && I.isRead == false).ToListAsync();
        }


        public async Task<List<MemberBook>> GetReadBooksOfMemberAsync(int memberId)
        {
            var context = new ApplicationDbContext();
            return await context.MemberBook.Include(I => I.Book).ThenInclude(I => I.Requests)
                                            .Include(I => I.Book).ThenInclude(I => I.Author)
                                            .Include(I => I.Book).ThenInclude(I => I.BaseCategory)
                                            .Include(I => I.Book).ThenInclude(I => I.SubCategory)
                                            .Where(I => I.Member.Id == memberId && I.isRead == true).ToListAsync();
        }
        public async Task AddMemberBookTableAsync(MemberBook memberBook)
        {
            var context = new ApplicationDbContext();
            await context.MemberBook.AddAsync(memberBook);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMemberBookTableAsync(MemberBook memberBook)
        {
            var context = new ApplicationDbContext();
            context.Set<MemberBook>().Update(memberBook);
            await context.SaveChangesAsync();
        }

        public List<MemberBook> GetIndexPageBooks(out int toplamSayfa, string aranacakKelime, int aktifSayfa)
        {
            var context = new ApplicationDbContext();

            var result = context.MemberBook.Include(I => I.Book).ThenInclude(I => I.BaseCategory)
                                            .Include(I => I.Book).ThenInclude(I => I.SubCategory)
                                            .Include(I => I.Book).ThenInclude(I => I.Author)
                                            .Where(I => I.MemberId == null).AsQueryable();


            toplamSayfa = (int)Math.Ceiling((double)result.Count() / 6);

            if (!String.IsNullOrWhiteSpace(aranacakKelime))
            {
                result = result.Where(I => I.Book.Author.FullName.ToLower().Contains(aranacakKelime.ToLower()) ||
                    I.Book.Name.ToLower().Contains(aranacakKelime.ToLower()) ||
                    I.Book.BaseCategory.Name.ToLower().Contains(aranacakKelime.ToLower()) ||
                    I.Book.SubCategory.Name.ToLower().Contains(aranacakKelime.ToLower()));

                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 6);
            }

            result = result.Skip((aktifSayfa - 1) * 6).Take(6);

            return result.ToList();
        }


    }
}

