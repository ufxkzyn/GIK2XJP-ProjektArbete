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

        public IActionResult StaffRequestRead(string? roomPicked, string? StaffType)
        {
            var RequestData = new StaffReadingPatientRequest().GetPatientRequest();
            ViewBag.Bookings = new RoomBook().GetRoomBookings(roomPicked);
            ViewBag.StaffPicked = StaffType;
            new CheckAvailabilityStaff().StaffAvailability(StaffType);
            ViewBag.RoomPicked = roomPicked;

            if (roomPicked != null && StaffType != null)
                new MatchRoomAndStaff().MatchRoomAndStaffMethod();

            ViewBag.FreeStaff = new StaffBooking().GetFreeJson();
            return View("StaffRequestRead", RequestData);
        }

        [HttpPost]
        public IActionResult ConfirmBooking(string patient, string rum, string dag, string tid,
                                            string personnummer, string? roomPicked, string? StaffType)
        {
            var (ok, message) = new StaffBooking().Confirm(patient, rum, dag, tid, personnummer);
            TempData[ok ? "Success" : "Error"] = message;
            return RedirectToAction("StaffRequestRead", new { roomPicked, StaffType });
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
    
    public IActionResult BookRoom(string roomPicked, string rum, string dag, string tid)
        {
            return RedirectToAction("StaffRequestRead", new { roomPicked });
        }

        public IActionResult MatchRoomAndStaff(string StaffType, string RoomPicked)
        {
            //new MatchRoomAndStaff().MatchRoomAndStaffMethod(StaffType, RoomPicked);
            return RedirectToAction("StaffIndex");
        }
    }
}