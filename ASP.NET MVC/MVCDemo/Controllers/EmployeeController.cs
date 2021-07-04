using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
		// GET: Employee
		public ActionResult Details(int id)
		{
			EmployeeContext employeeContext = new EmployeeContext();
			Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeID == id);
			return View(employee);
		}

		public ActionResult Index()
		{
			EmployeeContext employeeContext = new EmployeeContext();
			List<Employee> employee = employeeContext.Employees.ToList();
			return View(employee);
		}
	}
}