using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface ITimeAvailabilityService
    {
        Task<IEnumerable<TimeAvailability>> GetAllTimeAvailability();
    }
}
