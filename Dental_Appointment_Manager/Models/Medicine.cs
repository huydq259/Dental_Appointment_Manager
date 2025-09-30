using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    public class Medicine
    {
        [Key]
        public int medicine_id { get; set; }
        [Required]
        public string name{ get; set; }
        public string description{ get; set; }
        public string dosage_form{ get; set; }
        [Required]
        public decimal price{ get; set; }
    }
}