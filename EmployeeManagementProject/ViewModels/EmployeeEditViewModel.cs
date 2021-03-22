using System;
using System.ComponentModel.DataAnnotations;
using EmployeeManagementProject.ViewModels;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagementProject.Models
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
