using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IBookService : IGenericService<Book>
    {
        public List<DualHelper> GetMostReadBook();
        Task<Book> FindByNameAsync(string bookName);
        Task<List<Book>> GetBooksOfAuthorAsync(int authorId);
        Task<List<Book>> GetBooksWithAuthorsAsync();
        Task<List<Book>> GetBooksWithSubCategoryIdAsync(int id);
        Task<List<Book>> GetBooksWithBaseCategoryIdAsync(int id);
        Task<Book> GetBooksWithAllByIdAsync(int id);
        Task<List<MemberBook>> GetReadBooksOfMemberAsync(int memberId);
        Task<MemberBook> GetMemberBookByBookIdAsync(int bookId);
        Task<List<MemberBook>> GetBooksOfMemberWithAllAsync(int memberId);
        Task AddMemberBookTableAsync(MemberBook memberBook);
        Task UpdateMemberBookTableAsync(MemberBook memberBook);
        List<MemberBook> GetIndexPageBooks(out int toplamSayfa, string aranacakKelime, int aktifSayfa);






    }
}
