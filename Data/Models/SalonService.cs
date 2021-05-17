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
        public Salon Salon { get; set; }
        public Service Service { get; set; }
    }
}