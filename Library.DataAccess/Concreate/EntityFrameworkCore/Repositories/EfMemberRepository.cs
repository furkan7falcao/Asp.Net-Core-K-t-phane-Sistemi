using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfMemberRepository : EfGenericRepository<Member>, IMemberDAL
    {
        public async Task<int> GetCurrentBookCountAsync(int memberId)
        {
            var context = new ApplicationDbContext();
            return await context.MemberBook.Where(I => I.Member.Id == memberId && I.isRead == false).CountAsync();
        }

        public async Task<int> GetReadBookCountAsync(int memberId)
        {
            var context = new ApplicationDbContext();
            return await context.MemberBook.Where(I => I.Member.Id == memberId && I.isRead == true).CountAsync();
        }
    }
}
