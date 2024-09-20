using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;


        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task<List<object>> GetAppointmentByDoctorIdAsync(int id)
        {
            var appointments = await _appointmentRepository.GetByDoctorIdAsync(id);
            return appointments.Select(a => new
            {
                AppointmentId = a.AppointmentId,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                PatientName = a.Patient.Name,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime, //.ToString(@"hh\:mm\:ss"),
                Status = (int)a.Status
            }).ToList<object>();
        }

        public async Task<List<object>> GetAppointmentByPatientIdAsync(int id)
        {
            var appointments = await _appointmentRepository.GetByPatientIdAsync(id);
            return appointments.Select(a => new
            {
                AppointmentId = a.AppointmentId,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                DoctorName = a.Doctor.Name,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime, //.ToString(@"hh\:mm\:ss"),
                Status = (int)a.Status
            }).ToList<object>();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        public async Task<bool> CreateAppointmentAsync(Appointment appointment)
        {
            IEnumerable<Appointment> existingAppointment = await _appointmentRepository.GetAllAsync();
            bool isSlotAvailable = !existingAppointment.Any(a => (a.DoctorId == appointment.DoctorId) && (a.AppointmentDate.Date == appointment.AppointmentDate.Date) && (a.AppointmentTime == appointment.AppointmentTime));

            if (isSlotAvailable)
            {
                await _appointmentRepository.AddAsync(appointment);
                return true;
            }
            return false;
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.UpdateAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }

    }

}
