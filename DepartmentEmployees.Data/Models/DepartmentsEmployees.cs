using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Data.Models
{
    public class DepartmentsEmployees
    {
        public int id { get; set; }
        public int id_department { get; set; }
        public int id_employee { get; set; }
        public bool status { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }
        public virtual Departments departments { get; set; }
        public virtual Employees employees { get; set; }
    }
}
