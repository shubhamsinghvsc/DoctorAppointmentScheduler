using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Users user);
    }
}
