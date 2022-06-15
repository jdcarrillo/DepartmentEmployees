using DepartmentEmployees.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.DTO
{
    public class DepartmentEmployeeDTO
    {
        public int id { get; set; }
        public int id_department { get; set; }
        public int id_employee { get; set; }
        public bool? status { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }

        [NotMapped]
        public virtual DepartmentsDTO DepartmentDto { get; set; }

        [NotMapped]
        public virtual EmployeeDTO Employee { get; set; }
        [NotMapped]
        public virtual string Department_Name { get; set; }
        [NotMapped]
        public virtual string Employee_Name { get; set; }

        public List<Departments> Departments { set; get; }
        public List<Employees> Employees { set; get; }
        public string DepartmentsEmployeesJson { get; set; }
    }
}
