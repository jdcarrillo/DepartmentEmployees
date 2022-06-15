using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Data.Models
{
    public class Employees
    {
        public Employees()
        {
            DepartmentEmployees = new HashSet<DepartmentsEmployees>();
        }
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string position { get; set; }
        public bool status { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }

        [NotMapped]
        public virtual ICollection<DepartmentsEmployees> DepartmentEmployees { get; set; }
    }
}
