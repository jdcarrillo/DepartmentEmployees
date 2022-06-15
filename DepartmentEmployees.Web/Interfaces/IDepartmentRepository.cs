using DepartmentEmployees.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Interfaces
{
    public interface IDepartmentRepository
    {
        Departments GetById(int id);
        List<Departments> GetAll();
        Departments Save(Departments model);
        Departments Update(Departments model);
        Departments Delete(int id);
        List<Enterprises> GetEnterprises();
    }
}
