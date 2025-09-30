using Dental_Appointment_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    public class Appointment
    {
        [Key]
        public int appointment_id { get; set; }
        public DateTime appointment_date { get; set; }
        public TimeSpan appointment_time { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }  // Scheduled, Completed, Cancelled
        public string reason { get; set; }
        public DateTime created_at { get; set; }


        //RELATIONSHIPS
        [ForeignKey("Patient")]
        public long PatientId { get; set; }
        public User Patient { get; set; }


        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }
        public User Doctor { get; set; }


        [ForeignKey("Receptionist")]
        public long? ReceptionistId { get; set; }
        public User Receptionist { get; set; }

    }
}