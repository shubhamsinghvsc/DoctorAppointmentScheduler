using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface IHolidaysRepository
    {
        Task<IEnumerable<Holidays>> GetAll();
    }
}
