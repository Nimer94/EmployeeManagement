namespace EmployeeManagement.Models
{
    public class Contact : BaseEntity
    {
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

    }
}
