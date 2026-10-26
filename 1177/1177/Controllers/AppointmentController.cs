using Microsoft.AspNetCore.Mvc;
using _1337.Models;

namespace _1337.Controllers
{
	public class AppointmentController : Controller
	{
		private static readonly List<AppointmentSlot> AppointmentSlots = new(); // Skapar lista där doktorns tider tillfälligt sparas'

		public IActionResult Index() // Skapa en vy som visar alla tider tillgängliga för bokning
		{
			return View(AppointmentSlots);
		}

		[HttpGet]
		public IActionResult Create() // Visar formuär för att skapa en ny bokningsbar tid
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(AppointmentSlot appointmentSlot) // Tar emot formuläret och sparar den i listan, JSON?
		{
			appointmentSlot.AppointmentSlotId =
				AppointmentSlots.Count + 1;

			appointmentSlot.IsBooked = false;

			AppointmentSlots.Add(appointmentSlot);

			return RedirectToAction("Index");
		}
	}
}