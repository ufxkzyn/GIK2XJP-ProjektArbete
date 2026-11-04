using Microsoft.AspNetCore.Mvc;
using _1337.Models;

namespace _1337.PatientLogin
{
    public class PatientLogin
    {
        public static async Task<IActionResult> ExecutePatientLoginAsync(Controller controller, string patientId, string patientPW)
        {
            bool isCorrect = await AuthService.ValidateAsync<Patient>(
                Path.Combine("Data", "Patient", "PatientData.json"),
                patientId,                                  
                p => p.Password == patientPW        
                );

            if (isCorrect)
            {
                new GetInformationFromDataToCurrentUser().GetUserInformation(patientId, "Data/Patient/PatientData.json");
                return controller.RedirectToAction("PatientIndex");
            }

            controller.ViewBag.ErrorMessage = "Felaktigt personnummer eller lösenord.";
            return controller.View();
        }
    }
}