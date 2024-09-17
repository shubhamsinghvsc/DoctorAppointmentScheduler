using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeave()
        {
            return Ok(await _leaveService.GetAllLeave());
        }

        [HttpGet("GetByDoctorId")]
        public async Task<IActionResult> GetByDoctorId(int id)
        {
            return Ok(await _leaveService.GetLeaveByDoctorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddLeave(Leave leave)
        {
            if (leave == null)
            {
                return BadRequest("Leave can not be NULL.");
            }
            await _leaveService.CreateLeave(leave);
            return CreatedAtAction(nameof(GetByDoctorId), new { id = leave.LeaveId }, leave);

        }
    }
}
