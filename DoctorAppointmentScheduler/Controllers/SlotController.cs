using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSlots(DateTime appointmentDate, int doctorId)
        {
            IEnumerable<Slot> slot = await _slotService.GetSlot(appointmentDate, doctorId);
            if (slot.Count() == 1)
            {
                var errorObj = new
                {
                    status = slot.First().Status,
                };
                return BadRequest(errorObj);
            }
            return Ok(slot);
        }
    }
}
