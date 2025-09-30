using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    //Lịch hẹn
    public class Consulation
    {
        [Key]
        public int consulation_id { get; set; }
        [Required]
        public int appointment_id { get; set; }
        [Required]
        public int doctor_id  { get; set; }
        [Required]
        public string dianoisis { get; set; }
        public string notes { get; set; }
        public DateTime? created_at { get; set; }

        // Quan hệ với Appointment
        [Required]
        [ForeignKey("Appointment")]
        public int Appointment_id { get; set; }
        public virtual Appointment Appointment { get; set; }

        // Quan hệ với Doctor (User)
        [Required]
        [ForeignKey("Doctor")]
        public long Doctor_id { get; set; }
        public virtual User Doctor { get; set; }
    }
}