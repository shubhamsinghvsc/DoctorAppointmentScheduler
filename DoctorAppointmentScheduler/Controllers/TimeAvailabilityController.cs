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
    }
}
