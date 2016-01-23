using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MRSSApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public string UserName { get; set; }

        //[ForeignKey("SpecializationId")]
        //public virtual Specialization Specialization { get; set; }
    }
}