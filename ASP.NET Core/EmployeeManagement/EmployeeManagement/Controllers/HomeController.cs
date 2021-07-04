using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IEmployeeRepositroy _employeeRepositroy;
        public HomeController(IEmployeeRepositroy employeeRepositroy)
        {
            _employeeRepositroy = employeeRepositroy;
        }
        public ViewResult Index()
        {
            var model = _employeeRepositroy.GetAllEmployees();
            return View(model);
        }
        public ViewResult Details(int id )
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepositroy.GetEmployee(id),
                PageTitle = "Employee Details"

            };
            //Employee model = 
            //ViewBag.PageTitle = 
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
       {
            if (ModelState.IsValid)
            {
                var addedEmployee = _employeeRepositroy.Add(emp);
                return RedirectToAction("Details", new { id = addedEmployee.Id });
            }

            return View();
            
       }

       
    }
}
