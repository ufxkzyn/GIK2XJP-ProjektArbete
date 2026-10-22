using _1337.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1337.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult StaffLogin()
        {
            return View();
        }
        public IActionResult StaffIndex()
        {
            return View();
        }
        public IActionResult StaffRequestRead()
        {
            var RequestData = new StaffReadingPatientRequest().GetPatientRequest();
            return View("StaffRequestRead", RequestData);
        }
        public IActionResult StaffLogout()
        {
            System.IO.File.WriteAllText("Data/CurrentStaff.json", "{ }");
            return RedirectToAction("StaffLogin");
        }
        public IActionResult OpenPatientRequest(int priority, string staffComment)
        {
            new StaffReadingPatientRequest().OpenPatientRequest(priority, staffComment);
            return RedirectToAction("StaffIndex");
        }
    }
}
