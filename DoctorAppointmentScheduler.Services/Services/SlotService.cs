using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class SlotService : ISlotService
    {
        private readonly ITimeAvailabilityService _timeAvailabilityService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public SlotService(ITimeAvailabilityService timeAvailabilityService, IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _timeAvailabilityService = timeAvailabilityService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        public async Task<IEnumerable<Slot>> GetSlot(DateTime appointmentDate, int doctorId)
        {
            var timeAvailability = await _timeAvailabilityService.GetAllTimeAvailability();
            var existingAppointments = await _appointmentService.GetAllAppointmentsAsync();
            List<Slot> DoctorSlots = new List<Slot>();
            List<TimeAvailability> timeAvailabilities = timeAvailability.Where(t => t.DoctorId == doctorId && t.Day == appointmentDate.DayOfWeek).ToList();
            var doctor = await _doctorService.GetDoctorById(doctorId);
            int i = 1;
            foreach (TimeAvailability timeAvailable in timeAvailabilities)
            {
                TimeSpan EndTime = timeAvailable.EndTime;
                TimeSpan currentTime = timeAvailable.StartTime;

                while (currentTime < EndTime)
                {
                    TimeSpan endTime = currentTime.Add(doctor.DiagnosisDuration);

                    if (endTime <= EndTime)
                    {
                        bool isAvailable = !existingAppointments.Any(a => a.AppointmentDate.TimeOfDay == currentTime && a.DoctorId == doctor.DoctorId && a.AppointmentDate.Date == appointmentDate);
                        string status = isAvailable ? "Available" : "Unavailable";
                        DoctorSlots.Add(new Slot { SlotId = $"S{i}", StartTime = currentTime, EndTime = endTime, Status = status });
                        currentTime = endTime;
                    }
                    else
                    {
                        break;
                    }
                    i++;

                }
            }
            return DoctorSlots;
        }
    }
}
