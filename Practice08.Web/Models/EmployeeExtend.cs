using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public partial class Employee
    {
       public Department EmployeeDepartment { get; set; }
       public IEnumerable<Department> DepartmentList { get; set; }
    }
}
