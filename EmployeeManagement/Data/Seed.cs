using EmployeeManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Data
{
    public class Seed
    {
        public static void SeedEmployees(DataContext Db)
        {
            if (!Db.Employees.Any())
            {
                var employeeData = System.IO.File.ReadAllText("Data/EmployeeSeedData.json");
                var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData);

                foreach (var emp in employees)
                {
                    emp.AddedOn = DateTime.Now;
                    Db.Employees.AddAsync(emp);
                }
                Db.SaveChanges();
            }
        }
    }
}
