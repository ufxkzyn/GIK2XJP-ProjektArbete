using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace _1177.Models
{
    public class StaffReadingPatientRequest
    {
        public void OpenPatientRequest()
        {
            var CurrentPatientRequest = JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequestReady.json"));

            if (CurrentPatientRequest == null)
            {
                throw new Exception("Patient request data is missing.");
            }

            var Patient = CurrentPatientRequest["Patient"];
            var Request = CurrentPatientRequest["Request"];
            var Date = CurrentPatientRequest["Date"];

            var Priority = Request?["Priority"]?.GetValue<string>();
            var AddiontalComment = Request?["AdditionalComment"]?.GetValue<string>();


        }
    }
}