using Microsoft.AspNetCore.Mvc;

namespace _1177.Controllers
{
    public class StaffController : Controller
    {
        [HttpGet]
        public IActionResult StaffLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StaffLogin(string StaffId, string StaffPW)
        {
            // Calls the function to check whether the login information was correct or incorrect
            bool isValid = await _1177.StaffLogin.StaffLogin.ValidateCredentialsAsync(StaffId, StaffPW);

            // If it is correct, proceed
            if (isValid)
            {
                return RedirectToAction("StaffIndex");
            }

            // If it is incorrect, show a message
            ViewBag.ErrorMessage = "Felaktigt personnummer eller lösenord.";
            return View();
        }
        public IActionResult StaffIndex()
        {
            return View();
        }
        public IActionResult OpenStaffRequest()
        {
            return View();
        }
    }
}
