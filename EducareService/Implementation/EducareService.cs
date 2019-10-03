using EducareApplication.EducareService;
using EducareApplication.EducareService.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa.MVC;


namespace EducareApplication.Educareervice.Implementation
{
    public class Educareservice : Controller, IEducareService
    {
        private readonly LocalDbContext _localDbContext;

        public Educareservice(LocalDbContext localDbContext)
        {
            _localDbContext = localDbContext;
        }

        IList<AdmissionTable> IEducareService.GenerateRegistration(AdmissionTable _admissionTable, string ImgUrl)
        {
            try
            {
                var _NewAdmission = new AdmissionTable();
                _NewAdmission.STU_NAME = _admissionTable.STU_NAME;
                _NewAdmission.STU_F_NAME = _admissionTable.STU_F_NAME;
                _NewAdmission.STU_PAR_ADD = _admissionTable.STU_PAR_ADD;
                _NewAdmission.STU_CURR_ADD = _admissionTable.STU_CURR_ADD;
                _NewAdmission.STU_NATI = _admissionTable.STU_NATI;
                _NewAdmission.STU_GENDER = _admissionTable.STU_GENDER;
                _NewAdmission.STU_PHOTO = _admissionTable.STU_PHOTO;
                _NewAdmission.STU_MOBILE = _admissionTable.STU_MOBILE;
                _NewAdmission.STU_DOB = _admissionTable.STU_DOB;
                _NewAdmission.STU_DOA = _admissionTable.STU_DOA;
                _NewAdmission.STU_HOB = _admissionTable.STU_HOB;
                _NewAdmission.STU_HPASS_Y = _admissionTable.STU_HPASS_Y;
                _NewAdmission.STU_HPER = _admissionTable.STU_HPER;
                _NewAdmission.STU_HUNI = _admissionTable.STU_HUNI;
                _NewAdmission.STU_HROLL = _admissionTable.STU_HROLL;
                _NewAdmission.STU_IPASS_Y = _admissionTable.STU_IPASS_Y;
                _NewAdmission.STU_IPER = _admissionTable.STU_IPER;
                _NewAdmission.STU_IUNI = _admissionTable.STU_IUNI;
                _NewAdmission.STU_IROLL = _admissionTable.STU_IROLL;
                _NewAdmission.ImgURL = ImgUrl;

                _NewAdmission.STU_CITY = _localDbContext.GetCities()
                                             .SingleOrDefault(c => c.S_s_ID == _admissionTable.STU_CITY)
                                             ?.CITY_NAME ?? "NA";

                _NewAdmission.STU_STATE = _localDbContext.GetStates()
                                              .SingleOrDefault(c =>
                                                  c.STATE_ID == Convert.ToInt64(_admissionTable.STU_STATE))
                                              ?.STATE_NAME ?? "NA";

                _NewAdmission.STU_COUNTRY = _localDbContext.GetCountrys()
                                                .SingleOrDefault(c =>
                                                    c.CountryId == Convert.ToInt64(_admissionTable.STU_COUNTRY))
                                                ?.CountryName ?? "NA";


                _NewAdmission.STU_QUAL = _localDbContext.GetQualifications()
                                             .SingleOrDefault(c =>
                                                 c.QualificationID == Convert.ToInt64(_admissionTable.STU_QUAL))
                                             ?.Qualification ?? "NA";

                _NewAdmission.STU_COURSE = _localDbContext.GetCourse()
                                               .SingleOrDefault(c =>
                                                   c.COURSE_ID == Convert.ToInt64(_admissionTable.STU_COURSE))
                                               ?.COURSE_NAME ?? "NA";


                IList<AdmissionTable> newAdmission = new List<AdmissionTable>
                {
                    _NewAdmission
                };
                return newAdmission;
            }
            catch (Exception e)
            {
                return new List<AdmissionTable>();
            }
        }


        IList<SelectListItem> IEducareService.GetCountry()
        {
            IList<SelectListItem> _countryList = new List<SelectListItem>();
            var _country = _localDbContext.GetCountrys().ToList();
            _country.ForEach(x =>
            {
                _countryList.Add(new SelectListItem {Text = x.CountryName, Value = x.CountryId.ToString()});
            });
            return _countryList;
        }

