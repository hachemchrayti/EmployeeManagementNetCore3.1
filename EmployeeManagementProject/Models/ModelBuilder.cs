using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementProject.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Hachem",
                        Department = Dept.IT,
                        Email = "Hachem@pragimtech.com"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Ahmed",
                        Department = Dept.HR,
                        Email = "Ahmed@pragimtech.com"
                    }
                );
        }
    }
}
