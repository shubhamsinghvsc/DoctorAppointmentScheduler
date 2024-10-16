using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class SlotService : ISlotService
    {
        private readonly ITimeAvailabilityService _timeAvailabilityService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IHolidaysService _holidaysService;
        private readonly ILeaveService _leaveService;

        public SlotService(ITimeAvailabilityService timeAvailabilityService, IAppointmentService appointmentService, IDoctorService doctorService, ILeaveService leaveService, IHolidaysService holidaysService)
        {
            _timeAvailabilityService = timeAvailabilityService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _leaveService = leaveService;
            _holidaysService = holidaysService;
        }

        public async Task<IEnumerable<Slot>> GetSlot(DateTime appointmentDate, int doctorId)
        {
            if (DateTime.Today.Date > appointmentDate)
            {
                return new List<Slot>{
                        new Slot { SlotId = "Past", StartTime = TimeSpan.Zero, EndTime = TimeSpan.Zero, Status = "InvalidDate" }
                        };
            }

            var timeAvailability = await _timeAvailabilityService.GetTimeAvailabilityByDoctorId(doctorId);
            var existingAppointments = await _appointmentService.GetAllAppointmentsAsync();
            var holidays = await _holidaysService.GetAllHolidays();
            var leaves = await _leaveService.GetLeaveByDoctorId(doctorId);
            List<Slot> doctorSlots = new List<Slot>();


            bool isHoliday = holidays.Any(h => h.HolidayDate.Date == appointmentDate);
            bool isOnLeave = leaves.Any(l => l.DoctorId == doctorId && appointmentDate >= l.StartDate.Date && appointmentDate <= l.EndDate.Date);
            bool isScheduled = timeAvailability.Any(t => t.Day == appointmentDate.DayOfWeek);


            if (isHoliday)
            {
                // Add slots with Holiday status
                return new List<Slot> { new Slot { SlotId = "H", StartTime = TimeSpan.Zero, EndTime = TimeSpan.Zero, Status = "Holiday" } };
            }
            else if (isOnLeave)
            {
                // Add slots with Leave status
                return new List<Slot> { new Slot { SlotId = "L", StartTime = TimeSpan.Zero, EndTime = TimeSpan.Zero, Status = "Leave" } };
            }
            else if (!isScheduled)
            {
                // Add slots with NotScheduled status
                return new List<Slot> { new Slot { SlotId = "NS", StartTime = TimeSpan.Zero, EndTime = TimeSpan.Zero, Status = "NotScheduled" } };
            }
            else
            {
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
                            bool isAvailable = !existingAppointments.Any(a => a.AppointmentTime == currentTime && a.DoctorId == doctor.DoctorId && a.AppointmentDate.Date == appointmentDate);
                            string status = isAvailable ? "Available" : "Unavailable";
                            doctorSlots.Add(new Slot { SlotId = $"S{i}", StartTime = currentTime, EndTime = endTime, Status = status });
                            currentTime = endTime;
                        }
                        else
                        {
                            break;
                        }
                        i++;

                    }
                }
                return doctorSlots;
            }
        }
    }
}
