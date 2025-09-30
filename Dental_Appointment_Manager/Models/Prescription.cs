using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    //Đơn thuốc
    public class Prescription
    {
        [Key]
        public int prescription_id { get; set; }
        [Required]
        public int consulation_id{ get; set; }
        [Required]
        public int medicine_id{ get; set; }
        [Required]
        public int quantity{ get; set; }
        public string dosage_instructions{ get; set; }

        public ICollection<Medicine> Medicines { get; set; }
    }
}