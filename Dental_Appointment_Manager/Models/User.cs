using Dental_Appointment_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    public class User
    {
        [Key]
        public long userId { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public DateTime? dateOfBirth { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public RoleTitle RoleTitle { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        [Required]
        public DateTime updatedAt { get; set; }

        //RELATIONSHIPS
        public ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Appointment> PatientAppointments { get; set; } // as Patient
        public virtual ICollection<Appointment> DoctorAppointments { get; set; }  // as Doctor
        public virtual ICollection<Appointment> ReceptionistAppointments { get; set; } // as Receptionist
    }
}