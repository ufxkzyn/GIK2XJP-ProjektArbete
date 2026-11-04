using System.Text.Json;

namespace _1337.Models
{
    public class ScheduleService
    {
        private List<Staff> LoadStaff()
        {
            List<Staff> allStaff = new List<Staff>();

            string[] files =
            {
                "Doctors,.json",
                "AssistantNurse.json",
                "Nurse.json"
            };

            foreach (string file in files)
            {
                string path = $"Data/Hospital1/Staff/{file}";

                string json = File.ReadAllText(path);

                List<Staff> staff = JsonSerializer.Deserialize<List<Staff>>(json); // omvandlar json till en lista av staff objekt

                allStaff.AddRange(staff); // lägger till alla staff objekt till allStaff listan
            }
            return allStaff;
        }

        private List<AppointmentSlot> LoadRooms()
        {
            List<AppointmentSlot> allRooms = new List<AppointmentSlot>();

            string [] files =
            {
              "EmergencyRooms.json",
              "ExaminationRooms.json",
              "LabRooms.json"
            };

            foreach (string file in files)
            {
                string path = $"Data/Hospital1/Rooms/{file}";

                string json = File.ReadAllText(path);

                List<AppointmentSlot> rooms = JsonSerializer.Deserialize<List<AppointmentSlot>>(json); // omvandlar json till en lista av room objekt

                allRooms.AddRange(rooms); // lägger till alla staff objekt till allRooms listan
            }
            return allRooms;
        }
    }
}