using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IAuthorService : IGenericService<Author>
    {
        Task<List<Author>> GetAuthorsWithBooksAsync();
    }
}
