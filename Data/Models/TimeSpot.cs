using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBeauty.Models
{
    public class TimeSpot
    {
        [Key]
        public int TimeSpotID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string TimeSpotName { get; set; }

        //public ICollection<Appointment> Appointments { get; set; }
    }
}