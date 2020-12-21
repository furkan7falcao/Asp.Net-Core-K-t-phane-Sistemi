using Library.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity:class,ITable,new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
