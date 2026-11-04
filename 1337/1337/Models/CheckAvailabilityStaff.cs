using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1337.Models
{
    public class CheckAvailabilityStaff
    {
        public List<JsonObject> StaffAvailability(string StaffType, out string StaffTimesOut)
        {
            StaffTimesOut = string.Empty;

            var StaffTimes = new List<JsonObject>();

            switch (StaffType)
            {
                case "AssistantNurse":
                    {
                        var CurrentStaffTimes = JsonNode.Parse(File.ReadAllText("Data/Hospital1/Staff/AssistantNurse.json"));

                        foreach (var persnr in CurrentStaffTimes!.AsObject())
                        {
                            var TimeBookedFin = new JsonObject
                            {
                                ["personnummer"] = persnr.Key,
                                ["Måndag"] = persnr.Value!["Måndag"]?.DeepClone(),
                                ["Tisdag"] = persnr.Value!["Tisdag"]?.DeepClone(),
                                ["Onsdag"] = persnr.Value!["Onsdag"]?.DeepClone(),
                                ["Torsdag"] = persnr.Value!["Torsdag"]?.DeepClone(),
                                ["Fredag"] = persnr.Value!["Fredag"]?.DeepClone(),
                                ["Lördag"] = persnr.Value!["Lördag"]?.DeepClone(),
                                ["Söndag"] = persnr.Value!["Söndag"]?.DeepClone()
                            };
                            StaffTimes.Add(TimeBookedFin);
                        }
                        break;
                    }
                case "Doctors":
                    {
                        var CurrentStaffTimes = JsonNode.Parse(File.ReadAllText("Data/Hospital1/Staff/Doctors.json"));
                        foreach (var persnr in CurrentStaffTimes!.AsObject())
                        {
                            var TimeBookedFin = new JsonObject
                            {
                                ["personnummer"] = persnr.Key,
                                ["Måndag"] = persnr.Value!["Måndag"]?.DeepClone(),
                                ["Tisdag"] = persnr.Value!["Tisdag"]?.DeepClone(),
                                ["Onsdag"] = persnr.Value!["Onsdag"]?.DeepClone(),
                                ["Torsdag"] = persnr.Value!["Torsdag"]?.DeepClone(),
                                ["Fredag"] = persnr.Value!["Fredag"]?.DeepClone(),
                                ["Lördag"] = persnr.Value!["Lördag"]?.DeepClone(),
                                ["Söndag"] = persnr.Value!["Söndag"]?.DeepClone()
                            };
                            StaffTimes.Add(TimeBookedFin);
                        }
                        break;
                    }
                case "Nurses":
                    {
                        var CurrentStaffTimes = JsonNode.Parse(File.ReadAllText("Data/Hospital1/Staff/Nurses.json"));
                        foreach (var persnr in CurrentStaffTimes!.AsObject())
                        {
                            var TimeBookedFin = new JsonObject
                            {
                                ["personnummer"] = persnr.Key,
                                ["Måndag"] = persnr.Value!["Måndag"]?.DeepClone(),
                                ["Tisdag"] = persnr.Value!["Tisdag"]?.DeepClone(),
                                ["Onsdag"] = persnr.Value!["Onsdag"]?.DeepClone(),
                                ["Torsdag"] = persnr.Value!["Torsdag"]?.DeepClone(),
                                ["Fredag"] = persnr.Value!["Fredag"]?.DeepClone(),
                                ["Lördag"] = persnr.Value!["Lördag"]?.DeepClone(),
                                ["Söndag"] = persnr.Value!["Söndag"]?.DeepClone()
                            };
                            StaffTimes.Add(TimeBookedFin);
                        }
                        break;
                    }
            }
            return StaffTimes;
        }
    }
}
