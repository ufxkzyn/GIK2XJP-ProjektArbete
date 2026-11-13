using System.Text.Json;
using System.Text.Json.Nodes;

namespace _1337.Models
{
    public class StaffBooking
    {
        private const string FreePath = "Data/temp/WhichStaffIsFree.json";
        private const string BookingsPath = "Data/ConfirmedBookings.json";

        // WhichStaffIsFree.json minus anything already booked (JSON text for the view)
        public string GetFreeJson()
        {
            var bookings = ReadArray(BookingsPath).Select(b => b!.AsObject()).ToList();
            var result = new JsonArray();

            foreach (var f in ReadArray(FreePath))
            {
                var o = f!.AsObject();
                bool taken = bookings.Any(b =>
                    Same(b, o, "dag") && Same(b, o, "tid") &&
                    (Same(b, o, "rum") || Same(b, o, "personnummer")));

                if (!taken) result.Add(o.DeepClone());
            }
            return result.ToJsonString();
        }

        // Returns a message for the user and whether it worked
        public (bool ok, string message) Confirm(string patient, string rum, string dag, string tid, string personnummer)
        {
            var match = JsonNode.Parse(GetFreeJson())!.AsArray()
                .Select(f => f!.AsObject())
                .FirstOrDefault(f => f["rum"]?.ToString() == rum && f["dag"]?.ToString() == dag
                                  && f["tid"]?.ToString() == tid && f["personnummer"]?.ToString() == personnummer);

            if (match == null)
                return (false, "Tiden eller personalen är inte längre ledig.");

            var list = ReadArray(BookingsPath);
            list.Add(new JsonObject
            {
                ["id"] = Guid.NewGuid().ToString(),
                ["patient"] = patient,
                ["rum"] = rum,
                ["dag"] = dag,
                ["tid"] = tid,
                ["personnummer"] = personnummer,
                ["FirstName"] = match["FirstName"]?.ToString(),
                ["LastName"] = match["LastName"]?.ToString(),
                ["bookedAt"] = DateTime.Now.ToString("s")
            });

            File.WriteAllText(BookingsPath, list.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
            return (true, $"Bokat: rum {rum}, {dag} {tid}, {match["FirstName"]} {match["LastName"]}.");
        }

        private static bool Same(JsonObject a, JsonObject b, string key)
            => a[key]?.ToString() == b[key]?.ToString();

        private static JsonArray ReadArray(string path)
        {
            if (!File.Exists(path)) return new JsonArray();
            try { return JsonNode.Parse(File.ReadAllText(path))?.AsArray() ?? new JsonArray(); }
            catch { return new JsonArray(); }
        }
    }
}