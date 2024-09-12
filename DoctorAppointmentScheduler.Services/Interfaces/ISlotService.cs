using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface ISlotService
    {
        Task<IEnumerable<Slot>> GetSlot(DateTime appointmentDate, int doctorId);
    }
}
