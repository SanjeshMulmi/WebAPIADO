using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbApi.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Search(string Name, eGender? gender);
        List<Employee> GetEmployees();

        Task<Employee> GetEmployee(int employeId);
        Task<Employee> AddEmployee(Employee emp);

        Task<Employee> UpdateEmployee(Employee emp);

        Task DeleteEmployee(Employee emp);

    }
}
