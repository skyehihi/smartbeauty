using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBeauty.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int ClientID { get; set; }
        public int SalonID { get; set; }
        public DateTime BookingDate { get; set; }

        public Client Client { get; set; }
        public Salon Salon { get; set; }
    }
}
