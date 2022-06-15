using DepartmentEmployees.Data;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Web.DTO;
using DepartmentEmployees.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Repositories
{
    public class DepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        private readonly ILogger<DepartmentEmployeeRepository> _logger;
        private MariaDbContext _context;

        public DepartmentEmployeeRepository(MariaDbContext context, ILogger<DepartmentEmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public DepartmentsEmployees GetById(int id)
        {
            DepartmentsEmployees data = null;
            try
            {
                data = _context.DepartmentsEmployees
                                .Include(i => i.departments)
                                .Include(i => i.employees)
                                .FirstOrDefault(f => f.id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
        public List<DepartmentsEmployees> GetAll()
        {
            List<DepartmentsEmployees> data = null;
            try
            {
                data = _context.DepartmentsEmployees
                    .Include(i => i.departments)
                    .Include(i => i.employees)
                                .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return data;


        }

        public List<DepartmentsEmployees> Save(List<DepartmentsEmployees> entity)
        {
            try
            {
                foreach (var item in entity)
                {
                    item.status = true;
                    item.created_by = "juandaniel.carrillo";
                    item.created_date = DateTime.Now;
                    _context.DepartmentsEmployees.Attach(item);


                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }

        public DepartmentsEmployees Update(DepartmentsEmployees entity)
        {

            try
            {
                entity.created_by = "juandaniel.carrillo";
                entity.created_date = DateTime.Now;
                _context.DepartmentsEmployees.Update(entity);

                _context.SaveChanges(); ;
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public DepartmentsEmployees Delete(int id)
        {
            DepartmentsEmployees entity = new DepartmentsEmployees();
            try
            {
                entity = _context.DepartmentsEmployees.Find(id);
                _context.DepartmentsEmployees.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }

        public DepartmentEmployeeDTO DepartmentsEmployees()
        {
            List<Departments> departments = new List<Departments>();
            List<Employees> employees = new List<Employees>();
            DepartmentsEmployees entity = new DepartmentsEmployees();
            List<DepartmentsEmployees> data = new List<DepartmentsEmployees>();
            DepartmentEmployeeDTO depEmployeesDTO = new DepartmentEmployeeDTO();
            try
            {
                employees = _context.Employees.ToList();
                departments = _context.Departments.ToList();
                depEmployeesDTO.Departments = departments;
                depEmployeesDTO.Employees = employees;
            }
            catch (Exception ex)
            {
                throw;
            }
            return depEmployeesDTO;
        }
    }
}
