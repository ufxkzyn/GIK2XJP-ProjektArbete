using _1337.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _1337.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(string staffType = "AssistantNurse")
        {
            var checker = new CheckAvailabilityStaff();
            var result = checker.StaffAvailability(staffType, out _);

            ViewBag.StaffType = staffType;
            return View(result);
        }
    }
}
