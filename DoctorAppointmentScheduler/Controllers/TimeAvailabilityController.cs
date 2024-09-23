using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeAvailabilityController : ControllerBase
    {
        private readonly ITimeAvailabilityService _timeAvailabilityService;

        public TimeAvailabilityController(ITimeAvailabilityService timeAvailabilityRepository)
        {
            _timeAvailabilityService = timeAvailabilityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeAvailabilities()
        {
            return Ok(await _timeAvailabilityService.GetAllTimeAvailability());
        }

        [HttpGet("GetByDoctorId")]
        public async Task<IActionResult> GetByDoctorId(int DoctorId)
        {
            return Ok(await _timeAvailabilityService.GetTimeAvailabilityByDoctorId(DoctorId));
        }

        [HttpPost]
        public async Task<IActionResult> PostTimeAvailability(TimeAvailability timeAvailability)
        {
            IEnumerable<TimeAvailability> alreadyTimeAvailability = await _timeAvailabilityService.GetTimeAvailabilityByDoctorId(timeAvailability.DoctorId);
            if (timeAvailability == null)
            {
                return BadRequest("Can not be null");
            }
            if (alreadyTimeAvailability.Any(a => a.Day == timeAvailability.Day && a.StartTime == timeAvailability.StartTime && a.EndTime == timeAvailability.EndTime))
            {
                return BadRequest("Schedule already Exists.");
            }
            if (alreadyTimeAvailability.Any(a => a.Day == timeAvailability.Day && (timeAvailability.StartTime >= a.StartTime && timeAvailability.StartTime <= a.EndTime)))
            {
                return NotFound("starting or ending time matches existing scheule");
            }

            await _timeAvailabilityService.CreateTimeAvailability(timeAvailability);
            return CreatedAtAction(nameof(GetByDoctorId), new { id = timeAvailability.DoctorId }, timeAvailability);
        }
    }
}
