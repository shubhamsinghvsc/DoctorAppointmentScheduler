using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Repositories
{
    public class TimeAvailabilityRepository : ITimeAvailabilityRepository
    {
        private readonly AppDbContext _context;

        public TimeAvailabilityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeAvailability>> GetAll()
        {
            return await _context.TimeAvailabilities.ToListAsync();
        }

    }
}
