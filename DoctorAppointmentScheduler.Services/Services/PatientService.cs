using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatient()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<IEnumerable<Patient>> GetPatientByContactNumber(string contactNumber)
        {
            var patient = await _patientRepository.GetAllByContactNumber(contactNumber);
            if (patient == null || !patient.Any())
            {

            }
            return patient;
        }

        public async Task CreateNewPatient(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }
    }
}
