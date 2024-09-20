using DoctorAppointmentScheduler.Models.Models.Entities;

namespace DoctorAppointmentScheduler.DataAccess.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> GetByContactNumberAsync(string contactNumber);
        Task<List<Users>> GetAllAsync();
        Task AddAsync(Users user);
        Task UpdateAsync(Users user);
        Task DeleteAsync(int id);
    }
}
