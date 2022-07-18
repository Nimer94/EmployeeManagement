using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<EmployeeContact> EmployeeContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
