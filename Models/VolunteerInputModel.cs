using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using BirthdayMarket_v1.Models;
using BirthdayConnections.Models;

namespace BirthdayMarket_v1.Models
{
    public class VolunteerInputModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Display(Name = "Tell us what roles interest you")]
        public string? InterestedRoles { get; set; }

        [Display(Name = "How often would you like to volunteer?")]
        public VolunteerFrequency Frequency { get; set; }

        [Display(Name = "I have reliable transportation")]
        public bool HasTransportation { get; set; }

        [Display(Name = "I can lift packages (25+ lbs)")]
        public bool CanLiftPackages { get; set; }
    }
}