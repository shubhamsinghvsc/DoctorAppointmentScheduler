using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface ITimeAvailabilityRepository
    {
        Task<IEnumerable<TimeAvailability>> GetAll();
    }
}
