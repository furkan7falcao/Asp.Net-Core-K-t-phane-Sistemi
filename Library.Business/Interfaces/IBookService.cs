﻿using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IBookService : IGenericService<Book>
    {
        Task<MemberBook> IsNotReadSameBookBeforeAsync(MemberBook memberBook);
        Task<MemberBook> IsReadSameBookBeforeAsync(MemberBook memberBook);
        public List<DualHelper> GetMostReadBook();
        Task<List<MemberBook>> GetReadBooksOfMemberAsync(int memberId);
        Task AddMemberBookTableAsync(MemberBook memberBook);
        Task<Book> FindByNameAsync(string bookName);
        Task<MemberBook> GetMemberBookByBookIdAsync(int bookId, int memberId);
        Task UpdateMemberBookTableAsync(MemberBook memberBook);
        Task RemoveMemberBookTableAsync(MemberBook memberBook);
        Task<List<Book>> GetBooksOfAuthorAsync(int authorId);
        Task<List<MemberBook>> GetBooksOfMemberWithAllAsync(int memberId);
        Task<List<Book>> GetBooksWithAuthorsAsync();
        Task<List<Book>> GetBooksWithSubCategoryIdAsync(int id);
        Task<List<Book>> GetBooksWithBaseCategoryIdAsync(int id);
        Task<Book> GetBooksWithAllByIdAsync(int id);
        List<MemberBook> GetIndexPageBooks(out int toplamSayfa, string aranacakKelime, int aktifSayfa);
    }
}
