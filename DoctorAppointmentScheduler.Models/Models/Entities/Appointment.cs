using DoctorAppointmentScheduler.Models.Models.Enums;

namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public AppointmentStatus Status { get; set; }

        // Navigation Properties
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}
