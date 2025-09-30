using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=Dental_Appointment_Manager") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consulation> Consulations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient_Record> Patient_Records { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
    }

    
}