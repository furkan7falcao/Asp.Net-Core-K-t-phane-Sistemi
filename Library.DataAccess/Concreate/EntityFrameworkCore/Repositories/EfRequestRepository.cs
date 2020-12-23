using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfRequestRepository : EfGenericRepository<Request>, IRequestDAL
    {
        public async Task<List<Request>> GetAllUnReadRequestsAsync()
        {
            var context = new ApplicationDbContext();
            return await context.Request.Where(I =>I.State).ToListAsync();
        }

        public async Task<Request> GetSpecifyUnReadRequestAsync(Request request)
        {
            var context = new ApplicationDbContext();
            return await context.Request.Include(I=>I.PosterMember).Include(I=>I.WantedBook).Where(I => I.WantedBookId == request.WantedBookId || I.PosterMemberId == request.PosterMemberId).FirstOrDefaultAsync();
        }

        public async Task<List<Request>> getUnReadRequestsOfMemberAsync(int receiverMemberId)
        {
            var context = new ApplicationDbContext();
            return await context.Request.Where(I => I.ReceiverMemberId == receiverMemberId && I.State).ToListAsync();
        }

        public int getUnReadNotificationCount(int receiverMemberId)
        {
            var context = new ApplicationDbContext();
            return context.Request.Where(I => I.ReceiverMemberId == receiverMemberId && I.State).Count();
        }

        public async Task<Request> GetRequestOfBookAsync(int bookId)
        {
            var context = new ApplicationDbContext();
            return await context.Request.Include(I=>I.WantedBook).Where(I => I.WantedBookId == bookId).FirstOrDefaultAsync();
        }
    }
}
