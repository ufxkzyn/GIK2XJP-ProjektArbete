using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

namespace _1337.Models
{
    public class MatchRoomAndStaff
    {
        public List<JsonObject> MatchRoomAndStaffMethod()
        {
            var rooms = JsonSerializer.Deserialize<List<JsonObject>>(File.ReadAllText("Data/temp/RoomTimes.json")) ?? new();
            var staffList = JsonSerializer.Deserialize<List<JsonObject>>(File.ReadAllText("Data/temp/StaffTimes.json")) ?? new();
            var matches = new List<JsonObject>();

            foreach (var room in rooms)
            {
                string dag = room["dag"]!.ToString();
                string tid = room.Last().Key; 

                foreach (var staff in staffList)
                {
                    if (staff[dag]?[tid]?.ToString() != "Ledig")

                    matches.Add(new JsonObject
                    {
                        ["FirstName"] = staff["FirstName"]?.DeepClone(),
                        ["LastName"] = staff["LastName"]?.DeepClone(),
                        ["personnummer"] = staff["personnummer"]?.DeepClone(),
                        ["rum"] = room["rum"]?.DeepClone(),
                        ["dag"] = dag,
                        ["tid"] = tid
                    });
                }
            }

            File.WriteAllText("Data/temp/WhichStaffIsFree.json", JsonSerializer.Serialize(matches, new JsonSerializerOptions { WriteIndented = true }));
            return matches;
        }
    }
}