using System;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementProject.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
