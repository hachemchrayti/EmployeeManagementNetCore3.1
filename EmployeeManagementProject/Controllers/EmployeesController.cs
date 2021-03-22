using System;
using EmployeeManagementProject.Models;
using EmployeeManagementProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



    }
}
