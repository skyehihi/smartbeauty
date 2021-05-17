using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SmartBeauty.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        
        [StringLength(450)]
        public string IdentityID { get; set; }

        [Required]

        [StringLength(50)]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }


        public ICollection<Appointment> Appointments { get; set; }
    }
}