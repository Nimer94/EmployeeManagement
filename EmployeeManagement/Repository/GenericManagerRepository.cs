using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class GenericManagerRepository<T> : IGenericManagerRepository<T>
        where T : BaseEntity
    {
        private readonly DataContext _context;

        public GenericManagerRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<T> Add(T entity)
        {
            var e = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        /// <inheritdoc/>
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
