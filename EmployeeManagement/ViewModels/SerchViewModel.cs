using System;

namespace EmployeeManagement.ViewModels
{
    public class SerchViewModel
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
