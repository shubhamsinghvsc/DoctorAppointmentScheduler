namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class Slot
    {
        public string SlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }
    }
}
