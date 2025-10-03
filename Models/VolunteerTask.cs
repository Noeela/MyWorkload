using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviation.Models
{
    public class VolunteerTask
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Task Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Scheduled Date")]
        public DateTime ScheduledAt { get; set; } = DateTime.UtcNow;


        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public string? Location { get; set; }

        // Navigation property
        public ICollection<TaskAssignment> Assignments { get; set; } = new List<TaskAssignment>();
    }
}
