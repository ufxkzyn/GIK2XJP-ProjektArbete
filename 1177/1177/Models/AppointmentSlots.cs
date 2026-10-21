namespace _1177.Models
{
    public class AppointmentSlot
    {
        public int AppointmentSlotId { get; set; } //ID för tidsluckan

        public string DoctorName { get; set; } = string.Empty;

        public DateTime StartTime { get; set; } //Starttid på bokning

        public DateTime EndTime { get; set; } //Sluttid på bokning

        public bool IsBooked { get; set; }

        public string? PatientId { get; set; }
    }
}