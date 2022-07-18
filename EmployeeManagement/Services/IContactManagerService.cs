using EmployeeManagement.Models;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IContactManagerService
    {
        Task<Contact> CreateContact(Contact ContactToCreate);
        Task<Contact> EditContact(Contact ContactToEdit);
        Task<bool> DeleteContact(Contact ContactToDelete);
    }
}
