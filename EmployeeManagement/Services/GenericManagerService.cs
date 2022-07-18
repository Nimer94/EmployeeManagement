using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class GenericManagerService<T> : IGenericManagerService<T> where T : BaseEntity
    {
        private IValidationDictionary _validationDictionary;

        private IGenericManagerRepository<T> _repository;


        public GenericManagerService(IGenericManagerRepository<T> repository)
        {
            _repository = repository;
        }


        public async Task<T> Add(T entity)
        {
            var enti = await _repository.Add(entity);
            return enti;
        }

        public async Task<bool> Complete()
        {
            return await _repository.Complete();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _repository.ListAllAsync();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
