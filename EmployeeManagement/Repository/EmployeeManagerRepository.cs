using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private readonly DataContext _context;

        public EmployeeManagerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEmployeeContact(EmployeeContact employeeContact)
        {
            await _context.EmployeeContacts.AddAsync(employeeContact);
            _context.SaveChanges();
            return true;
        }

     


        public async Task<bool> DeleteEmployeeContact(int id)
        {
            var contact = await _context.EmployeeContacts.SingleOrDefaultAsync(p => p.Id == id);
            _context.EmployeeContacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

   
        public async Task<bool> EditEmployeeContact(EmployeeContact EmployeeContactToEdit)
        {
            var orginalcontact = await _context.EmployeeContacts.SingleOrDefaultAsync(p => p.Id == EmployeeContactToEdit.Id);
            orginalcontact.Title = EmployeeContactToEdit.Title;
            orginalcontact.ContactType = EmployeeContactToEdit.ContactType;
            await _context.SaveChangesAsync();
            return true;
        }

      

        public async Task<EmployeeContact> GetEmployeeContact(int EmployeeContactID)
        {
            return await _context.EmployeeContacts.Include(p => p.Contact).Include(p => p.Employee).SingleOrDefaultAsync(p => p.Id == EmployeeContactID);
        }

        public async Task<IEnumerable<EmployeeContact>> GetEmployeeContacts(int id)
        {
            return await _context.EmployeeContacts.Where(p => p.EmployeeID == id).Include(p => p.Contact).ToListAsync();
        }


        public async Task<IEnumerable<Employee>> SerchEmployees(SerchViewModel model)
        {
            var Employees = await _context.Employees.ToListAsync();
            if (model.StartDate != null)
            {
                Employees = Employees.Where(p => p.AddedOn >= model.StartDate).ToList();
            }
            if (model.EndDate != null)
            {
                Employees = Employees.Where(p => p.AddedOn <= model.EndDate).ToList();
            }
            if (model.FirstName != null)
            {
                Employees = Employees.Where(p => p.FirstName == model.FirstName).ToList();
            }
            if (model.LastName != null)
            {
                Employees = Employees.Where(p => p.LastName == model.LastName).ToList();
            }
            return Employees;
        }
    }
}
