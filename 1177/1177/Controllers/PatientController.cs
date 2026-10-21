using Microsoft.AspNetCore.Mvc;
namespace _1177.Controllers
{
    public class PatientController : Controller
    {
        [HttpGet]
        public IActionResult PatientLogin()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> PatientLogin(string patientId, string patientPW)
        {
            // Calls the function to check whether the login information was correct or incorrect
            bool isValid = await _1177.PatientLogin.PatientLogin.ValidateCredentialsAsync(patientId, patientPW);
            // If it is correct, proceed
            if (isValid)
            {
                return RedirectToAction("PatientIndex");
            }
            // If it is incorrect, show a message
            ViewBag.ErrorMessage = "Felaktigt personnummer eller lösenord.";
            return View();
        }

        public IActionResult PatientIndex()
        {
            return View();
        }
        }

    }

