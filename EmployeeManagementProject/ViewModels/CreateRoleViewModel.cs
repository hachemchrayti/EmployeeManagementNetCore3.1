using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementProject.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
