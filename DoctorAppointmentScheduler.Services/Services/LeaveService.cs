using DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces;
using DoctorAppointmentScheduler.Models.Models.Entities;
using DoctorAppointmentScheduler.Services.Interfaces;

namespace DoctorAppointmentScheduler.Services.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveReopsitory;

        public LeaveService(ILeaveRepository leaveReopsitory)
        {
            _leaveReopsitory = leaveReopsitory;
        }

        public async Task<IEnumerable<Leave>> GetAllLeave()
        {
            return await _leaveReopsitory.GetAll();
        }
        public async Task<IEnumerable<Leave>> GetLeaveByDoctorId(int id)
        {
            return await _leaveReopsitory.GetByDoctorId(id);
        }
    }
}
