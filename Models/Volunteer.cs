using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthdayConnections.Models
{
    /// <summary>
    /// Represents a volunteer interested in helping with Birthday Connections
    /// </summary>
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }

        // Personal Information
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();

        // Contact
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        // Volunteer Preferences
        [Display(Name = "Interested Roles")]
        public string? InterestedRoles { get; set; }

        [Display(Name = "Preferred Frequency")]
        public VolunteerFrequency? Frequency { get; set; }

        [Display(Name = "Available Start Date")]
        [DataType(DataType.Date)]
        public DateTime? AvailableFrom { get; set; }

        [Display(Name = "Has Reliable Transportation")]
        public bool HasTransportation { get; set; } = false;

        [Display(Name = "Can Lift 25+ lbs")]
        public bool CanLiftPackages { get; set; } = false;

        // Admin / Tracking
        [Display(Name = "Date Submitted")]
        [DataType(DataType.DateTime)]
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Status")]
        public VolunteerStatus Status { get; set; } = VolunteerStatus.Pending;

        [Display(Name = "Admin Notes")]
        public string? AdminNotes { get; set; }

        public bool IsContacted { get; set; } = false;
        public DateTime? ContactedAt { get; set; }
        public string? ContactedBy { get; set; }
    }

    // Enums for structured data
    public enum VolunteerFrequency
    {
        [Display(Name = "One-time")]
        OneTime = 0,

        [Display(Name = "Monthly")]
        Monthly = 1,

        [Display(Name = "Bi-weekly")]
        BiWeekly = 2,

        [Display(Name = "Weekly")]
        Weekly = 3,

        [Display(Name = "As needed")]
        AsNeeded = 4
    }

    public enum VolunteerStatus
    {
        [Display(Name = "Pending Review")]
        Pending = 0,

        [Display(Name = "Approved")]
        Approved = 1,

        [Display(Name = "Rejected")]
        Rejected = 2,

        [Display(Name = "Active")]
        Active = 3,

        [Display(Name = "Inactive")]
        Inactive = 4
    }
}