using DepartmentEmployees.Data;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ILogger<DepartmentRepository> _logger;
        private MariaDbContext _context;

        public DepartmentRepository(MariaDbContext context, ILogger<DepartmentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Departments GetById(int id)
        {
            Departments data = null;
            try
            {
                data = _context.Departments
                                .Include(i => i.enterprises)
                                .FirstOrDefault(f => f.id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return data;
        }
        public List<Departments> GetAll()
        {
            List<Departments> data = null;
            try
            {
                data = _context.Departments
                                .Include(i => i.enterprises)
                                .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return data;


        }
        public Departments Save(Departments entity)
        {
            try
            {
                entity.created_by = "juandaniel.carrillo";
                entity.created_date = DateTime.Now;
                _context.Departments.Attach(entity);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }

        public Departments Update(Departments entity)
        {

            try
            {
                entity.created_by = "juandaniel.carrillo";
                entity.created_date = DateTime.Now;
                _context.Departments.Update(entity);

                _context.SaveChanges(); ;
            }
            catch (Exception ex)
            {
                entity = null;
            }
            return entity;
        }

        public Departments Delete(int id)
        {
            Departments entity = new Departments();
            try
            {
                entity = _context.Departments.Find(id);
                _context.Departments.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }

        public List<Enterprises> GetEnterprises()
        {
            List<Enterprises> entity = new List<Enterprises>();
            try
            {
                entity = _context.Enterprises.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }
    }

}
