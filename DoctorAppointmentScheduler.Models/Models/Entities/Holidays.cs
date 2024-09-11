namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class Holidays
    {
        public int HolidaysId { get; set; }
        public DateTime HolidayDate { get; set; } = DateTime.Now;
        public string Name { get; set; } = string.Empty;
    }
}
