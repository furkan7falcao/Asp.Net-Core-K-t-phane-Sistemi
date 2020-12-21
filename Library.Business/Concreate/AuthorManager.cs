using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class AuthorManager : GenericManager<Author> , IAuthorService
    {
        private readonly IAuthorDAL _authorDAL;
        public AuthorManager(IAuthorDAL authorDAL) : base(authorDAL)
        {
            _authorDAL = authorDAL;
        }

        public async Task<List<Author>> GetAuthorsWithBooksAsync()
        {
            return await _authorDAL.GetAuthorsWithBooksAsync();
        }
    }
}
