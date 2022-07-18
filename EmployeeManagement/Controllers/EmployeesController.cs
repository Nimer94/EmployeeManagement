using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private IGenericManagerRepository<Employee> _employeesservice;
        private IGenericManagerRepository<Contact> _contactsservice;
        private IEmployeeManagerRepository _service;


        public EmployeesController(
            IGenericManagerRepository<Employee> employeesservice,
            IGenericManagerRepository<Contact> contactsservice,
            IEmployeeManagerRepository service)
        {
            _employeesservice = employeesservice;
            _contactsservice = contactsservice;
            _service = service;
        }

        /// <summary>
        /// Returns list of add saved employees in data repository.
        /// </summary>
        /// <returns>List of records.</returns>
        public async Task<ActionResult> List()
        {
            var emps = await _employeesservice.ListAllAsync();
            return View(emps);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cRUDEmployeeViewModel = new CRUDEmployeeViewModel();
            return View(cRUDEmployeeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CRUDEmployeeViewModel Viewemployee)
        {
            var emp = new Employee
            {
                FirstName = Viewemployee.FirstName,
                PhoneNumber = Viewemployee.PhoneNumber,
                LastName = Viewemployee.LastName,
                AddedOn = DateTime.Now,
                Title = Viewemployee.Title,
                Position = Viewemployee.Position,
                InsuranceType = Viewemployee.InsuranceType,
            };

            var result = await _employeesservice.Add(emp);

            return Json(new { success = true, CusID = result.Id });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var emp = await _employeesservice.GetByIdAsync(id.Value);
            var model = new CRUDEmployeeViewModel
            {
                Id = emp.Id,
                Title = emp.Title,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                PhoneNumber = emp.PhoneNumber,
                Position = emp.Position,
                InsuranceType = emp.InsuranceType,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CRUDEmployeeViewModel ViewEmployee)
        {
            var emp = new Employee
            {
                Id = ViewEmployee.Id,
                Title = ViewEmployee.Title,
                PhoneNumber = ViewEmployee.PhoneNumber,
                FirstName = ViewEmployee.FirstName,
                LastName = ViewEmployee.LastName,
                Position = ViewEmployee.Position,
                InsuranceType = ViewEmployee.InsuranceType,

            };

            _employeesservice.Update(emp);
            await _employeesservice.Complete();

            return Json(new { success = true, EmpID = ViewEmployee.Id });
        }

        public async Task<ActionResult> Details(int id)
        {
            var emp = await _employeesservice.GetByIdAsync(id);
            var model = new CRUDEmployeeViewModel
            {
                Id = emp.Id,
                Title = emp.Title,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                PhoneNumber = emp.PhoneNumber,
                Position = emp.Position,
                InsuranceType = emp.InsuranceType,
            };
            var employeecontacts = await _service.GetEmployeeContacts(id);
            model.EmployeeContacts = employeecontacts.ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var emp = await _employeesservice.GetByIdAsync(id);

            _employeesservice.Delete(emp);

            await _employeesservice.Complete();

            return RedirectToAction("List");
        }

        public async Task<ActionResult> SaveContact(ContactsViewModel contactViewModel)
        {
            var contact = new Contact
            {
                Id = contactViewModel.ContactID,
                Comment = contactViewModel.Comment,
                PhoneNumber = contactViewModel.PhoneNumber,
                Email = contactViewModel.Email,
                MobileNumber = contactViewModel.MobileNumber,

            };

            if (contactViewModel.EmployeeContactID == 0)
            {
                var result = await _contactsservice.Add(contact);

                if (result.Id != 0)
                {
                    var employeeContact = new EmployeeContact
                    {
                        ContactID = result.Id,
                        EmployeeID = contactViewModel.EmployeeID,
                        Order = 1,
                        Title = contactViewModel.Title,
                        ContactType = contactViewModel.ContactType
                    };

                    var contactIsAdded = await _service.AddEmployeeContact(employeeContact);

                    if (contactIsAdded)
                    {
                        return Json(new { success = contactIsAdded });
                        await _employeesservice.Complete();
                    }
                    else
                    {
                        _contactsservice.Delete(result);
                        await _employeesservice.Complete();
                    }
                }
            }
            else
            {
                var customerContact = new EmployeeContact
                {
                    Id = contactViewModel.EmployeeContactID,
                    Title = contactViewModel.Title,
                    ContactType = contactViewModel.ContactType
                };

                var result = await _service.EditEmployeeContact(customerContact);

                if (result)
                {
                    _contactsservice.Update(contact);

                    await _employeesservice.Complete();

                    return Json(new { success = result });
                }
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<ActionResult> GetEmployeeContact(int? id)
        {
            var employeecontact = await _service.GetEmployeeContact(id.Value);

            var model = new ContactsViewModel
            {
                EmployeeContactID = employeecontact.Id,
                ContactID = employeecontact.ContactID,
                Title = employeecontact.Title,
                Comment = employeecontact.Contact.Comment,
                Email = employeecontact.Contact.Email,
                PhoneNumber = employeecontact.Contact.PhoneNumber,
                EmployeeID = employeecontact.EmployeeID,
                MobileNumber = employeecontact.Contact.MobileNumber,
                ContactType = employeecontact.ContactType
            };

            var serialized = JsonConvert.SerializeObject(model);

            return Content(serialized, "application/json");
        }


        public async Task<ActionResult> DeleteContact(int? id)
        {
            var result = await _service.DeleteEmployeeContact(id.Value);

            if (result)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }


        public async Task<ActionResult> GetEmpsList(SerchViewModel serchform)
        {
            var result = await _service.SerchEmployees(serchform);

            return PartialView("_EmployeesListPartial", result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
