using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class City
    {
        public int CityID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string CityName { get; set; }

        public string Province { get; set; }

        public ICollection<Salon> Salons { get; set; }
    }
}