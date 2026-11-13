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
            var CurrentPatientRequest =
                JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequestReady.json"))?.AsObject();

            if (CurrentPatientRequest == null)
            {
                throw new Exception("Patient request data is missing.");
            }

            var Patient = CurrentPatientRequest["Patient"];
            var Request = CurrentPatientRequest["Request"];
            var Priority = priority;
            var AddiontalComment = staffComment;

            var RequestAndfinish = new JsonObject
            {
                ["Patient"] = Patient?.DeepClone(),
                ["personnummer"] = CurrentPatientRequest["Födelsedatum"]?.DeepClone(),
                ["Date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ["Priority"] = Priority,
                ["AdditionalComment"] = AddiontalComment,
                ["Request"] = Request?.DeepClone()
            };

            var RequestDone = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            File.WriteAllText("Data/Patient/PatientRequestAnswered.json",JsonSerializer.Serialize(RequestAndfinish, RequestDone));
        }
    }
}