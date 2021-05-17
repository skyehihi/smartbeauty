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

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public SalonService SalonServices { get; set; }
    }
}