using ForestApp_CityApi_DataAccess.Abstract;
using ForestApp_CityApi_Entity;
using ForestAppBase.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForestApp_CityApi_DataAccess.Concrate
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly IBaseRepository<CityApiDbContext, District> _baseRepository;
        private CityApiDbContext _context;

        public DistrictRepository(IBaseRepository<CityApiDbContext, District> baseRepository, CityApiDbContext context)
        {
            _baseRepository = baseRepository;
            _context = context;
        }
        public async Task<int> CountAll()
        {
            return await _baseRepository.CountAll();
        }

        public async Task<int> CountWhere(Expression<Func<District, bool>> predicate)
        {
            return await _baseRepository.CountWhere(predicate);
        }

        public async Task<int> Delete(District entityToDelete)
        {
            return await _baseRepository.Delete(entityToDelete);
        }

        public async Task<int> DeleteByGuidId(Guid id)
        {
            return await _baseRepository.DeleteByGuidId(id);
        }

        public async Task<int> DeleteById(int id)
        {
            return await _baseRepository.DeleteById(id);
        }

        public async Task<List<District>> Find(Expression<Func<District, bool>> filter)
        {
            return await _baseRepository.Find(filter);

        }

        public async Task<District> FindOne(Expression<Func<District, bool>> filter)
        {
            return await _baseRepository.FindOne(filter);
        }

        public async Task<IEnumerable<District>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<District> GetByGuidId(Guid id)
        {
            return await _baseRepository.GetByGuidId(id);
        }

        public async Task<District> GetByID(int id)
        {
            return await _baseRepository.GetByID(id);
        }

        public Task<IList<District>> GetLast(Expression<Func<District, int>> filter, int takeCount = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<District> Insert(District entity)
        {
            return await _baseRepository.Insert(entity);
        }

        public async Task<bool> isExists(Expression<Func<District, bool>> filter)
        {
            return await _baseRepository.isExists(filter);
        }

        public async Task<District> Update(District entityToUpdate)
        {
            return await _baseRepository.Update(entityToUpdate);
        }
    }
}
