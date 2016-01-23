using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSSApp.Helpers
{
    public class DepartmentListHelper
    {
        public List<KeyValuePair<int, string>> Departments { get; set; }
        public DepartmentListHelper()
        {
            Departments=new List<KeyValuePair<int, string>>();
            PopulateDepartments();
        }

        private void PopulateDepartments()
        {
            Departments.Add(new KeyValuePair<int, string>(1, "Cardiology"));
            Departments.Add(new KeyValuePair<int, string>(2, "Gastroenterology"));
            Departments.Add(new KeyValuePair<int, string>(3, "Onocology"));
            Departments.Add(new KeyValuePair<int, string>(4, "Neurology"));
            Departments.Add(new KeyValuePair<int, string>(5, "Orthhopaedics"));
            Departments.Add(new KeyValuePair<int, string>(6, "Nephrology"));
            Departments.Add(new KeyValuePair<int, string>(7, "Critical Care Management"));
            Departments.Add(new KeyValuePair<int, string>(8, "Pediatrics"));
        }
    }
}