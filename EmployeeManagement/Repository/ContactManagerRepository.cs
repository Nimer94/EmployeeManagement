using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class ContactManagerRepository : IContactManagerRepository
    {
        private readonly DataContext _context;

        public ContactManagerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Contact> CreateContact(Contact ContactToCreate)
        {
            await _context.Contacts.AddAsync(ContactToCreate);
            await _context.SaveChangesAsync();
            return ContactToCreate;
        }

        public async Task<bool> DeleteContact(Contact ContactToDelete)
        {
            var orginalcontact = await _context.Contacts.SingleOrDefaultAsync(p => p.Id == ContactToDelete.Id);
            _context.Contacts.Remove(orginalcontact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Contact> EditContact(Contact ContactToEdit)
        {
            var orginalcontact = await _context.Contacts.SingleOrDefaultAsync(p => p.Id == ContactToEdit.Id);
            orginalcontact.Comment = ContactToEdit.Comment;
            orginalcontact.MobileNumber = ContactToEdit.MobileNumber;
            orginalcontact.PhoneNumber = ContactToEdit.PhoneNumber;
            orginalcontact.Email = ContactToEdit.Email;
            await _context.SaveChangesAsync();
            return ContactToEdit;
        }
    }
}
