using DepartmentEmployees.Data;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Web.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly ILogger<EnterpriseRepository> _logger;
        private MariaDbContext _context;

        public EnterpriseRepository(MariaDbContext context, ILogger<EnterpriseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Enterprises> GetAll()
        {
            List<Enterprises> data = null;
            try
            {
                data = _context.Enterprises.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return data;
        }

        public Enterprises GetById(int id)
        {
            Enterprises employee = null;
            try
            {
                employee = _context.Enterprises.FirstOrDefault(f => f.id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return employee;
        }

        public Enterprises Save(Enterprises entity)
        {
            try
            {

                entity.created_by = "juandaniel.carrillo";
                entity.created_date = DateTime.Now;
                _context.Enterprises.Attach(entity);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
            return entity;
        }

        public Enterprises Update(Enterprises entity)
        {
            Enterprises enterprise = new Enterprises();
            try
            {
                enterprise = _context.Enterprises.FirstOrDefault(f => f.id == entity.id);
                if (enterprise != null)
                {

                    enterprise.name = entity.name;
                    enterprise.phone = entity.phone;
                    enterprise.status = entity.status;

                    enterprise.modified_by = "juandaniel.carrillo";
                    enterprise.modified_date = DateTime.Now;


                    _context.Enterprises.Update(enterprise);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return enterprise;
        }

        public Enterprises Delete(int id)
        {
            Enterprises entity = new Enterprises();
            try
            {
                entity = _context.Enterprises.Find(id);
                _context.Enterprises.Remove(entity);
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
