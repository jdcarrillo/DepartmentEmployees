using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Data.Models
{
    public class Departments
    {

        public int id { get; set; }
        public int id_enterprises { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Phone]
        public string phone { get; set; }
        [Required]
        public string description { get; set; }
        public bool status { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }

        public virtual Enterprises enterprises { get; set; }
        [NotMapped]
        public virtual ICollection<DepartmentsEmployees> departments_employees { get; set; }
    }
}
