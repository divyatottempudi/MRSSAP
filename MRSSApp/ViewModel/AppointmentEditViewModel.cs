using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRSSApp.Models;

namespace MRSSApp.ViewModel
{
    public class AppointmentEditViewModel
    {
        public string ControllerName { get; set; }
        public Appointment Appointment { get; set; }
    }
}