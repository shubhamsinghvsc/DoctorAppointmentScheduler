using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            return await _repository.GetAll();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
