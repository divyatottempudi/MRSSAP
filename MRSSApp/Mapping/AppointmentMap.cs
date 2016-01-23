using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MRSSApp.Models;

namespace MRSSApp.Mapping
{
    //DepartmentId
    //DoctorName
    //AppointmentDateTime
    //PersonFirstName
    //PersonLastName
    //PersonAge
    //Gender
    //ContactNumber
    //EmailAddress
    //InternalProblem
    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            this.HasKey(t => t.AppointmentId);

            this.Property(t => t.AlternateNumber).IsOptional();
            this.Property(t => t.DepartmentId).IsRequired();
            this.Property(t => t.DoctorName).IsRequired();
            this.Property(t => t.AppointmentDateTime).IsRequired();
            this.Property(t => t.PersonFirstName).IsRequired();
            this.Property(t => t.PersonLastName).IsRequired();
            this.Property(t => t.PersonAge).IsRequired();
            this.Property(t => t.Gender).IsRequired();
            this.Property(t => t.ContactNumber).IsRequired();
            this.Property(t => t.EmailAddress).IsRequired();
            this.Property(t => t.InternalProblem).IsRequired();
            this.Property(t => t.Prescription).IsOptional();
            this.Property(t => t.PatientUserName).IsOptional();

            this.ToTable("Appointments");
            this.Property(t => t.AppointmentId).HasColumnName("AppointmentId");

            this.Property(t => t.AlternateNumber).HasColumnName("AlternateNumber");
            this.Property(t => t.DepartmentId).IsRequired().HasColumnName("DepartmentId");
            this.Property(t => t.DoctorName).IsRequired().HasColumnName("DoctorName");
            this.Property(t => t.AppointmentDateTime).IsRequired().HasColumnName("AppointmentDateTime");
            this.Property(t => t.PersonFirstName).IsRequired().HasColumnName("PersonFirstName");
            this.Property(t => t.PersonLastName).IsRequired().HasColumnName("PersonLastName");
            this.Property(t => t.PersonAge).IsRequired().HasColumnName("PersonAge");
            this.Property(t => t.Gender).IsRequired().HasColumnName("Gender");
            this.Property(t => t.ContactNumber).IsRequired().HasColumnName("ContactNumber");
            this.Property(t => t.EmailAddress).IsRequired().HasColumnName("EmailAddress");
            this.Property(t => t.InternalProblem).IsRequired().HasColumnName("InternalProblem");
            this.Property(t => t.Prescription).IsOptional().HasColumnName("Prescription");
            this.Property(t => t.PatientUserName).IsOptional().HasColumnName("PatientUserName");

        }
    }
}