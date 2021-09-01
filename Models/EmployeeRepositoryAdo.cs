using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebbApi.Models
{
    public class EmployeeRepositoryAdo : IEmployeeRepository
    {

        string connectionString = "data source=(localdb)\\MSSQLLocalDB; database=EmployeeDepartMent; Integrated Security=true;";
        /*  string connectionS  "EmpDBConnection": "Server=(localdb)\\MSSQLLocalDB;Database=EmployeeDepartMent;Trusted_Connection=True;MultipleActiveResultSets=true"*/

        SqlConnection con = null; 
            
        

        public EmployeeRepositoryAdo()
        {
             con = new SqlConnection(connectionString);

        }

        public Task<Employee> AddEmployee(Employee emp)
        {
            /*List<Employee> employeeList = new List<Employee>();

            SqlCommand cmd = new SqlCommand("InsertEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var employee = new Employee();

                employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                employee.FirstName = rdr["FirstName"].ToString();
                employee.gender = (eGender) rdr["gender"];
                employee.DepartMentID = Convert.ToInt32(rdr["DepartMentId"]);
              
              
                employeeList.Add(employee);
            }con.Close();*/
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int employeId)
        {
            throw new NotImplementedException();
        }

        public  List<Employee> GetEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            SqlCommand cmd = new SqlCommand("select e.EmployeeID, e.FirstName, e.LastName, e.gender, e.DepartMentID, d.DepartMentName from Employees e inner join DepartMent d on e.DepartMentID = d.DepartMentID", con);
            
            cmd.CommandType = CommandType.Text;
            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var employee = new Employee();

                employee.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                employee.FirstName = rdr["FirstName"].ToString();
                employee.LastName = rdr["LastName"].ToString();
                employee.gender = (eGender)rdr["gender"];
                employee.DepartMentID = Convert.ToInt32(rdr["DepartMentId"]);
                Department objDepart = new Department();
                objDepart.DepartmentID = Convert.ToInt32(rdr["DepartMentId"]);
                objDepart.DepartMentName = Convert.ToString(rdr["DepartMentName"]);
                employee.departMent = objDepart;
                /*employee.departMent.DepartmentID = Convert.ToInt32(rdr["DepartMentId"]);
                employee.departMent.DepartMentName = Convert.ToString(rdr["DepartMentName"]);*/

                // we cannot get the instance of connection multiple times. 
                /* int deptID = employee.DepartMentID;
                 // Sql command for Department Table
                 SqlCommand cmdForDepart = new SqlCommand("SELECT DepartmentName FROM Department WHERE DepartmentID=" + deptID, con);
                 cmdForDepart.CommandType = CommandType.Text;
                 con.Open();
                 SqlDataReader readDepart = cmdForDepart.ExecuteReader();
                 employee.departMent = (Department)readDepart["DepartMentName"];*/


                employeeList.Add(employee);
            }
            con.Close();
            return  employeeList;
        }

        public Task<IEnumerable<Employee>> Search(string Name, eGender? gender)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
