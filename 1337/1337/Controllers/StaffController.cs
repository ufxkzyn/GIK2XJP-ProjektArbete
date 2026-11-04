using _1337.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1337.Controllers
{
    public class StaffController : Controller
    {
        [HttpGet]
        public IActionResult StaffLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StaffLogin(string staffId, string staffPW)
            => await _1337.StaffLogin.StaffLogin.ExecuteStaffLoginAsync(this, staffId, staffPW);
            
        public IActionResult StaffIndex()
        {
            return View(new GetUserName().GetUserNameMethod());
        }
        public IActionResult StaffRequestRead()
        {
            var RequestData = new StaffReadingPatientRequest().GetPatientRequest();
            return View("StaffRequestRead", RequestData);
        }
        public IActionResult StaffLogout()
        {
            System.IO.File.WriteAllText("Data/CurrentUser.json", "{ }");
            return RedirectToAction("StaffLogin");
        }
        public IActionResult OpenPatientRequest(int priority, string staffComment)
        {
            new StaffReadingPatientRequest().OpenPatientRequest(priority, staffComment);
            return RedirectToAction("StaffIndex");
        }
    }
}
