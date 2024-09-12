using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetById(int id);
    }
}
