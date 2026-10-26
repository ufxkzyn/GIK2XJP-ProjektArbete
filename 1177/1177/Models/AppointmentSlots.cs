namespace _1177.Models
{
    public class AppointmentSlot
    {
        public int AppointmentSlotId { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        public DateTime StartTime { get; set; } 

        public DateTime EndTime { get; set; } 

        public bool IsBooked { get; set; }

        public string? PatientId { get; set; }
    }
}