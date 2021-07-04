using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepositroy
    {
        Employee GetEmployee(int id);
        List<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        Employee Delete(int id);

        Employee Update(Employee employee);
    }
}
