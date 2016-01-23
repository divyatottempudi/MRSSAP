using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MRSSApp.Models;

namespace MRSSApp.ViewModel
{
    public class AppointmentListViewModel
    {
        public AppointmentListViewModel()
        {   
        }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }
        public List<Appointment> ApoointmentModels { get; set; }
        public int HighAlertCount { get; set; }
        public int MidAlertCount { get; set; }
        public int NoRiskAlertCount { get; set; }
    }
}