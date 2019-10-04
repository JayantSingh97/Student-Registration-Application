using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EducareApplication.EducareService
{
    [MetadataType(typeof(AdmissionModel))]
    public partial class AdmissionTable
    {
    }

    public partial class AdmissionModel
    {
        public long STU_ID { get; set; }

        [Display(Name = "Student Name")]
        [MinLength(5, ErrorMessage = "Name Length Should be >= 5")]
        [MaxLength(15, ErrorMessage = "Name Length Should be <= 15")]
        [Required(ErrorMessage = "Name is Required. Please Fill it out")]
        public string STU_NAME { get; set; }

        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "Father name is Required. Please Fill it out")]
        public string STU_F_NAME { get; set; }

        [Display(Name = "Permanent address")]
        [Required(ErrorMessage = "Permanent address is Required. Please Fill it out")]
        public string STU_PAR_ADD { get; set; }

        [Display(Name = "Current address")]
        [Required(ErrorMessage = "Current address is Required. Please Fill it out")]
        public string STU_CURR_ADD { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City Name is Required. Please select city")]
        public string STU_CITY { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State name is Required. Please select state")]
        public string STU_STATE { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country name is Required. Please select county")]
        public string STU_COUNTRY { get; set; }

        [Display(Name = "Nationality")]
        [Required(ErrorMessage = "Nationality is Required. Please select Nationality")]
        public string STU_NATI { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is Required. Please select gender")]
        public string STU_GENDER { get; set; }

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Qualification is Required. Please select qualification")]
        public string STU_QUAL { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course is Required. Please select your course")]
        public string STU_COURSE { get; set; }

        [Display(Name = "Photo")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Photo is Required. Please select a file")]
        public string STU_PHOTO { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile number is Required. Please enter a mobile")]
        [DataType("number")]
        [MinLength(10, ErrorMessage = "Mobile Number Length Should be >= 10")]
        [MaxLength(11, ErrorMessage = "Mobile Number Length Should be <= 11")]
        public string STU_MOBILE { get; set; }

        [Display(Name = "DOB")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please Select  DOB ")]
        public string STU_DOB { get; set; }

        [Display(Name = "Admission date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please Select admission date ")]
        public string STU_DOA { get; set; }

        [Display(Name = "Hobbies")]
        [Required(ErrorMessage = "Please enter hobbies")]
        public string STU_HOB { get; set; }

        [Display(Name = "Passing year")]
        [DataType("number")]
        [MinLength(2, ErrorMessage = "high school passing year Length Should be >= 2")]
        [MaxLength(4, ErrorMessage = "high school passing year Length Should be <= 4")]
        [Required(ErrorMessage = "Please enter high school passing year")]
        public string STU_HPASS_Y { get; set; }

        [Display(Name = "Percentage")]
        [DataType("number")]
        [MinLength(1, ErrorMessage = "Percentage Length Should be >= 1")]
        [MaxLength(2, ErrorMessage = "Percentage Length Should be <= 3")]
        [Required(ErrorMessage = "Please enter high school passing %")]
        public string STU_HPER { get; set; }

        [Display(Name = "Board/institution")]
        [Required(ErrorMessage = "Please enter high school passing board/institution")]
        public string STU_HUNI { get; set; }

        [Display(Name = "Roll number")]
        [Required(ErrorMessage = "Please enter high school roll number")]
        public string STU_HROLL { get; set; }

        [Display(Name = "Passing year")]
        [DataType("number")]
        [MinLength(2, ErrorMessage = "intermediate passing year Length Should be >= 2")]
        [MaxLength(4, ErrorMessage = "intermediate passing year Should be <= 4")]
        [Required(ErrorMessage = "Please enter intermediate passing year")]
        public string STU_IPASS_Y { get; set; }

        [Display(Name = "Percentage")]
        [DataType("number")]
        [MinLength(1, ErrorMessage = "Percentage Length Should be >= 1")]
        [MaxLength(2, ErrorMessage = "Percentage Length Should be <= 3")]
        [Required(ErrorMessage = "Please enter intermediate passing %")]
        public string STU_IPER { get; set; }

        [Display(Name = "Board/institution")]
        [Required(ErrorMessage = "Please enter intermediate passing  board/institution")]
        public string STU_IUNI { get; set; }

        [Display(Name = "Roll number")]
        [Required(ErrorMessage = "Please enter intermediate passing  roll number")]
        public string STU_IROLL { get; set; }
    }

    public class ClaimUserIdentity
    {
        [Required(ErrorMessage = "Your user Name is requried. Please fill it out !")]
        public string username { get; set; }

        [Required(ErrorMessage = "Your Password is requried. Please fill it out !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is requried. Please select your role !")]
        public string Role { get; set; }
    }
}



