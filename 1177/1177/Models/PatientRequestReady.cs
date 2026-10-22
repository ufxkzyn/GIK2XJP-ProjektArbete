using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;


namespace _1337.Models
{
    public class PatientRequestReady
    {
        public void SaveAndSendPatientRequest()
        {
            var CurrentPatient = JsonNode.Parse(File.ReadAllText("Data/CurrentPatient.json"));
            var CurrentRequest = JsonNode.Parse(File.ReadAllText("Data/Patient/PatientRequest.json"));

            if (CurrentPatient == null || CurrentRequest == null)
            {
                throw new Exception("Patient or Request data is missing.");
            }

            var RequestAndPatient = CurrentPatient["FirstName"].ToString() + " " + CurrentPatient["LastName"].ToString() + " " + CurrentPatient["PersonNr"].ToString() + " " + CurrentRequest["Request"].ToString();
            


            var SaveRequestAndPatient = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("Data/Patient/PatientRequestReady.json", JsonSerializer.Serialize(RequestAndPatient, SaveRequestAndPatient));
        }
    }
}
