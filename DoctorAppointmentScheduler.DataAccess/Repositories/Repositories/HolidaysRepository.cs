using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Repositories
{
    public class HolidaysRepository : IHolidaysRepository
    {
        private readonly AppDbContext _context;

        public HolidaysRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Holidays>> GetAll()
        {
            return await _context.Holidays.ToListAsync();
        }
    }
}
