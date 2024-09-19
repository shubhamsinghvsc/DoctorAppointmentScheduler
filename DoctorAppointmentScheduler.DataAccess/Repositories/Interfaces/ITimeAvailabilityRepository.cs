using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface ITimeAvailabilityRepository
    {
        Task<IEnumerable<TimeAvailability>> GetAll();
        Task<IEnumerable<TimeAvailability>> GetByDoctorId(int id);
        Task AddAsync(TimeAvailability timeAvailability);
        Task UpdateAsync(TimeAvailability timeAvailability);
        Task DeleteAsync(int id);
    }
}
