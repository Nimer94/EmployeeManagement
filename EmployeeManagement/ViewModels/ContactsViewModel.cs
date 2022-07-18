using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class ContactsViewModel
    {
        public int EmployeeContactID { get; set; }

        public int EmployeeID { get; set; }

        public int ContactID { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public Title Title { get; set; }

        public ContactType? ContactType { get; set; }
    }
}
