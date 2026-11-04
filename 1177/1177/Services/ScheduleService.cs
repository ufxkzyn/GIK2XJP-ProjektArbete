using System.Text.Json;
using _1337.Models;


namespace _1337.Services
{
    public class ScheduleService
    {
        // rumnr, dag, tid, personnummer
        private Dictionary<string, Dictionary<string, Dictionary<string, string?>>> rooms = new();

        private string[] filePaths =
            {
                "Data/EmergencyRooms.json",
                "Data/ExaminationRooms.json",
                "Data/OperationRooms.json"
            };

        // håller koll på vilken fil varje rum tillbehör 
        private Dictionary<string, string> roomFiles = new();

        // läser in alla rum från rum json filerna
        public void LoadSchedule()
        {
            rooms.Clear();
            roomFiles.Clear();

            foreach (string filePath in filePaths)
            {
                string json = File.ReadAllText(filePath);

                var data = JsonSerializer.Deserialize<List<JsonElement>>(json);

                foreach (var room in data!)
                {
                    string roomNr = room.GetProperty("RumNr").GetString()!;
                    rooms[roomNr] = new();

                    roomFiles[roomNr] = filePath;

                    string[] days =
                    {
                "Måndag", "Tisdag", "Onsdag",
                "Torsdag", "Fredag", "Lördag", "Söndag"
            };

                    foreach (string day in days)
                    {
                        rooms[roomNr][day] =
                            JsonSerializer.Deserialize<Dictionary<string, string?>>(
                                room.GetProperty(day).GetRawText())!;
                    }
                }
            }
        }

        //boka läkare
        public bool BookDoctor(string room, string day, string time, string personNr)
        {
            //kontrollera att rummet finns
            if (!rooms.ContainsKey(room))
                return false;

            //kontrollera att dagen finns
            if (!rooms[room].ContainsKey(day))
                return false;

            //kontrollera att tiden finns
            if (!rooms[room][day].ContainsKey(time))
                return false;

            //kontrollera att tiden inte är bokad
            if (rooms[room][day][time] != null)
                return false;

            // boka läkaren genom att spara personnumret
            rooms[room][day][time] = personNr;

            SaveSchedule(roomFiles[room]);

            return true;
        }

        // spara json-filen
        public void SaveSchedule(string filePath)
        {
            var json = new List<Dictionary<string, object>>();

            foreach (var room in rooms)
            {
                if (roomFiles[room.Key] != filePath)
                    continue;

                var roomData = new Dictionary<string, object>();

                roomData["RumNr"] = room.Key;

                foreach (var day in room.Value)
                {
                    roomData[day.Key] = day.Value;
                }

                json.Add(roomData);
            }

            File.WriteAllText(filePath,
                JsonSerializer.Serialize(json, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
        }

        //skriver ut schemat
        public void PrintSchedule()
        {
            foreach (var room in rooms) // 
            {
                Console.WriteLine($"Rum: {room.Key}"); // hämtar rummets namn
                Console.WriteLine($"Fil: {roomFiles[room.Key]}");

              foreach (var day in room.Value) //går igenom varje dag i rummet 
                {
                    Console.WriteLine($"Dag: {day.Key}"); // hämtar dagens namn

                    foreach (var time in day.Value)
                    {
                        Console.WriteLine($"Tid: {time.Key} | Läkare: {time.Value ?? "Ledig"}"); // 
                    }
                }
            }
        }
    }
}