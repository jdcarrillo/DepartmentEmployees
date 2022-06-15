using System.Collections.Generic;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Web.DTO;

namespace DepartmentEmployees.Web.Interfaces
{
    public interface IDepartmentEmployeeRepository
    {
        List<Data.Models.DepartmentsEmployees> GetAll();
        Data.Models.DepartmentsEmployees GetById(int id);
        List<DepartmentsEmployees> Save(List<DepartmentsEmployees> model);
        DepartmentsEmployees Update(DepartmentsEmployees model);
        DepartmentsEmployees Delete(int id);

        DepartmentEmployeeDTO DepartmentsEmployees();
    }
}
