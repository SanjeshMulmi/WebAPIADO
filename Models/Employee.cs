using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebbApi.Models
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartMentID { get; set; }
        public eGender gender { get; set; }
        public Department departMent { get; set; }
        

    }
    public enum eGender{
        male,female
    }
}
