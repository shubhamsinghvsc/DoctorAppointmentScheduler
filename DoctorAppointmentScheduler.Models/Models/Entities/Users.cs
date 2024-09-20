using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class Users
    {
        [Key]
        public string ContactNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}
