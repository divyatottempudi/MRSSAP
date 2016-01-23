using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSSApp.ViewModel
{
    public class AdminAppointmentListViewModel
    {
        public AdminAppointmentListViewModel()
        {
            AdminAppointments = new List<AdminAppointment>();
        }

        public List<AdminAppointment> AdminAppointments { get; set; }

    }

    public class AdminAppointment
    {
        public int AppointmentId { get; set; }
        public string Confirmation { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string PatientPhoneNumber { get; set; }
        public int Gender { get; set; }
    }
}