using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MRSSApp.Helpers;
using MRSSApp.Models;
using MRSSApp.ViewModel;

namespace MRSSApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private MRSSAppContext db = new MRSSAppContext();

        // GET: Appointments
        public ActionResult Index()
        {
            return View(db.Appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            var vm = new AppointmentDetailsViewModel()
            {
                Appointment = appointment
            };
            if (User.IsInRole("Doctor"))
            { 
                vm.ControllerName = "AppointmentList";
                vm.CanEdit = true;
            }
            if (User.IsInRole("Patient"))
            { 
                vm.ControllerName = "PatientAppointmentList";
                vm.CanEdit = false;
            }
            if (User.IsInRole("Admin"))
            { 
                vm.ControllerName = "AdminAppointmentList";
                vm.CanEdit = true;
            }
            return View(vm);
        }

        // GET: Appointments/Create
        [Authorize(Roles = "Patient")]
        public ActionResult Create()
        {
            List<KeyValuePair<int, string>> genderList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Male"),
                new KeyValuePair<int, string>(2, "Female")
            };
            var appointment = new CreateAppointmentViewModel()
            {
                ErrorMessage = string.Empty,
                PersonAge = default(int),
                GenderList = new SelectList(genderList, "Key", "Value"),
                DoctorList = new SelectList(new DoctorsHelper(db).Doctors, "Key", "Value"),
                DepartmentList = new SelectList(new DepartmentListHelper().Departments, "Key", "Value")
            };
            return View(appointment);
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,DepartmentId,DoctorName,AppointmentDateTime,PersonFirstName,PersonLastName,PersonAge,Gender,ContactNumber,AlternateNumber,EmailAddress,InternalProblem")] CreateAppointmentViewModel appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Appointment appReq = db.Appointments.Create();
                    appReq.AlternateNumber = appointment.AlternateNumber;
                    appReq.AppointmentDateTime = appointment.AppointmentDateTime;
                    appReq.ContactNumber = appointment.ContactNumber;
                    appReq.DepartmentId = appointment.DepartmentId;
                    appReq.DoctorName = appointment.DoctorName;
                    appReq.EmailAddress = appointment.EmailAddress;
                    appReq.Gender = appointment.Gender;
                    appReq.InternalProblem = appointment.InternalProblem;
                    appReq.PersonAge = appointment.PersonAge;
                    appReq.PersonFirstName = appointment.PersonFirstName;
                    appReq.PersonLastName = appointment.PersonLastName;
                    appReq.ConfirmationToken = GuidEncoder.Encode(Guid.NewGuid());

                    db.Appointments.Add(appReq);
                    db.SaveChanges();

                    return RedirectToAction("Confirmation", new { appointmentId = appReq.AppointmentId });

                }
                catch (Exception)
                {
                    appointment.ErrorMessage =
                        "An error occured during processing the transaction. Try agina or please call 1-800-111-2222 to make an appoint";
                    return View(appointment);
                }
            }
            return View(appointment);
            
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            var vm = new AppointmentEditViewModel()
            {
                Appointment = appointment
            };
            if (User.IsInRole("Doctor"))
                vm.ControllerName = "AppointmentList";
            if (User.IsInRole("Patient"))
                vm.ControllerName = "PatientAppointmentList";
            if (User.IsInRole("Admin"))
                vm.ControllerName = "AdminAppointmentList";
            return View(vm);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointmentEditViewModel viewModel)
        {
            var appointment = viewModel.Appointment;
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AppointmentList");
            }
            return View(viewModel);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Confirmation(int? appointmentId)
        {
            Appointment appointment = db.Appointments.Find(appointmentId);
            var confirmVM = new ConfirmationViewModel();
            confirmVM.ConfirmationNumber = appointment.ConfirmationToken;
            confirmVM.AllottedTime = appointment.AppointmentDateTime.Value.ToString("MMMM dd, yyyy") + " at " +
                appointment.AppointmentDateTime.Value.Hour.ToString() + " to " + appointment.AppointmentDateTime.Value.AddHours(1).Hour.ToString();

            return View(confirmVM);
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult AppointmentList()
        {
            var userName = User.Identity.GetUserName();
            var doctor = db.Doctors.FirstOrDefault(o => o.UserName == userName);
            var appointmentList =
                db.Appointments.Where(
                    o => o.DoctorName == doctor.UserName)
                    .ToList();

            AppointmentListViewModel vm=new AppointmentListViewModel();
            vm.DoctorName = doctor.FirstName + " " + doctor.LastName;
            vm.ApoointmentModels = appointmentList.Where(o=> o.AppointmentDateTime.Value.Date >= DateTime.Now.Date).ToList();
            vm.HighAlertCount =
                appointmentList.Where(o => o.AppointmentDateTime.Value.Date == DateTime.UtcNow.Date).Count();
            vm.MidAlertCount =
                appointmentList.Where(o => o.AppointmentDateTime.Value.Date == DateTime.UtcNow.AddDays(1).Date).Count();
            vm.NoRiskAlertCount =
                appointmentList.Where(o => o.AppointmentDateTime.Value.Date > DateTime.UtcNow.AddDays(1).Date).Count();



            return View(vm);
        }

        [Authorize(Roles = "Patient")]
        public ActionResult PatientAppointmentList()
        {
            var userName = User.Identity.GetUserName();
            var appointmentList =
                db.Appointments.Where(
                    o => o.PatientUserName == userName)
                    .ToList();

            AppointmentListViewModel vm = new AppointmentListViewModel();
            vm.PatientName = userName;
            vm.ApoointmentModels = appointmentList;
            
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminAppointmentList()
        {
            var vm = new AdminAppointmentListViewModel();
            var appointmentList =
                db.Appointments
                    .ToList();

            foreach (var appointment in appointmentList.Where(
                    o => o.AppointmentDateTime.Value.Date == DateTime.UtcNow.Date))
            {
                var doctor = db.Doctors.Where(o => o.UserName == appointment.DoctorName).FirstOrDefault();
                vm.AdminAppointments.Add(new AdminAppointment()
                {
                    AppointmentId = appointment.AppointmentId,
                    Confirmation = appointment.ConfirmationToken,
                    PatientName = appointment.PersonFirstName + " " + appointment.PersonLastName,
                    DoctorName = doctor != null ? (doctor.FirstName + " " + doctor.LastName) : string.Empty,
                    PatientPhoneNumber = appointment.ContactNumber,
                    Gender = appointment.Gender
                });
            }

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
