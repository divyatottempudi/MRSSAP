using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRSSApp.Models;

namespace MRSSApp.ViewModel
{
    public class CreateAppointmentViewModel
    {
        [Required(ErrorMessage = "Department Required")] // textboxes will show
        [Display(Name = "Department :")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Doctor Name Required")] // textboxes will show
        [Display(Name = "Doctor Name :")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Appointment Date Required")] // textboxes will show
        [Display(Name = "Appointment Date Time :")]
        public DateTime? AppointmentDateTime { get; set; }

        [Required(ErrorMessage = "First Name Required")] // textboxes will show
        [Display(Name = "First Name :")]
        public string PersonFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")] // textboxes will show
        [Display(Name = "Last Name :")]
        public string PersonLastName { get; set; }

        [Required(ErrorMessage = "Age Required")] // textboxes will show
        [Display(Name = "Age :")]
        public int PersonAge { get; set; }

        [Required(ErrorMessage = "Gender Required")]
        [Display(Name = "Gender :")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Telephone Number Required")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number :")]
        public string ContactNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Alternate Number :")]
        public string AlternateNumber { get; set; }

        [Required(ErrorMessage = "Email Address Required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email Address :")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "State Internal Problem")]
        [Display(Name = "Internal Problem :")]
        public string InternalProblem { get; set; }

        public string ErrorMessage { get; set; }

        public SelectList GenderList { get; set; }

        public SelectList DoctorList { get; set; }

        public SelectList DepartmentList { get; set; }
    }
}
