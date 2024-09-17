using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leave>> GetAll()
        {
            return await _context.Leaves.ToListAsync();
        }
        public async Task<IEnumerable<Leave>> GetByDoctorId(int id)
        {
            return await _context.Leaves.Where(l => l.DoctorId == id).ToListAsync();
        }

        public async Task AddAsync(Leave leave)
        {
            _context.Add(leave);
            await _context.SaveChangesAsync();
        }
    }
}
