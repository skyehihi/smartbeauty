using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class Service
    {
        public int ServiceID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string ServiceName { get; set; }

        //public int SalonID { get; set; }

        public ICollection<ServicePrice> ServicePrices { get; set; }
        public ICollection<SalonService> SalonServices { get; set; }
    }
}