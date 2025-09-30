using Dental_Appointment_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dental_Appointment_Manager.Models
{
    public class Payment
    {
        [Key]
        public int payment_id{ get; set; }
        [Required]
        public int appointment_id{ get; set; }
        [Required]
        public decimal total{ get; set; }
        [Required]
        public DateTime payment{ get; set; }
        [Required]
        public string payment_method{ get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public virtual Appointment Appointment { get; set; }

    }
}