using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface ILeaveService
    {
        Task<IEnumerable<Leave>> GetAllLeave();
    }
}
