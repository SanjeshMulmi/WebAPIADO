using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebbApi.Models;

namespace WebbApi.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
            
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
