using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class ContactManagerService : IContactManagerService
    {

        private IContactManagerRepository _repository;

        public ContactManagerService(IContactManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contact> CreateContact(Contact ContactToCreate)
        {
            Contact contact = new Contact { Id = 0 };
            try
            {
                contact = await _repository.CreateContact(ContactToCreate);
            }
            catch
            {
                return contact;
            }
            return contact;
        }

        public async Task<bool> DeleteContact(Contact ContactToDelete)
        {
            try
            {
                await _repository.DeleteContact(ContactToDelete);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<Contact> EditContact(Contact ContactToEdit)
        {
            Contact contact = new Contact { Id = 0 };
            try
            {
                contact = await _repository.EditContact(ContactToEdit);
            }
            catch
            {
                return contact;
            }
            return contact;
        }
    }
}
