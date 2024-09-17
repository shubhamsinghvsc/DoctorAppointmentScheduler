﻿using DoctorAppointmentScheduler.DataAccess.Contexts;
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
        public async Task<IEnumerable<TimeAvailability>> GetByDoctorId(int id)
        {
            return await _context.TimeAvailabilities.Where(t => t.DoctorId == id).ToListAsync();
        }

        public async Task CreateTimeAvailability(TimeAvailability timeAvailability)
        {
            _context.Add(timeAvailability);
            await _context.SaveChangesAsync();
        }

    }
}
