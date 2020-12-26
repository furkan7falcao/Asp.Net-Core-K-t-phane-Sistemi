using Library.Entities.Concreate;
using System.Threading.Tasks;

namespace Library.DataAccess.Interfaces
{
    public interface IMemberDAL : IGenericDAL<Member>
    {
        Task<int> GetReadBookCountAsync(int memberId);
        Task<int> GetCurrentBookCountAsync(int memberId);
    }
}
