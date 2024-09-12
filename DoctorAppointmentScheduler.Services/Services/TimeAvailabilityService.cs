using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class TimeAvailabilityService : ITimeAvailabilityService
    {
        private readonly ITimeAvailabilityRepository _timeAvailability;

        public TimeAvailabilityService(ITimeAvailabilityRepository timeAvailability)
        {
            _timeAvailability = timeAvailability;
        }

        public async Task<IEnumerable<TimeAvailability>> GetAllTimeAvailability()
        {
            return await _timeAvailability.GetAll();
        }
    }
}
