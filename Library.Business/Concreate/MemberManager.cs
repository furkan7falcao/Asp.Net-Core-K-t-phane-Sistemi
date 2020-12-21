using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Concreate;

namespace Library.Business.Concreate
{
    public class MemberManager : GenericManager<Member> , IMemberService
    {
        private readonly IMemberDAL _memberDAL;
        public MemberManager(IMemberDAL memberDAL) : base(memberDAL)
        {
            _memberDAL = memberDAL;
        }

    }
}
