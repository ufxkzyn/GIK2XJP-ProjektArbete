using System.Text.Json;
using System.Text.Json.Nodes;

namespace _1337.Models
{
    public class StaffBooking
    {
        public List<JsonObject> ConfirmBooking(string patient, string rum, string dag, string tid, string FirstName, string LastName, string Roll)
        {
            var CurrentChoices = JsonNode.Parse(File.ReadAllText("Data/temp/WhichStaffIsFree.json"));
            var WhichPatient = JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequestAnswered.json"));

            var ConfirmedBooking = JsonNode.Parse(File.ReadAllText("Data/Hospital1/ConfirmedBookings.json"));




            var StaffBookingEntry = new JsonObject
                {
                    ["rum"] = rum,
                    ["dag"] = dag,
                    ["tid"] = tid,
                    ["FirstName"] = FirstName,
                    ["LastName"] = LastName,
                    ["Roll"] = Roll
            };

            var PatientBookingEntry = new JsonObject
                {
                    ["patient"] = patient,
                    ["personnummer"] = WhichPatient["personnummer"]?.ToString(),
                    ["bookedAt"] = DateTime.Now.ToString("s"),
                    ["Request"] = WhichPatient["Request"]?.ToString(),
                    ["Priority"] = WhichPatient["Priority"]?.ToString(),
                    ["AdditionalComment"] = WhichPatient["AdditionalComment"]?.ToString()
                };

            var IntoTheJsonYouGo = ConfirmedBooking as JsonArray ?? new JsonArray();

            var StaffAndPatientbooking = new JsonObject
            {
                ["BokningsNr"] = IntoTheJsonYouGo.Count + 1,
                ["StaffBooking"] = StaffBookingEntry,
                ["PatientBooking"] = PatientBookingEntry
            };

            var SaveBookingOptions = new JsonSerializerOptions{WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping};

            IntoTheJsonYouGo.Add(StaffAndPatientbooking);
            File.WriteAllText("Data/Hospital1/ConfirmedBookings.json", JsonSerializer.Serialize(IntoTheJsonYouGo, SaveBookingOptions));
            return new List<JsonObject> { StaffAndPatientbooking };
        }
    }
}