using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class Salon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalonID { get; set; }
        public string SalonName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}