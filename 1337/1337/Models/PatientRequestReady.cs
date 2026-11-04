using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;



namespace _1337.Models
{
    public class PatientRequestReady
    {
        public void SaveAndSendPatientRequest(string requestText)
        {
            var CurrentPatient = JsonNode.Parse(File.ReadAllText("Data/CurrentPatient.json"));


            var RequestAndPatient = new JsonObject
            {
                ["Patient"] = CurrentPatient["FirstName"]?.ToString() + " " + CurrentPatient["LastName"]?.ToString(),
                ["Födelsedatum"] = CurrentPatient["PersonNr"]?.ToString(),
                ["Request"] = requestText,
                ["Date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            var SaveRequestAndPatient = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("Data/Patient/PatientRequestReady.json",JsonSerializer.Serialize(RequestAndPatient, SaveRequestAndPatient));
        }
    }
}
