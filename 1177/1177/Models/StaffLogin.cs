using Microsoft.AspNetCore.Mvc;
using _1337.Models;

namespace _1337.StaffLogin
{
    public class StaffLogin
    {
    public static async Task<IActionResult> ExecuteStaffLoginAsync(Controller controller, string staffId, string staffPW)
        {

            string[] staffFiles = new[]
            {
                Path.Combine("Data", "Hospital1", "Staff", "Doctors.json"),
                Path.Combine("Data", "Hospital1", "Staff", "Nurses.json"),
                Path.Combine("Data", "Hospital1", "Staff", "AssistantNurse.json")
            };

            foreach (var filePath in staffFiles)
            {
                if (!File.Exists(filePath))
                    continue;
            
                bool isCorrect = await AuthService.ValidateAsync<Staff>(
                    filePath,
                    staffId,                                  
                    p => p.Password == staffPW        
                    );


                if (isCorrect)
                {
                    new GetInformationFromDataToCurrentUser().GetUserInformation(staffId, filePath);
                    return controller.RedirectToAction("StaffIndex");
                }

            }

            controller.ViewBag.ErrorMessage = "Felaktigt anställnings-ID eller lösenord.";
            return controller.View();
        }
    }
}