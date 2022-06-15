using DepartmentEmplosyees.Web.Interfaces;
using DepartmentEmployees.Data;
using DepartmentEmployees.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ILogger<EmployeeRepository> _logger;
        private MariaDbContext _context;

        public EmployeeRepository(MariaDbContext context, ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Employees GetById(int id)
        {
            Employees employee = null;
            try
            {
                employee = _context.Employees.FirstOrDefault(f => f.id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return employee;
        }

        public List<Employees> GetAll()
        {
            List<Employees> employee = null;
            try
            {
                employee = _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return employee;
        }

        public Employees Save(Employees entity)
        {
            try
            {

                entity.created_by = "juandaniel.carrillo";
                entity.created_date = DateTime.Now;
                _context.Employees.Attach(entity);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }

        public Employees Update(Employees entity)
        {
            Employees employee = new Employees();
            try
            {
                employee = _context.Employees.FirstOrDefault(f => f.id == entity.id);
                if (employee != null)
                {

                    employee.name = entity.name;
                    employee.surname = entity.surname;
                    employee.age = entity.age;
                    employee.email = entity.email;
                    employee.position = entity.position;
                    employee.status = entity.status;

                    employee.modified_by = "juandaniel.carrillo";
                    employee.modified_date = DateTime.Now;


                    _context.Employees.Update(employee);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return employee;
        }

        public Employees Delete(int id)
        {
            Employees entity = new Employees();
            try
            {
                entity = _context.Employees.Find(id);
                _context.Employees.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }



    }
}
