using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviation.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Incident Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Incident Description")]
        public string Description { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }

        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
        public string? ReporterId { get; set; }
    }
}
