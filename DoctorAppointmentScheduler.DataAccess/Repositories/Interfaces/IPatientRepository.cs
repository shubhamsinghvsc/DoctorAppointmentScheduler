using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAll();
        Task<IEnumerable<Patient>> GetAllByContactNumber(string contactNumber);

    }
}
