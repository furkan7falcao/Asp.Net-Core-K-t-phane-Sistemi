using Library.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface IAuthorDAL : IGenericDAL<Author>
    {
        Task<List<Author>> GetAuthorsWithBooksAsync();
    }
}
