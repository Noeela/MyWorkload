using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviation.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Resource Type")]
        public string ResourceType { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Additional Notes")]
        public string? Notes { get; set; }

        public DateTime DonatedAt { get; set; } = DateTime.UtcNow;
        public string? DonorId { get; set; }
    }
}
