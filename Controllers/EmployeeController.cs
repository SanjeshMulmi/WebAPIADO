using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebbApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebbApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository )
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public  ActionResult GetEmployees()
        {

            return Ok(_employeeRepository.GetEmployees());

        }
        [HttpPost]
        public async Task<ActionResult> AddEmployees(Employee emp)
        {


            return Ok(await _employeeRepository.AddEmployee(emp));
        }
        
    }
}
