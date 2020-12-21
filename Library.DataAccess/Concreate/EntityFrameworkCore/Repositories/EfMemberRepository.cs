using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;

namespace Library.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfMemberRepository : EfGenericRepository<Member>, IMemberDAL
    {
        //public async Task<Member> GetMemberOfNotificationAsync(Request notification)
        //{
        //    var context = new ApplicationDbContext();

        //    var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
        //    {
        //        user = resultUser,
        //        userRole = resultUserRole
        //    })
        //    .Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
        //    {
        //        user = resultTable.user,
        //        userRoles = resultTable.userRole,
        //        roles = resultRole
        //    }).Where(I => I.roles.Name == "Member").Select(I => new Member()
        //    {
        //        Id = I.user.Id,
        //        FullName = I.user.FullName,
        //        UserName = I.user.UserName,
        //        Picture = I.user.Picture,
        //        Email = I.user.Email
        //    });

        //    return await result.Where(I => I.Id == notification.PosterMemberId).FirstOrDefaultAsync();

        //}
    }
}
