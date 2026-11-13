using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;

namespace _1337.Models
{
    public class MatchRoomAndStaff
    {
        public void MatchRoomAndStaffMethod()
        {
            var rooms = JsonSerializer.Deserialize<List<JsonObject>>(File.ReadAllText("Data/temp/RoomTimes.json")) ?? new();
            var staffList = JsonSerializer.Deserialize<List<JsonObject>>(File.ReadAllText("Data/temp/StaffTimes.json")) ?? new();
            var matches = new Dictionary<string, Dictionary<string, Dictionary<string, List<object>>>>();

            foreach (var room in rooms)
            {
                string dag = room["dag"]!.ToString();
                string tid = room.Last().Key; 
                string rum = room["rum"]!.ToString();

                matches.TryAdd(rum, new());
                matches[rum].TryAdd(dag, new());
                matches[rum][dag].TryAdd(tid, new ());

                foreach (var staff in staffList)
                {

                    if (staff[dag]?[tid]?.ToString() != "Ledig")
                    {
                        matches[rum][dag][tid].Add(new JsonObject
                        {
                            ["FirstName"] = staff["FirstName"]?.DeepClone(),
                            ["LastName"] = staff["LastName"]?.DeepClone(),
                            ["personnummer"] = staff["personnummer"]?.DeepClone(),
                            ["Roll"] = staff["Roll"]?.DeepClone()
                        });
                    }

                }
            }

            File.WriteAllText("Data/temp/WhichStaffIsFree.json", JsonSerializer.Serialize(matches, new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));
        }
    }
}