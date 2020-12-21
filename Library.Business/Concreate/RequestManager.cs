using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class RequestManager : GenericManager<Request> , IRequestService
    {
        private readonly IRequestDAL _notificationDAL;
        public RequestManager(IRequestDAL notificationDAL) : base(notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }

        public async Task<List<Request>> GetAllUnReadRequestsAsync()
        {
            return await _notificationDAL.GetAllUnReadRequestsAsync();
        }

        public async Task<Request> GetSpecifyUnReadRequestAsync(Request request)
        {
            return await _notificationDAL.GetSpecifyUnReadRequestAsync(request);
        }

        public async Task<List<Request>> getUnReadRequestsOfMemberAsync(int memberId)
        {
            return await _notificationDAL.getUnReadRequestsOfMemberAsync(memberId);
        }

        public int getUnReadNotificationCount(int memberId)
        {
            return _notificationDAL.getUnReadNotificationCount(memberId);
        }

        public async Task<Request> GetRequestOfBookAsync(int bookId)
        {
            return await _notificationDAL.GetRequestOfBookAsync(bookId);
        }
    }
}
