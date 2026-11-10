using _1337.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _1337.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(string? StaffType, string? roomPicked) 
        {
            ViewBag.StaffType = StaffType;
            ViewBag.RoomPicked = roomPicked;
            if (StaffType != null)
                ViewBag.Staffbooking = new CheckAvailabilityStaff().StaffAvailability(StaffType);
            if (roomPicked != null)
                ViewBag.Bookings = new RoomBook().GetRoomBookings(roomPicked);

            if (roomPicked != null && StaffType != null)
                ViewBag.Matches = new MatchRoomAndStaff().MatchRoomAndStaffMethod();
            return View();
        }
    }
}