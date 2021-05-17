using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class Salon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalonID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        [Display(Name = "Salon Name")]
        public string SalonName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<SalonService> SalonServices { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}