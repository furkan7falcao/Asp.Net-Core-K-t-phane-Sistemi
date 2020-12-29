using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class MemberManager : GenericManager<Member> , IMemberService
    {
        private readonly IMemberDAL _memberDAL;
        public MemberManager(IMemberDAL memberDAL) : base(memberDAL)
        {
            _memberDAL = memberDAL;
        }

        public async Task<int> GetCurrentBookCountAsync(int memberId)
        {
            return await _memberDAL.GetCurrentBookCountAsync(memberId);
        }
        public async Task<int> GetReadBookCountAsync(int memberId)
        {
            return await _memberDAL.GetReadBookCountAsync(memberId);
        }

        public List<DualHelper> GetFiveMembersMostReadBook()
        {
            return _memberDAL.GetFiveMembersMostReadBook();
        }

        public List<DualHelper> GetFiveMembersMostActive()
        {
            return _memberDAL.GetFiveMembersMostActive();
        }


    }
}
