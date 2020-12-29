using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IMemberService : IGenericService<Member>
    {
        Task<int> GetReadBookCountAsync(int memberId);
        Task<int> GetCurrentBookCountAsync(int memberId);
        public List<DualHelper> GetFiveMembersMostReadBook();
        public List<DualHelper> GetFiveMembersMostActive();
    }
}
