using DepartmentEmployees.Data;
using DepartmentEmployees.Data.Models;
using DepartmentEmployees.Models;
using DepartmentEmployees.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Controllers
{

    public class EnterpriseController : Controller
    {
        private readonly ILogger<EnterpriseController> _logger;
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseController(IEnterpriseRepository enterpriseRepository, ILogger<EnterpriseController> logger)
        {
            _enterpriseRepository = enterpriseRepository;
            _logger = logger;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [Route("[Controller]/GetAll")]
        public IActionResult GetEnterpriseList(string message = "")
        {
            DataModel model = new DataModel();
            model.enterpriseModels = new List<Enterprises>();
            var data = _enterpriseRepository.GetAll();

            model.enterpriseModels = data;
            ViewBag.StatusMessage = message;

            return PartialView("_EnterpriseList", model);
        }

        public Enterprises Get(int id)
        {
            DataModel model = new DataModel();
            var data = _enterpriseRepository.GetById(id);
            model.enterpriseModels.Add(data);

            return data;

        }

        public ActionResult GetById(int id)
        {
            var model = _enterpriseRepository.GetById(id);
            if (model != null)
            {
                return PartialView("_GridEditPartial", model);
            }

            return View();
        }

        public ActionResult EnterprisesDetails()
        {


            return PartialView("_EnterpriseManagement");
        }

        [HttpPost]
        public ActionResult Save([FromForm] Enterprises model)
        {

            try
            {
                _enterpriseRepository.Save(model);


                ModelState.Clear();
                ViewBag.StatusMessage = "Company data was saved!";


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return PartialView("_EnterpriseManagement", model);
        }

        public ActionResult Update([FromForm] Enterprises model)
        {
            try
            {
                _enterpriseRepository.Update(model);

                ModelState.Clear();
                ViewBag.StatusMessage = "Company data was updated!";

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
                _enterpriseRepository.Delete(id);

                ModelState.Clear();
                ViewBag.StatusMessage = "Company data was deleted!";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return RedirectToAction("GetAll", new { message = ViewBag.StatusMessage });
        }

    }
}
