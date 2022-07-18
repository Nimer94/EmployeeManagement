namespace EmployeeManagement.Models
{
    public enum Title
    {
        Herr,
        Frau,
        Firma,
    }

    public enum ContactType
    {
        Personal,
        Work,
        Reports,
        Other
    }

    public class EmployeeContact : BaseEntity
    {
        public int EmployeeID { get; set; }
        public int ContactID { get; set; }
        public Title Title { get; set; }
        public ContactType? ContactType { get; set; }
        public int Order { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
