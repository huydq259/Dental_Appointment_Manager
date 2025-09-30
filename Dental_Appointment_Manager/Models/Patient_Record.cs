using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    public class Patient_Record
    {
        [Key]
        public int record_id { get; set; }
        [Required]
        public string medical_history { get; set; }
        [Required]
        public string allergies { get; set; }
        public string notes { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }

        //RELATIONSHIP
        public long PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual User Patient { get; set; }

        public long DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual User Doctor { get; set; }
    }
}