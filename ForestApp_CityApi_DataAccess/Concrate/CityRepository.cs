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
    public class CityRepository : ICityRepository
    {
        private readonly IBaseRepository<CityApiDbContext, City> _baseRepository;
        private CityApiDbContext _context;
        public CityRepository(IBaseRepository<CityApiDbContext, City> baseRepository, CityApiDbContext context)
        {
            _baseRepository = baseRepository;
            _context = context;
        }
        public async Task<int> CountAll()
        {
            return await _baseRepository.CountAll();
        }

        public async Task<int> CountWhere(Expression<Func<City, bool>> predicate)
        {
            return await _baseRepository.CountWhere(predicate);
        }

        public async Task<int> Delete(City entityToDelete)
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

        public async Task<List<City>> Find(Expression<Func<City, bool>> filter)
        {
            return await _baseRepository.Find(filter);

        }

        public async Task<City> FindOne(Expression<Func<City, bool>> filter)
        {
            return await _baseRepository.FindOne(filter);
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<City> GetByGuidId(Guid id)
        {
            return await _baseRepository.GetByGuidId(id);
        }

        public async Task<City> GetByID(int id)
        {
            return await _baseRepository.GetByID(id);
        }

        public Task<IList<City>> GetLast(Expression<Func<City, int>> filter, int takeCount = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<City> Insert(City entity)
        {
            return await _baseRepository.Insert(entity);
        }

        public async Task<bool> isExists(Expression<Func<City, bool>> filter)
        {
            return await _baseRepository.isExists(filter);
        }

        public async Task<City> Update(City entityToUpdate)
        {
            return await _baseRepository.Update(entityToUpdate);
        }
    }
}
