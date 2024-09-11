using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface IHolidaysService
    {
        Task<IEnumerable<Holidays>> GetAllHolidays();
    }
}
