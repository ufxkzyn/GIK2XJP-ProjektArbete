using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace _1337.Models
{
    public class GetPatientName
    {
        public (DateTime Date, string Name) GetPatientNameMethod()
        { 
            var CurrentPatient = JsonNode.Parse(File.ReadAllText("Data/CurrentPatient.json"));
            if (CurrentPatient == null)
            {
                throw new Exception("Patient data is missing.");
            }

            DateTime CurrentDate = DateTime.Now;
            var CurrentPatientName = CurrentPatient["FirstName"].ToString() + " " + CurrentPatient["LastName"].ToString();
            return (CurrentDate, CurrentPatientName);
        }
    }
}
