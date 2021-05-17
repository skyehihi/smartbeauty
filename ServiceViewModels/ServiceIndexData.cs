using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBeauty.Models.SchoolViewModels
{
    public class ServiceIndexData
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Salon> Salons { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}