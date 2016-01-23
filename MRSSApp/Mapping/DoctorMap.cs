using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MRSSApp.Models;

namespace MRSSApp.Mapping
{
    public class DoctorMap : EntityTypeConfiguration<Doctor>
    {
        public DoctorMap()
        {
            this.HasKey(t => t.DoctorId);

            this.Property(t => t.FirstName).IsRequired();
            this.Property(t => t.LastName).IsRequired();
            this.Property(t => t.EMailAddress).IsRequired();
            this.Property(t => t.UserName).IsRequired();

            this.ToTable("Doctor");
            this.Property(t => t.DoctorId).HasColumnName("DoctorId");

            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).IsRequired().HasColumnName("LastName");
            this.Property(t => t.EMailAddress).IsRequired().HasColumnName("EMailAddress");
            this.Property(t => t.UserName).IsRequired().HasColumnName("UserName");
        }
    }
}