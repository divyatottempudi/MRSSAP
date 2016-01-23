using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MRSSApp.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }
        public string Name { get; set; }
    }
}