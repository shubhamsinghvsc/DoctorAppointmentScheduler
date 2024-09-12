﻿using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<Leave>> GetAll();
        Task<IEnumerable<Leave>> GetByDoctorId(int id);
    }
}
