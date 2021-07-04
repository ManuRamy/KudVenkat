using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepositroy
    {
        readonly AppDBContext appDBContext;
        public SQLEmployeeRepository(AppDBContext context)
        {
            appDBContext = context;
        }
        public Employee Add(Employee employee)
        {
            appDBContext.Employees.Add(employee);
            appDBContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = appDBContext.Employees.Find(id);
            if (employee != null)
            {
                appDBContext.Employees.Remove(employee);
                appDBContext.SaveChanges();
            }
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return appDBContext.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            return appDBContext.Employees.Find(id);
        }

        public Employee Update(Employee emp)
        {
            var employee = appDBContext.Employees.Attach(emp);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDBContext.SaveChanges();
            return emp;
        }
    }
}
