namespace DisasterAlleviation.Models
{
    public class TaskAssignment
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public VolunteerTask Task { get; set; }

        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
