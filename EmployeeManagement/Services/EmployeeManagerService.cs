using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeManagerService : IEmployeeManagerService
    {

        private IEmployeeManagerRepository _repository;

        public EmployeeManagerService(EmployeeManagerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddEmployeeContact(EmployeeContact employeeContact)
        {
            try
            {
                await _repository.AddEmployeeContact(employeeContact);
            }
            catch
            {
                return false;
            }
            return true;
        }

       

      

        public async Task<bool> DeleteEmployeeContact(int id)
        {
            try
            {
                return await _repository.DeleteEmployeeContact(id);
            }
            catch
            {
                return false;
            }
        }

      

        public async Task<bool> EditEmployeeContact(EmployeeContact EmployeeContactToEdit)
        {
            try
            {
                await _repository.EditEmployeeContact(EmployeeContactToEdit);
            }
            catch
            {
                return false;
            }
            return true;
        }

      
        public async Task<EmployeeContact> GetEmployeeContact(int EmployeeContactID)
        {
            try
            {
                return await _repository.GetEmployeeContact(EmployeeContactID);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> SerchEmployees(SerchViewModel model)
        {
      
                return await _repository.SerchEmployees(model);
        }
    }
}
