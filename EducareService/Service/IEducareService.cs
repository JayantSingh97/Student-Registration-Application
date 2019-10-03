using EducareApplication.Educareervice.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EducareApplication.EducareService.Service
{
    public interface IEducareService
    {

        IList<AdmissionTable> GenerateRegistration(AdmissionTable _admissionTable,string ImgUrl);

        bool IsUserAuthenticated(ClaimUserIdentity user); 

        IList<SelectListItem> GetCountry();

        IList<SelectListItem> GetStates();

        IList<SelectListItem> GetCities();

        IList<SelectListItem> GetCourse();

        IList<SelectListItem> GetQualification();

        JsonResult GetStates(string CountryId);

        JsonResult GetCities(string StateId);

        JsonResult GetCourse(string CourseId);

        IList<SelectListItem> GetGender();

        Rotativa.MVC.ActionAsPdf GeneraterPDF(string ActionName);
         
        IList<AdmissionTable> GetAdmissions();

        IList<AdmissionTable> FilterAdmissions(AdmissionTable _admission, string Filter);

        AdmissionTable AdmissionPageGenerater(AdmissionTable _admission);

        AdmissionTable FilterAdmissionsbyRegistrationID(string Registrationid);

        IList<AdmissionTable> FilterAdmissions(string RegistrationId , string StudentName);

    }
}
