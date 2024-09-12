using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetAll();
    }
}
