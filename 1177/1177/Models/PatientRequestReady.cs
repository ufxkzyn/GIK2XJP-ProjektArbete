using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;


namespace _1177.Models
{
    public class PatientRequestReady
    {
        public void SaveAndSendPatientRequest()
        {
            var CurrentPatient = JsonNode.Parse(File.ReadAllText("Models/Patient.json"));
            var CurrentRequest = JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequest.json"));

            if (CurrentPatient == null || CurrentRequest == null)
            {
                throw new Exception("Patient or Request data is missing.");

            CurrentPatient.AsObject().Remove("Password");
            CurrentPatient.AsObject().Remove("Email");
            CurrentPatient.AsObject().Remove("PhoneNr");
            var CurrentDate = DateTime.Now;

            var RequestAndPatient = new JsonObject
            {
                ["Patient"] = CurrentPatient,
                ["Date"] = CurrentDate,
                ["Request"] = CurrentRequest
            };

            var SaveRequestAndPatient = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("Data/Patient/PatientRequestReady.json", RequestAndPatient.ToJsonString(SaveRequestAndPatient));
        }
    }
}
