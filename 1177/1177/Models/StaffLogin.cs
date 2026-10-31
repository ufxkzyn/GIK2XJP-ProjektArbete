using Microsoft.AspNetCore.Mvc;
using _1337.Models;

namespace _1337.StaffLogin
{
    public class StaffLogin
    {
    public static async Task<IActionResult> ExecuteStaffLoginAsync(Controller controller, string staffId, string staffPW)
        {
            bool isCorrect = await AuthService.ValidateAsync<Staff>(
                Path.Combine("Data", "Staaff", "AllStaff.json"),
                staffId,                                  
                p => p.Password == staffPW        
                );


            if (isCorrect)
            {
                new GetInformationFromDataToCurrentUser().GetUserInformation(staffId, "Data/Staff/AllStaff.json");
                return controller.RedirectToAction("StaffIndex");
            }

            controller.ViewBag.ErrorMessage = "Felaktigt anställnings-ID eller lösenord.";
            return controller.View();
        }
    }
}