using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Models;
using DepartmentEmployees.Web.DTO;
using DepartmentEmployees.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace DepartmentEmployees.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository, ILogger<DepartmentController> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public Departments Get(int id)
        {
            DataModel model = new DataModel();
            var data = _departmentRepository.GetById(id);
            model.departmentsModel.Add(data);

            return data;

        }

        public ActionResult GetById(int id)
        {
            var model = _departmentRepository.GetById(id);
            if (model != null)
            {
                List<SelectListItem> enterpriseList = new List<SelectListItem>();
                enterpriseList.Add(new SelectListItem() { Value = model.enterprises.id.ToString(), Text = model.enterprises.name });
                ViewBag.SelectedItem = model.enterprises.name;
                ViewBag.enterprisesList = GetEnterprises();

                return PartialView("_GridEditPartial", model);
            }

            return View();
        }

        public IActionResult GetAll(string message = "")
        {
            DataModel model = new DataModel();
            model.departmentsModel = new List<Departments>();
            var data = _departmentRepository.GetAll();

            model.departmentsModel = data;
            ViewBag.StatusMessage = message;

            return PartialView("_DepartmentList", model);
        }
        public ActionResult DepartmentDetails()
        {

            var enterprisesList = GetEnterprises();
            DepartmentsDTO departmentDTO = new DepartmentsDTO();
            departmentDTO.enterprisesList = enterprisesList;
            return PartialView("_DepartmentManagement", departmentDTO);
        }
        private List<SelectListItem> GetEnterprises()
        {
            var enterprises = _departmentRepository.GetEnterprises();

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (var item in enterprises)
            {
                lst.Add(new SelectListItem() { Value = item.id.ToString(), Text = item.name }); ;
            }
            return lst;
        }


        [HttpPost]
        public ActionResult Save([FromForm] Departments model)
        {
            DepartmentsDTO departmentsDTO = new DepartmentsDTO();
            try
            {
                if (ModelState.IsValid)
                {


                    _departmentRepository.Save(model);

                    var enterprisesList = GetEnterprises();
                    departmentsDTO.enterprisesList = enterprisesList;

                    ModelState.Clear();
                    ViewBag.StatusMessage = "Department data was saved!";
                }
                else
                {
                    var enterprisesList = GetEnterprises();
                    departmentsDTO.enterprisesList = enterprisesList;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return PartialView("_DepartmentManagement", departmentsDTO);
        }

        public ActionResult Update([FromForm] Departments model)
        {
            try
            {
                _departmentRepository.Update(model);

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
                _departmentRepository.Delete(id);

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
