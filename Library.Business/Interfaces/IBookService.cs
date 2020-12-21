using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IBookService : IGenericService<Book>
    {
        Task<List<Book>> GetBooksOfAuthorAsync(int authorId);
        Task<List<Book>> GetBooksOfMemberWithAllAsync(int memberId);
        Task<List<Book>> GetBooksWithAuthorsAsync();
        Task<List<Book>> GetBooksWithSubCategoryIdAsync(int id);
        Task<List<Book>> GetBooksWithBaseCategoryIdAsync(int id);
        Task<Book> GetBooksWithAllByIdAsync(int id);
        List<Book> GetIndexPageBooks(out int toplamSayfa, string aranacakKelime, int aktifSayfa);






    }
}
