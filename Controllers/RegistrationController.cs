using EducareApplication.Educareervice.Implementation;
using EducareApplication.EducareService;
using EducareApplication.EducareService.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa.MVC;

namespace EducareApplication.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly IEducareService _Repository;
        private readonly string ServcerPath = ConfigurationManager.AppSettings["ServcerPath"];
        private readonly string URLPDF = ConfigurationManager.AppSettings["URLPDF"];

        public RegistrationController(IEducareService repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View(_Repository.GetAdmissions());
        }

        [HttpPost]
        public ActionResult Dashboard(AdmissionTable _admission, string filter)
        {
            return View(_Repository.FilterAdmissions(_admission, filter));
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult AdmissionFilter(string registrationid, string studentName)
        {
            return View(nameof(Dashboard), _Repository.FilterAdmissions(registrationid, studentName));
        }

        [HttpGet]
        public ActionResult AdmissionPageGenerater(string Registrationid)
        {
            return View(_Repository.FilterAdmissionsbyRegistrationID(Registrationid));
        }

        [HttpGet]
        public ActionResult PDFPageGenerater(string RegistrationID)
        {
            return RegistrationID != null ? View(_Repository.FilterAdmissionsbyRegistrationID(RegistrationID)) : View();
        }

        [HttpGet]
        public ActionResult GeneratePDF(string RegistrationID)
        {
            return new UrlAsPdf(URLPDF + RegistrationID);
        }

        [HttpGet]
        public ActionResult GenerateExcelReport()
        {
            var csv = _Repository.GenerateExcelReport();
            HttpContext.Response.Clear();
            HttpContext.Response.AddHeader("content-disposition",
                string.Format("attachment; filename={0}.csv", "Students_Report"));
            HttpContext.Response.ContentType = "text/csv";
            HttpContext.Response.AddHeader("Student_Report", "public");
            HttpContext.Response.Write(csv);
            HttpContext.Response.End();
            return RedirectToAction(nameof(Dashboard));
        }

        [HttpGet]
        public ActionResult GenerateRegistration()
        {
            ViewBag.Country = _Repository.GetCountry();
            ViewBag.State = _Repository.GetStates();
            ViewBag.City = _Repository.GetCities();
            ViewBag.Course = _Repository.GetCourse();
            ViewBag.Qualification = _Repository.GetQualification();
            ViewBag.Gender = _Repository.GetGender();
            return View();
        }

        [HttpPost]
        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateRegistration(AdmissionTable _newAdmissionTable, HttpPostedFileBase STU_PHOTO)
        {
            if (ModelState.IsValid && STU_PHOTO != null)
            {
                var extension = Path.GetExtension(STU_PHOTO.FileName);
                var path = Path.Combine(Server.MapPath(ServcerPath) + STU_PHOTO.FileName);
                var FD = new FileInfo(path);
                if (FD.Exists) FD.Delete();
                STU_PHOTO.SaveAs(path);
                if (_Repository != null)
                {
                    var list = new List<AdmissionTable>();
                    var tables = _Repository.GenerateRegistration(_newAdmissionTable, ServcerPath + STU_PHOTO.FileName);
                    for (var index = tables.Count - 1; index >= 0; index--)
                    {
                        var table = tables[index];
                        list.Add(table);
                    }

                    var _newAdmission = list.SingleOrDefault();
                    ViewBag.Success = true;
                    return View(nameof(AdmissionPageGenerater), _newAdmission);
                }
            }

            return RedirectToAction(nameof(Dashboard));
        }

        [HttpPost]
        [Route(nameof(Dashboard))]
        public JsonResult GetState(string CountryId)
        {
            return _Repository.GetStates(CountryId);
        }

        [HttpPost]
        public JsonResult GetCity(string Stateid)
        {
            return _Repository.GetCities(Stateid);
        }

        [HttpPost]
        public JsonResult GetCourse(string CourseId)
        {
            return _Repository.GetCourse(CourseId);
        }
    }
}
