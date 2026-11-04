using _1337.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _1337.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(string? roomPicked, string? StaffType)
        {

            ViewBag.Bookings = new RoomBook().GetRoomBookings(roomPicked);
            ViewBag.Staffbooking = new CheckAvailabilityStaff().StaffAvailability(StaffType);
            ViewBag.StaffType = StaffType;
            ViewBag.RoomPicked = roomPicked;

            return View();
        }
    }
}
