using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    /// <summary>
    /// Repository interface that performs several functions for Db.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericManagerRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieve record by given PK value.
        /// </summary>
        /// <param name="id">id value of record.</param>
        /// <returns>Record if exists.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Retrieve list of all records from Db.
        /// </summary>
        /// <returns>List of records.</returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// Adds record to Db.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task<T> Add(T entity);

        /// <summary>
        /// Updates given record.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes given record from Db..
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Save changes to Db.
        /// </summary>
        /// <returns>Indicates whether saved successfully.</returns>
        Task<bool> Complete();

    }
}
