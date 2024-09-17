using DoctorAppointmentScheduler.Models.Models.Enums;

namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderSelector Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
