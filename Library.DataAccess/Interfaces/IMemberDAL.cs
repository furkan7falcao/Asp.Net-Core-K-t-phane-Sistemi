using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface IMemberDAL : IGenericDAL<Member>
    {
        Task<int> GetReadBookCountAsync(int memberId);
        Task<int> GetCurrentBookCountAsync(int memberId);
        public List<DualHelper> GetFiveMembersMostReadBook();
        public List<DualHelper> GetFiveMembersMostActive();
    }
}
