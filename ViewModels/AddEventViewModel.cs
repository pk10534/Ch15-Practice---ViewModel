using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ch26_Practice_2___Razor_Forms.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3-50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description is too long: 500 characters max")]
        public string Description { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Location must have more than two characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "The number of attendees is requried")]
        [Range(1, 100000, ErrorMessage = "Attendee number must be between 1 and 100,000")]
        public string NumberOfAttendees { get; set; }
    }
}
