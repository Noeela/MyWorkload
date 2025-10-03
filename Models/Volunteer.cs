using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviation.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Display(Name = "Skills")]
        public string? Skills { get; set; }

        public DateTime SignedUpAt { get; set; } = DateTime.UtcNow;
    }
}
