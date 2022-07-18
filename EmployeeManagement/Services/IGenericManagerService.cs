using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IGenericManagerService<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Complete();

    }
}
