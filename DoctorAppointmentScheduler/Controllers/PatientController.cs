using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DoctorAppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public PatientController(IPatientService patientService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            return Ok(await _patientService.GetAllPatient());
        }

        [HttpGet("{contactNumber}")]
        public async Task<IActionResult> GetPatientByContactNumber(string contactNumber)
        {
            var patient = await _patientService.GetPatientByContactNumber(contactNumber);
            var doctor = await _doctorService.GetAllDoctor();

            if (patient.IsNullOrEmpty())
            {
                return BadRequest("Patient is not Registered");
            }

            var response = new
            {
                Patient = patient,
                Doctor = doctor
            };


            return Ok(response);
        }
    }
}
