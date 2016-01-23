using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRSSApp.Models;

namespace MRSSApp.Helpers
{
    public class DoctorsHelper
    {
        public List<KeyValuePair<string, string>> Doctors { get; set; }
        public DoctorsHelper(MRSSAppContext context)
        {
            Doctors = new List<KeyValuePair<string, string>>();
            PopulateDoctors(context);
        }

        private void PopulateDoctors(MRSSAppContext context)
        {
            Doctors.Add(new KeyValuePair<string, string>("", string.Empty));
            var doctors = context.Doctors.ToList();
            foreach (var doctor in doctors)
            {
                Doctors.Add(new KeyValuePair<string, string>(doctor.UserName, doctor.FirstName + " " + doctor.LastName));
            }
        }
    }
}