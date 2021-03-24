using System;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
