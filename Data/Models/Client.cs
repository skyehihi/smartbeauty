using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SmartBeauty.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        [StringLength(50)]

        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]

        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}