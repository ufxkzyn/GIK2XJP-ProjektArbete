using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace _1337.Models
{
    public class StaffReadingPatientRequest
    {
        public JsonNode GetPatientRequest()
        {
            return JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequestReady.json"));
        }

        public void OpenPatientRequest(int priority, string staffComment)
        {
            var CurrentPatientRequest = JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequestReady.json"));

            if (CurrentPatientRequest == null)
            {
                throw new Exception("Patient request data is missing.");
            }

            var Patient = CurrentPatientRequest["Patient"];
            var Request = CurrentPatientRequest["Request"];
            var Date = CurrentPatientRequest["Date"];

            var Priority = priority;
            var AddiontalComment = staffComment;


            var RequestAndfinish = new JsonObject
            {
                ["Patient"] = Patient,
                ["Date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ["Priority"] = Priority,
                ["AdditionalComment"] = AddiontalComment
            };

            var RequestDone = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("Data/Patient/PatientRequestAnswered.json", JsonSerializer.Serialize(RequestAndfinish, RequestDone));
        }
    }
}