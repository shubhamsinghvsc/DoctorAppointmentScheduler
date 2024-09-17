using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface ITimeAvailabilityRepository
    {
        Task<IEnumerable<TimeAvailability>> GetAll();
        Task<IEnumerable<TimeAvailability>> GetByDoctorId(int id);
        Task CreateTimeAvailability(TimeAvailability timeAvailability);
    }
}
