using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService, IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _tokenService = tokenService;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Users user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user == null)
            {
                return BadRequest("User is null");
            }

            Users isUserExist = await _usersRepository.GetByContactNumberAsync(user.ContactNumber);
            if (isUserExist != null)
            {
                return BadRequest("User Already Exists");
            }

            await _usersRepository.AddAsync(user);
            return Ok(new { message = "User Created Successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(String contactNumber, string password)
        {
            if (contactNumber == null || password == null)
            {
                return BadRequest("Contact Number or Password is NUll");
            }
            Users existingLoginDetail = await _usersRepository.GetByContactNumberAsync(contactNumber);
            if (existingLoginDetail == null)
            {
                return BadRequest("User Does not Exists");
            }

            if (existingLoginDetail.password != password)
            {
                return Unauthorized("Password Does Not Mached (Incorrect Password)");
            }

            var token = _tokenService.GenerateToken(existingLoginDetail);
            return Ok(new { Token = token });


        }
    }
}