        JsonResult IEducareService.GetStates(string CountryId)
        {
            var _StateList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(CountryId))
            {
                var _states = _localDbContext.GetStates().Where(x => x.CO_S_ID == CountryId).ToList();
                _states.ForEach(x =>
                {
                    _StateList.Add(new SelectListItem {Text = x.STATE_NAME, Value = x.STATE_ID.ToString()});
                });
            }

            return Json(_StateList, JsonRequestBehavior.AllowGet);
        }

        JsonResult IEducareService.GetCities(string StateId)
        {
            var _CityList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(StateId))
            {
                var _City = _localDbContext.GetCities().Where(x => x.S_s_ID == StateId).ToList();
                _City.ForEach(x =>
                {
                    _CityList.Add(new SelectListItem {Text = x.CITY_NAME, Value = x.CITY_ID.ToString()});
                });
            }

            return Json(_CityList, JsonRequestBehavior.AllowGet);
        }

        bool IEducareService.IsUserAuthenticated(ClaimUserIdentity user)
        {
            return string.Equals(user.Role, "Admin", StringComparison.CurrentCultureIgnoreCase)
                ? _localDbContext.ClaimUserIdentity()
                    .Any(u => u.username == user.username && u.Password == user.Password)
                : _localDbContext.ClaimUserIdentity()
                    .Any(u => u.username == user.username && u.Password == user.Password);
        }

        IList<SelectListItem> IEducareService.GetStates()
        {
            return new List<SelectListItem> {new SelectListItem()};
        }

        IList<SelectListItem> IEducareService.GetCities()
        {
            return new List<SelectListItem> {new SelectListItem()};
        }

        IList<SelectListItem> IEducareService.GetCourse()
        {
            return new List<SelectListItem> {new SelectListItem()};
        }

        IList<SelectListItem> IEducareService.GetQualification()
        {
            IList<SelectListItem> _QualificationList = new List<SelectListItem>();
            var _Qualification = _localDbContext.GetQualifications().ToList();
            _Qualification.ForEach(x =>
            {
                _QualificationList.Add(new SelectListItem
                    {Text = x.Qualification, Value = x.QualificationID.ToString()});
            });
            return _QualificationList;
        }

        JsonResult IEducareService.GetCourse(string CourseId)
        {
            var _CourseList = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(CourseId))
            {
                var _Course = _localDbContext.GetCourse().Where(x => x.s_c_id == CourseId).ToList();
                _Course.ForEach(x =>
                {
                    _CourseList.Add(new SelectListItem {Text = x.COURSE_NAME, Value = x.COURSE_ID.ToString()});
                });
            }

            return Json(_CourseList, JsonRequestBehavior.AllowGet);
        }

        IList<SelectListItem> IEducareService.GetGender()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Male", Value = "Male"},
                new SelectListItem {Text = "FeMale", Value = "FeMale"},
                new SelectListItem {Text = "Other", Value = "Other"}
            };
        }

        IList<AdmissionTable> IEducareService.GetAdmissions()
        {
            return _localDbContext.GetStudentData();
        }


        IList<AdmissionTable> IEducareService.FilterAdmissions(AdmissionTable _admission, string Filter)
        {
            if (Filter == "Name")
                return _localDbContext.GetStudentData().Where(a => a.STU_ID == _admission.STU_ID)
                    .OrderByDescending(a => a.STU_DOA).ToList();
            return
                _localDbContext.GetStudentData().Where(a => a.STU_F_NAME == _admission.STU_F_NAME)
                    .OrderByDescending(a => a.STU_DOA).ToList();
        }

        AdmissionTable IEducareService.AdmissionPageGenerater(AdmissionTable _admission)
        {
            return _localDbContext.GetStudentData().SingleOrDefault(s => s.STU_ID == _admission.STU_ID);
        }

        ActionAsPdf IEducareService.GeneraterPDF(string ActionName)
        {
            return new ActionAsPdf(nameof(ActionName));
        }

        AdmissionTable IEducareService.FilterAdmissionsbyRegistrationID(string Registrationid)
        {
            var student = Convert.ToInt64(Registrationid);
            var _admission = _localDbContext.GetStudentData().SingleOrDefault(a => a.STU_ID == student);
            return _admission;
        }

        IList<AdmissionTable> IEducareService.FilterAdmissions(string RegistrationId, string StudentName)
        {
            long student = 0;
            if (!string.IsNullOrEmpty(RegistrationId)) student = Convert.ToInt64(RegistrationId);
            return string.IsNullOrEmpty(RegistrationId) == false
                ? _localDbContext.GetStudentData().Where(r => r.STU_ID == student).ToList()
                : _localDbContext.GetStudentData().Where(name => name.STU_NAME.StartsWith(StudentName)).ToList();
        }
    }


    public class LocalDbContext
    {
        public IList<AdmissionTable> GetStudentData()
        {
            return new List<AdmissionTable>
            {
                new AdmissionTable
                {
                    STU_NAME = "Jhon",
                    STU_F_NAME = "kerry",
                    STU_PAR_ADD = "2019-20-12",
                    STU_CURR_ADD = "101 Nill Street New york city",
                    STU_CITY = "New York City",
                    STU_STATE = "New York",
                    STU_COUNTRY = "USA",
                    STU_NATI = "American",
                    STU_GENDER = "Male",
                    STU_QUAL = "Graduate",
                    STU_COURSE = "BE",
                    STU_PHOTO = "/Images/pexels-photo-315987.jpeg",
                    STU_MOBILE = "00000000000",
                    STU_DOB = "1997-20-12",
                    STU_DOA = "2019-20-12",
                    STU_HOB = "singing",
                    STU_HPASS_Y = "2010-20-10",
                    STU_HPER = "80",
                    STU_HUNI = "New york university",
                    STU_HROLL = "123cxvbncx",
                    STU_IPASS_Y = "2012-20-10",
                    STU_IPER = "90",
                    STU_IUNI = "New york university",
                    STU_IROLL = "2323232323",
                    ImgURL = "/Images/pexels-photo-315987.jpeg",
                    STU_ID = 12121
                },
                new AdmissionTable
                {
                    STU_NAME = "Rakesh",
                    STU_F_NAME = "R",
                    STU_PAR_ADD = "2019-20-12",
                    STU_CURR_ADD = "101 Nill Street New Delhi",
                    STU_CITY = "New Delhi",
                    STU_STATE = "Delhi",
                    STU_COUNTRY = "India",
                    STU_NATI = "Indian",
                    STU_GENDER = "Male",
                    STU_QUAL = "Graduate",
                    STU_COURSE = "BE",
                    STU_PHOTO = "/Images/1366x768-hd-backgrounds-4002894.jpg",
                    STU_MOBILE = "00000000000",
                    STU_DOB = "1997-20-12",
                    STU_DOA = "2019-20-12",
                    STU_HOB = "singing",
                    STU_HPASS_Y = "2010-20-10",
                    STU_HPER = "80",
                    STU_HUNI = "Delhi university",
                    STU_HROLL = "123cxvbncx",
                    STU_IPASS_Y = "2012-20-10",
                    STU_IPER = "90",
                    STU_IUNI = "Delhi university",
                    STU_IROLL = "2323232323",
                    ImgURL = "/Images/1366x768-hd-backgrounds-4002894.jpg",
                    STU_ID = 1221
                },
                new AdmissionTable
                {
                    STU_NAME = "Remo",
                    STU_F_NAME = "sevenson",
                    STU_PAR_ADD = "2019-20-12",
                    STU_CURR_ADD = "101 Nill Street UK",
                    STU_CITY = "London",
                    STU_STATE = "London",
                    STU_COUNTRY = "UK",
                    STU_NATI = "UK",
                    STU_GENDER = "Male",
                    STU_QUAL = "Graduate",
                    STU_COURSE = "BE",
                    STU_PHOTO = "/Images/pexels-photo-994605.jpeg",
                    STU_MOBILE = "00000000000",
                    STU_DOB = "1997-20-12",
                    STU_DOA = "2019-20-12",
                    STU_HOB = "singing",
                    STU_HPASS_Y = "2010-20-10",
                    STU_HPER = "80",
                    STU_HUNI = "UK university",
                    STU_HROLL = "123cxvbncx",
                    STU_IPASS_Y = "2012-20-10",
                    STU_IPER = "90",
                    STU_IUNI = "UK university",
                    STU_IROLL = "2323232323",
                    ImgURL = "/Images/pexels-photo-994605.jpeg",
                    STU_ID = 121321
                },
                new AdmissionTable
                {
                    STU_NAME = "Jesika",
                    STU_F_NAME = "melon",
                    STU_PAR_ADD = "2019-20-12",
                    STU_CURR_ADD = "101 new height Street russia",
                    STU_CITY = "moscow",
                    STU_STATE = "moscow",
                    STU_COUNTRY = "Russia",
                    STU_NATI = "Russian",
                    STU_GENDER = "FeMale",
                    STU_QUAL = "Graduate",
                    STU_COURSE = "BE",
                    STU_PHOTO = "/Images/pexels-photo-458819.jpeg",
                    STU_MOBILE = "00000000000",
                    STU_DOB = "1997-20-12",
                    STU_DOA = "2019-20-12",
                    STU_HOB = "singing",
                    STU_HPASS_Y = "2010-20-10",
                    STU_HPER = "80",
                    STU_HUNI = "moscow university",
                    STU_HROLL = "123cxvbncx",
                    STU_IPASS_Y = "2012-20-10",
                    STU_IPER = "90",
                    STU_IUNI = "moscow university",
                    STU_IROLL = "2323232323",
                    ImgURL = "/Images/pexels-photo-458819.jpeg",
                    STU_ID = 121221
                }
            };
        }

        public IList<QualificationTable> GetQualifications()
        {
            return new List<QualificationTable>
            {
                new QualificationTable
                {
                    Qualification = "Intermediate",
                    QualificationID = 2
                },

                new QualificationTable
                {
                    Qualification = "Under Graduate",
                    QualificationID = 1
                }
            };
        }

        public IList<CountryTable> GetCountrys()
        {
            return new List<CountryTable>
            {
                new CountryTable
                {
                    CountryName = "USA",
                    CountryId = 1
                },

                new CountryTable
                {
                    CountryName = "India",
                    CountryId = 2
                }
            };
        }

        public IList<StateTable> GetStates()
        {
            return new List<StateTable>
            {
                new StateTable
                {
                    STATE_NAME = "California",
                    STATE_ID = 1,
                    CO_S_ID = "1"
                },

                new StateTable
                {
                    STATE_NAME = "Maharashtra",
                    STATE_ID = 2,
                    CO_S_ID = "2"
                }
            };
        }

        public IList<CityTable> GetCities()
        {
            return new List<CityTable>
            {
                new CityTable
                {
                    CITY_NAME = "California",
                    CITY_ID = 1,
                    S_C_ID = "1",
                    S_s_ID = "1"
                },

                new CityTable
                {
                    CITY_NAME = "Mumbai",
                    CITY_ID = 2,
                    S_C_ID = "2",
                    S_s_ID = "2"
                }
            };
        }

        public IList<CourseTable> GetCourse()
        {
            return new List<CourseTable>
            {
                new CourseTable
                {
                    COURSE_NAME = "MCA",
                    COURSE_FEES = "250000",
                    COURSE_ID = 1,
                    s_c_id = "1"
                },

                new CourseTable
                {
                    COURSE_NAME = "BCA",
                    COURSE_FEES = "150000",
                    COURSE_ID = 2,
                    s_c_id = "2"
                }
            };
        }

        public IList<ClaimUserIdentity> ClaimUserIdentity()
        {
            return new List<ClaimUserIdentity>
            {
                new ClaimUserIdentity
                {
                    username = "admin",
                    Password = "1234"
                }
            };
        }



    }

}
    
