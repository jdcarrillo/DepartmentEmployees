using DepartmentEmployees.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmplosyees.Web.Interfaces
{
    public interface IEmployeeRepository
    {
        Employees GetById(int id);
        List<Employees> GetAll();
        Employees Save(Employees model);
        Employees Update(Employees model);
        Employees Delete(int id);
    }
}
