using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Repositories
{
    public class ILeaveReopsitory : ILeaveRepository
    {
        private readonly AppDbContext _context;

        public ILeaveReopsitory(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leave>> GetAll()
        {
            return await _context.Leaves.ToListAsync();
        }
    }
}
