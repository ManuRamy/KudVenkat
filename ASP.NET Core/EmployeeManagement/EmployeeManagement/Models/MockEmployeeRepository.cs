using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepositroy
    {
        public List<Employee> employeeList;
        public MockEmployeeRepository()
        {
            employeeList = new List<Employee>
            {
                new Employee()
                {
                    Id = 1, Name = "Mary" , Department=DepartmentEnum.HR, Email="Mary@pragimtech.com"
                },
                new Employee()
                {
                    Id = 2, Name = "John" , Department=DepartmentEnum.IT, Email="John@pragimtech.com"
                },
                new Employee()
                {
                    Id = 3, Name = "Sam" , Department=DepartmentEnum.IT, Email="Sam@pragimtech.com"
                }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = employeeList.Max(emp => emp.Id) + 1;
            employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            var emp = employeeList.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employeeList.Remove(emp);
            }

            return emp;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return employeeList.FirstOrDefault(emp => emp.Id == id);
        }

        public Employee Update(Employee employee)
        {
            var emp = employeeList.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Department = employee.Department;
                emp.Email = employee.Email;
            }

            return employee;
        }
    }
}
