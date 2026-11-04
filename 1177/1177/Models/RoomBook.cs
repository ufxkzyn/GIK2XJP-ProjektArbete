using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace _1337.Models
{
    public class RoomBook
    {
        public List<JsonObject> GetRoomBookings(string RoomPicked)
        {
            var bookingEntries = new List<JsonObject>();

            switch (RoomPicked)
            {
                case "Akutrum":
                {
                    var CurrentRoomType = JsonNode.Parse(File.ReadAllText("Data/Hospital1/Rooms/EmergencyRooms.json"));

                    foreach (var room in CurrentRoomType!.AsObject())
                    {
                        foreach (var day in room.Value!.AsObject())
                        {
                            if (day.Key == "RumNr") continue;
                            foreach (var time in day.Value!.AsObject())
                            {
                                var TimeBookedFin = new JsonObject
                                {
                                    ["rum"] = room.Key,
                                    ["dag"] = day.Key,
                                    ["tid"] = time.Key,
                                    ["personnummer"] = time.Value?.ToString()
                                };
                                bookingEntries.Add(TimeBookedFin);
                            }
                        }
                    }

                    break;
                }

                case "TreatmentRoom":
                    {
                        var CurrentRoomType = JsonNode.Parse(File.ReadAllText("Data/Hospital1/Rooms/TreatmentRoom.json"));

                        foreach (var room in CurrentRoomType!.AsObject())
                        {
                            foreach (var day in room.Value!.AsObject())
                            {
                                if (day.Key == "RumNr") continue;
                                foreach (var time in day.Value!.AsObject())
                                {
                                    var TimeBookedFin = new JsonObject
                                    {
                                        ["rum"] = room.Key,
                                        ["dag"] = day.Key,
                                        ["tid"] = time.Key,
                                        ["personnummer"] = time.Value?.ToString()
                                    };

                                    bookingEntries.Add(TimeBookedFin);
                                }
                            }
                        }

                        break;
                    }

                case "Behandlingsrum":
                    {
                        var CurrentRoomType = JsonNode.Parse(File.ReadAllText("Data/Hospital1/Rooms/ExaminationRooms.json"));

                        foreach (var room in CurrentRoomType!.AsObject())
                        {
                            foreach (var day in room.Value!.AsObject())
                            {
                                if (day.Key == "RumNr") continue;
                                foreach (var time in day.Value!.AsObject())
                                {
                                    var TimeBookedFin = new JsonObject
                                    {
                                        ["rum"] = room.Key,
                                        ["dag"] = day.Key,
                                        ["tid"] = time.Key,
                                        ["personnummer"] = time.Value?.ToString()
                                    };

                                    bookingEntries.Add(TimeBookedFin);
                                }
                            }
                        }

                        break;
                    }
            }
            return bookingEntries;
        }
    }
}
