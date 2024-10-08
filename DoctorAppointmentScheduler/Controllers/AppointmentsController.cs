﻿using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;

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
            bool isAppointmentBooked = await _appointmentService.CreateAppointmentAsync(appointment);
            if (appointment == null)
            {
                return BadRequest();
            }
            if (!isAppointmentBooked)
            {
                return BadRequest("Slot is Already Booked");
            }
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
            return Ok(new { message = "Updated Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return Ok(new { message = "Deleted Successfully" });
        }


    }

}
