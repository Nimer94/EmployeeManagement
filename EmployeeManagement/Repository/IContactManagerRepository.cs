using EmployeeManagement.Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IContactManagerRepository
    {
        Task<Contact> CreateContact(Contact ContactToCreate);
        Task<Contact> EditContact(Contact ContactToEdit);
        Task<bool> DeleteContact(Contact ContactToDelete);
    }
}
