using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IRequestService : IGenericService<Request>
    {
        Task<List<Request>> getUnReadRequestsOfMemberAsync(int memberId);
        int getUnReadNotificationCount(int memberId);
        Task<List<Request>> GetAllUnReadRequestsAsync();
        Task<Request> GetSpecifyUnReadRequestAsync(Request request);
        Task<Request> GetRequestOfBookAsync(int bookId);





    }
}
