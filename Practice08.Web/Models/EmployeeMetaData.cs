using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EmployeeMetaData
    {
        [Required]
        
        public int ID { get; set; }
        [Required]
        [Display(Name="Firstname")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public Nullable<int> Salary { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}
