using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class SalonService
    {
        public int SalonID { get; set; }
        public int ServiceID { get; set; }
        public Salon Salons { get; set; }
        public Service Services { get; set; }
    }
}