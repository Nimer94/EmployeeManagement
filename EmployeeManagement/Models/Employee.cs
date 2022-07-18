using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public enum EmployeeTitle
    {
        Herr,
        Frau
    }

    public class Employee : BaseEntity
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime AddedOn { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string InsuranceType { get; set; }

        [Required]
        public EmployeeTitle Title { get; set; }

        public virtual ICollection<EmployeeContact> EmployeeContacts { get; set; }



    }
}
