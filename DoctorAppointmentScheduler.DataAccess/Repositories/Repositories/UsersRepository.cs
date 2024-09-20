using DoctorAppointmentScheduler.DataAccess.Contexts;
using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<Users> GetByContactNumberAsync(string contactNumber)
        {
            return await _context.Users.FindAsync(contactNumber);
        }

        public async Task AddAsync(Users user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int contactNumber)
        {
            var user = await _context.Users.FindAsync(contactNumber);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
