using System.Text.Json;
using _1177.Models;

namespace _1177.PatientLogin
{
    public static class PatientLogin
    {   // Async is used to free up threads, aka pure optimisation 
        public static async Task<bool> ValidateCredentialsAsync(string patientId, string patientPW)
        {
            // AppContext.BaseDirectory is thge path for the "base" folder, aka 1177/1177/here
            string patientFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Patient", "PatientData.json");

            // If the file doesn's exist or isn't in that specific place, return false
            if (!System.IO.File.Exists(patientFilePath))
            {
                return false;
            }
            // Reads the patient data file and saves it locally
            string jsonText = await System.IO.File.ReadAllTextAsync(patientFilePath);
            // Creates an option variable for the structure of the json file
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            // Creates a list of patients from the json file, using the options
            List<Patient>? patients = JsonSerializer.Deserialize<List<Patient>>(jsonText, options);

            // Returns patients and checks if any of them align with what was put into the SSN and password fields
            return patients?.Any(p => p.PersonNr == patientId && p.Password == patientPW) ?? false;
        }
    }
}