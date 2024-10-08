﻿using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
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
        public async Task<IEnumerable<TimeAvailability>> GetTimeAvailabilityByDoctorId(int id)
        {
            return await _timeAvailability.GetByDoctorId(id);
        }

        public async Task CreateTimeAvailability(TimeAvailability timeAvailability)
        {
            await _timeAvailability.AddAsync(timeAvailability);
        }
    }
}
