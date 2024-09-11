using DoctorAppointmentScheduler.Models.Models.Enums;

namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class Leave
    {
        public int LeaveId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TypeOfLeave LeaveType { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public Doctor? Doctor { get; set; }
    }
}
