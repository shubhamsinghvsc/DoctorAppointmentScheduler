using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface ILeaveService
    {
        Task<IEnumerable<Leave>> GetAllLeave();
        Task<IEnumerable<Leave>> GetLeaveByDoctorId(int id);
    }
}
