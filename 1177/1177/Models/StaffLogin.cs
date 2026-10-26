using System.Text.Json;
using _1177.Models;

namespace _1177.StaffLogin
{
    public static class StaffLogin
    {   // Async is used to free up threads, aka pure optimisation 
        public static async Task<bool> ValidateCredentialsAsync(string StaffId, string StaffPW)
        {
            // AppContext.BaseDirectory is thee path for the "base" folder, aka 1177/1177/here
            string staffFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "Staff", "AllStaff.json");

            // If the file doesn's exist or isn't in that specific place, return false
            if (!System.IO.File.Exists(staffFilePath))
            {
                return false;
            }
            // Reads the staff data file and saves it locally
            string jsonText = await System.IO.File.ReadAllTextAsync(staffFilePath);
            // Creates an option variable for the structure of the json file
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            // Creates a list of staff from the json file, using the options
            List<Staff>? staff = JsonSerializer.Deserialize<List<Staff>>(jsonText, options);

            // Returns patients and checks if any of them align with what was put into the SSN and password fields
            return staff?.Any(p => p.PersonNr == StaffId && p.Password == StaffPW) ?? false;
        }
    }
}