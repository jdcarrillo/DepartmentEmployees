using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentEmplosyees.Web.Interfaces;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DepartmentEmployees.Web.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll(string message = "")
        {
            DataModel model = new DataModel();
            model.employeeModels = new List<Employees>();
            var data = _employeeRepository.GetAll();

            model.employeeModels = data;
            ViewBag.StatusMessage = message;

            return PartialView("_EmployeeList", model);
        }

 
        public Employees Get(int id)
        {
            DataModel model = new DataModel();
            model.employeeModels = new List<Employees>();
            var data = _employeeRepository.GetById(id);
            model.employeeModels.Add(data);

            return data;

        }

        public ActionResult GetById(int id)
        {
            var model = _employeeRepository.GetById(id);
            if (model != null)
            {
                return PartialView("_GridEditPartial", model);
            }

            return View();
        }
        [HttpGet]
        public ActionResult EmployeeDetails()
        {
            return PartialView("_EmployeeManagement");
        }
        [HttpPost]
        public ActionResult Save([FromForm] Employees model)
        {
            try
            {
                _employeeRepository.Save(model);
                ModelState.Clear();
                ViewBag.StatusMessage = "Employee data was saved!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return PartialView("_EmployeeManagement", model);
        }

        public ActionResult Update([FromForm] Employees model)
        {
            try
            {
                _employeeRepository.Update(model);
                ModelState.Clear();
                ViewBag.StatusMessage = "Employee data was updated!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("GetAll", new { message = ViewBag.StatusMessage });
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _employeeRepository.Delete(id);
                ModelState.Clear();
                ViewBag.StatusMessage = "Employee data was deleted!";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("GetAll", new { message = ViewBag.StatusMessage });
        }
    }
}
