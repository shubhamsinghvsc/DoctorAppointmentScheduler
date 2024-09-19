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

        public async Task AddAsync(Holidays holidays)
        {
            _context.Holidays.Add(holidays);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Holidays holidays)
        {
            _context.Holidays.Update(holidays);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var holidays = await _context.Holidays.FindAsync(id);
            if (holidays != null)
            {
                _context.Holidays.Remove(holidays);
                await _context.SaveChangesAsync();
            }
        }
    }
}
