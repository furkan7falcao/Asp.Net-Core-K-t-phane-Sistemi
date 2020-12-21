using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface IBookDAL : IGenericDAL<Book>
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
