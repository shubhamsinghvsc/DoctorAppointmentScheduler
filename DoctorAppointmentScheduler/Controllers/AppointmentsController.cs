using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("GetDoctorAppointmentHistory")]
        public async Task<IActionResult> GetDoctorAppointmentHistory(int doctorId)
        {
            var appointment = await _appointmentService.GetAppointmentByDoctorIdAsync(doctorId);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpGet("GetPatientAppointmentHistory")]
        public async Task<IActionResult> GetPatientAppointmentHistory(int patientId)
        {
            var appointment = await _appointmentService.GetAppointmentByPatientIdAsync(patientId);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }
            await _appointmentService.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetById), new { id = appointment.AppointmentId }, appointment);
        }










        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest();
            }
            await _appointmentService.UpdateAppointmentAsync(appointment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }
    }

}
