﻿namespace DoctorAppointmentScheduler.Models.Models.Entities
{
    public class TimeAvailability
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Navigation Property
        public Doctor? Doctor { get; set; }
    }
}
