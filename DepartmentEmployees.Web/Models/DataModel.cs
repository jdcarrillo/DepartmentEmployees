using DepartmentEmployees.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Models
{
    public class DataModel
    {
        public List<Enterprises> enterpriseModels { get; set; }
        public List<Employees> employeeModels { get; set; }
        public List<Departments> departmentsModel { get; set; }
        public List<DepartmentsEmployees> departmentsEmployeeModel { get; set; }

    }
}
