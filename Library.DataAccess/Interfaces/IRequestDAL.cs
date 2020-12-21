using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface IRequestDAL : IGenericDAL<Request>
    {
        Task<List<Request>> getUnReadRequestsOfMemberAsync(int memberId);
        int getUnReadNotificationCount(int memberId);
        Task<List<Request>> GetAllUnReadRequestsAsync();
        Task<Request> GetSpecifyUnReadRequestAsync(Request request);
        Task<Request> GetRequestOfBookAsync(int bookId);




    }
}
