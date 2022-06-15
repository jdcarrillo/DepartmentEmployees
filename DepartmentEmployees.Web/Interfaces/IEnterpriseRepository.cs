using DepartmentEmployees.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Interfaces
{
    public interface IEnterpriseRepository
    {
        List<Enterprises> GetAll();
        Enterprises GetById(int id);
        Enterprises Save(Enterprises model);
        Enterprises Update(Enterprises model);
        Enterprises Delete(int id);
    }
}
