using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class CRUDEmployeeViewModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime AddedOn { get; set; }

        public string Position { get; set; }

        public string InsuranceType { get; set; }

        [Required]
        public EmployeeTitle Title { get; set; }

        public List<EmployeeContact> EmployeeContacts { get; set; }

        public CRUDEmployeeViewModel()
        {
            EmployeeContacts = new List<EmployeeContact>();
        }
    }
}
