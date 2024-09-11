using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    internal interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetAll();
    }
}
