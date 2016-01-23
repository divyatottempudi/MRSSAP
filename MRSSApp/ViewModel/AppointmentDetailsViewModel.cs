using MRSSApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSSApp.ViewModel
{
    public class AppointmentDetailsViewModel
    {
        public bool CanEdit { get; set; }
        public string ControllerName { get; set; }
        public Appointment Appointment { get; set; }
    }
}