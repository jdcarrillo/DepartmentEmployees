using DepartmentEmployees.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Data
{


    public class MariaDbContext : DbContext
    {
        public DbSet<Enterprises> Enterprises { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Models.DepartmentsEmployees> DepartmentsEmployees { get; set; }
        public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<Enterprises>().ToTable("enterprises");
            //modelBuilder.Entity<Departments>().ToTable("departments");
            modelBuilder.Entity<Employees>().ToTable("employees");
            //modelBuilder.Entity<DepartmentsEmployees>().ToTable("departments_employees");

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(c => new { c.id });
                entity.Property(e => e.created_date);

                entity.HasOne(d => d.enterprises)
                   .WithMany(p => p.Departments)
                   .HasForeignKey(d => d.id_enterprises);

                entity.ToTable("departments");
            });

            modelBuilder.Entity<DepartmentsEmployees>(entity =>
            {
                entity.HasOne(d => d.departments)
                  .WithMany(p => p.departments_employees)
                  .HasForeignKey(d => d.id_department);
                //.OnDelete(DeleteBehavior.ClientSetNull)

                entity.HasOne(d => d.employees)
                    .WithMany(p => p.DepartmentEmployees)
                    .HasForeignKey(d => d.id_employee);
                    //.OnDelete(DeleteBehavior.ClientSetNull)

                entity.ToTable("departments_employees");
            });
        }
    }

}
