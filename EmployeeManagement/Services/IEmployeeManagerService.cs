using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IEmployeeManagerService
    {

        Task<bool> EditEmployeeContact(EmployeeContact CostomerContactToEdit);
        Task<bool> AddEmployeeContact(EmployeeContact customerContact);
        Task<EmployeeContact> GetEmployeeContact(int CustomerContactID);
        Task<bool> DeleteEmployeeContact(int id);
        Task<IEnumerable<Employee>> SerchEmployees(SerchViewModel model);



    }
}
