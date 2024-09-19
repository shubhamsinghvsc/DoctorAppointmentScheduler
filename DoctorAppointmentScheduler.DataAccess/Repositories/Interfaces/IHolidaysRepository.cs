using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface IHolidaysRepository
    {
        Task<IEnumerable<Holidays>> GetAll();
        Task AddAsync(Holidays holidays);
        Task UpdateAsync(Holidays holidays);
        Task DeleteAsync(int id);
    }
}
