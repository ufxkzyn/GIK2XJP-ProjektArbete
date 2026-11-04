using System.Text.Json;
using _1337.Models;

namespace _1337.Services
{
    public class ScheduleService
    {
        private List<Staff> LoadStaff()
        {
            List<LoadStaff> allStaff = new List<Staff>();

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

                List<Staff> staff =
                    JsonSerializer.Deserialize<List<Staff>>(json); // omvandlar json till en lista av staff objekt

                allStaff.AddRange(staff); // lägger till alla staff objekt till allStaff listan
            }
            return allStaff;
        }

        private List<Room> LoadRooms()
        {
            List<Room> allRooms = new List<Room>();

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

                List<Room> rooms =
                   JsonSerializer.Deserialize<List<Room>>(json); // omvandlar json till en lista av room objekt

                allRoom.AddRange(rooms); // lägger till alla staff objekt till allRooms listan
            }
            return allRooms;
        }
    }
}