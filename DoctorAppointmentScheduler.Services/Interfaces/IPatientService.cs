using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatient();
        Task<IEnumerable<Patient>> GetPatientByContactNumber(string contactNumber);
    }
}
