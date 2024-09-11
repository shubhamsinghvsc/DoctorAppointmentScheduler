using DoctorAppointmentScheduler.DataAccess.Repositories.Repositories;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveReopsitory _leaveReopsitory;

        public LeaveService(ILeaveReopsitory leaveReopsitory)
        {
            _leaveReopsitory = leaveReopsitory;
        }

        public async Task<IEnumerable<Leave>> GetAllLeave()
        {
            return await _leaveReopsitory.GetAll();
        }
    }
}
