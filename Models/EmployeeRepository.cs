using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebbApi.Data;

namespace WebbApi.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(Employee emp)
        {
            var result = await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteEmployee(Employee emp)
        {
            var result = await _context.Employees.FindAsync(emp.EmployeeID);
            if (result != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Employee> GetEmployee(int employeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }


        public async Task<IEnumerable<Employee>> Search(string Name, eGender? gender)
        {
            IQueryable<Employee> query = _context.Employees;

            if (!String.IsNullOrEmpty(Name))
            {
                query = query.Where(e => e.FirstName.Contains(Name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.gender == (eGender)gender);
            }

            return await query.ToListAsync();
        }


        public Task<Employee> UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        List<Employee> IEmployeeRepository.GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
