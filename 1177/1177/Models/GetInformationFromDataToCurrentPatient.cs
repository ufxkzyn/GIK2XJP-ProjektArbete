using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;


namespace _1337.Models
{
    public class GetInformationFromDataToCurrentPatient
    {
        public void GetPatientInformation(string patientId)
        {
            var patientsData = JsonNode.Parse(File.ReadAllText("Data/Patient/PatientData.json"));


            JsonNode? CurrentPatient = null;
            foreach (var person in patientsData.AsArray())
            {
                if (person["PersonNr"].ToString() == patientId)
                {
                    CurrentPatient = person;
                }
            }

            string Tojson = JsonSerializer.Serialize(CurrentPatient, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText("Data/CurrentPatient.json", Tojson);
        }
    }
}
