using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public List<DualHelper> GetFiveMembersMostActive()
        {
            var context = new ApplicationDbContext();
            return context.MemberBook.Include(I => I.Member).Where(I => I.Member != null)
                .GroupBy(I => I.Member.FullName).OrderByDescending(I => I.Count()).Take(3).Select(I => new DualHelper
                {
                    Name = I.Key,
                    NumberOfBooks = I.Count()
                }).ToList();
        }

        public List<DualHelper> GetFiveMembersMostReadBook()
        {
            var context = new ApplicationDbContext();
            return context.MemberBook.Include(I => I.Member).Where(I => I.isRead == true)
                .GroupBy(I => I.Member.FullName).OrderByDescending(I => I.Count()).Take(3).Select(I => new DualHelper
                {
                    Name = I.Key,
                    NumberOfBooks = I.Count()
                }).ToList();
        }


    }
}
