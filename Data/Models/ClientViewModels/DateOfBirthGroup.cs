using System;
using System.ComponentModel.DataAnnotations;

namespace SmartBeauty.Models.ClientViewModels
{
    public class DateOfBirthGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public int ClientCount { get; set; }
    }
}
