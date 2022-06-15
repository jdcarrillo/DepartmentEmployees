using DepartmentEmployees.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.DTO
{
    public class DepartmentEmployeesListDTO
    {
        public List<Departments> Departments { set; get; }
        public List<Employees> Employees { set; get; }
    }
}
