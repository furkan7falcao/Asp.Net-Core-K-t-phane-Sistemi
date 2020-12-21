using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class BookManager : GenericManager<Book> , IBookService
    {
        private readonly IBookDAL _bookDAL;
        public BookManager(IBookDAL bookDAL) : base(bookDAL)
        {
            _bookDAL = bookDAL;
        }

        public async Task<List<Book>> GetBooksOfAuthorAsync(int authorId)
        {
            return await _bookDAL.GetBooksOfAuthorAsync(authorId);
        }

        public async Task<List<Book>> GetBooksOfMemberWithAllAsync(int memberId)
        {
            return await _bookDAL.GetBooksOfMemberWithAllAsync(memberId);
        }

        public async Task<Book> GetBooksWithAllByIdAsync(int id)
        {
            return await _bookDAL.GetBooksWithAllByIdAsync(id);
        }

        public async Task<List<Book>> GetBooksWithAuthorsAsync()
        {
            return await _bookDAL.GetBooksWithAuthorsAsync();
        }

        public async Task<List<Book>> GetBooksWithBaseCategoryIdAsync(int id)
        {
            return await _bookDAL.GetBooksWithBaseCategoryIdAsync(id);
        }

        public async Task<List<Book>> GetBooksWithSubCategoryIdAsync(int id)
        {
            return await _bookDAL.GetBooksWithSubCategoryIdAsync(id);
        }

        public List<Book> GetIndexPageBooks(out int toplamSayfa, string aranacakKelime, int aktifSayfa)
        {
            return _bookDAL.GetIndexPageBooks(out toplamSayfa, aranacakKelime, aktifSayfa);
        }
    }
}
