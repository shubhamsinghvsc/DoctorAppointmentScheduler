using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(int id);

        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int id);
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(int id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);

    }
}
