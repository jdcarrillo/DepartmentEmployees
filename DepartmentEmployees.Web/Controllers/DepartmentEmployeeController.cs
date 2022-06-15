using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Models;
using DepartmentEmployees.Web.DTO;
using DepartmentEmployees.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.Controllers
{
    public class DepartmentEmployeeController : Controller
    {
        private readonly ILogger<DepartmentEmployeeController> _logger;
        private readonly IDepartmentEmployeeRepository _departmentEmployeeRepository;
        public DepartmentEmployeeController(IDepartmentEmployeeRepository departmentEmployeeRepository, ILogger<DepartmentEmployeeController> logger)
        {
            _departmentEmployeeRepository = departmentEmployeeRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public DepartmentsEmployees Get(int id)
        {
            DataModel model = new DataModel();
            var data = _departmentEmployeeRepository.GetById(id);
            model.departmentsEmployeeModel.Add(data);

            return data;

        }

        public ActionResult GetById(int id)
        {
            var model = _departmentEmployeeRepository.GetById(id);
            if (model != null)
            {
                List<SelectListItem> departmentsList = new List<SelectListItem>();
                departmentsList.Add(new SelectListItem() { Value = model.departments.id.ToString(), Text = model.departments.name });
                ViewBag.SelectedItemDepartment = model.departments.name;
                //ViewBag.departmentsList = GetDepartments();

                return PartialView("_GridEditPartial", model);
            }

            return View();
        }

        public IActionResult GetAll(string message = "")
        {
            DataModel model = new DataModel();
            model.departmentsModel = new List<Departments>();
            var data = _departmentEmployeeRepository.GetAll();

            model.departmentsEmployeeModel = data;
            ViewBag.StatusMessage = message;

            return PartialView("_DepartmentEmployeeList", model);
        }
        public ActionResult DepartmentEmployeeDetails()
        {
            DepartmentEmployeeDTO model = new DepartmentEmployeeDTO();
            var depEmp = _departmentEmployeeRepository.DepartmentsEmployees();
            List<SelectListItem> employeesList = new List<SelectListItem>();
            List<SelectListItem> departmentsList = new List<SelectListItem>();
            employeesList = GetEmployees(depEmp.Employees);
            departmentsList = GetDepartments(depEmp.Departments);

            ViewBag.SelectedItemEmployees = employeesList;
            ViewBag.SelectedItemDepartments = departmentsList;

            return PartialView("_DepartmentEmployeeManagement", depEmp);
        }
        private List<SelectListItem> GetEmployees(List<Employees> employees)
        {
            List<SelectListItem> dataList = new List<SelectListItem>();

            dataList.Add(new SelectListItem() { Value = "-1", Text = "Employees", Selected = true, Disabled = true });
            foreach (var item in employees)
            {
                dataList.Add(new SelectListItem()
                {
                    Value = item.id.ToString(),
                    Text = item.name
                });
            }

            return dataList;
        }
        private List<SelectListItem> GetDepartments(List<Departments> departments)
        {
            List<SelectListItem> dataList = new List<SelectListItem>();

            dataList.Add(new SelectListItem { Value = "-1", Text = "Departments", Selected = true, Disabled = true });
            foreach (var item in departments)
            {
                dataList.Add(new SelectListItem()
                {
                    Value = item.id.ToString(),
                    Text = item.name
                });
            }

            return dataList;
        }

        [HttpPost]
        public ActionResult Save(DepartmentEmployeeDTO model)
        {
            DepartmentEmployeeDTO depEmp = new DepartmentEmployeeDTO();
            try
            {
                if (ModelState.IsValid)
                {
                    depEmp = _departmentEmployeeRepository.DepartmentsEmployees();
                    List<SelectListItem> employeesList = new List<SelectListItem>();
                    List<SelectListItem> departmentsList = new List<SelectListItem>();
                    employeesList = GetEmployees(depEmp.Employees);
                    departmentsList = GetDepartments(depEmp.Departments);

                    ViewBag.SelectedItemEmployees = employeesList;
                    ViewBag.SelectedItemDepartments = departmentsList;

                    if (!string.IsNullOrWhiteSpace(model.DepartmentsEmployeesJson))
                    {
                        List<DepartmentsEmployees> departmentsEmployees = new List<DepartmentsEmployees>();
                        departmentsEmployees = JsonConvert.DeserializeObject<List<DepartmentsEmployees>>(model.DepartmentsEmployeesJson);

                        _departmentEmployeeRepository.Save(departmentsEmployees);
                    }

                    ModelState.Clear();
                    ViewBag.StatusMessage = "Department data was saved!";
                }
                else
                {
                    //var enterprisesList = GetEnterprises();
                    //departmentsDTO.enterprisesList = enterprisesList;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return PartialView("_DepartmentEmployeeManagement", depEmp);
        }

        public ActionResult Update([FromForm] DepartmentsEmployees model)
        {
            try
            {
                _departmentEmployeeRepository.Update(model);

                ModelState.Clear();
                ViewBag.StatusMessage = "Department data was updated!";

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
                _departmentEmployeeRepository.Delete(id);

                ModelState.Clear();
                ViewBag.StatusMessage = "Department data was deleted!";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("GetAll", new { message = ViewBag.StatusMessage });
        }
    }
}
