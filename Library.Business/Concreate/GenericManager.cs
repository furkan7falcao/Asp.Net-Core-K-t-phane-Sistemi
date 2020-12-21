using Library.Business.Interfaces;
using Library.DataAccess.Interfaces;
using Library.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Business.Concreate
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDAL<TEntity> _genericDAL;

        public GenericManager(IGenericDAL<TEntity> genericDAL)
        {
            _genericDAL = genericDAL;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _genericDAL.AddAsync(entity);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _genericDAL.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDAL.GetAllAsync();

        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDAL.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDAL.UpdateAsync(entity);

        }
    }
}
