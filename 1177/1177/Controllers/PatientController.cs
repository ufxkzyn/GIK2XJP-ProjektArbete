using _1337.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace _1337.Controllers
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
            bool isValid = await _1337.PatientLogin.PatientLogin.ValidateCredentialsAsync(patientId, patientPW);

            // If it is correct, proceed
            if (isValid)
            {
                // tror det ska ligga här, det sprarar den nuvarande inloggade patienten i currentpatient
                new GetInformationFromDataToCurrentPatient().GetPatientInformation(patientId);
                return RedirectToAction("PatientIndex");
            }

            // If it is incorrect, show a message
            ViewBag.ErrorMessage = "Felaktigt personnummer eller lösenord.";
            return View();
        }

        public IActionResult PatientIndex()
        {
            return View(new GetPatientName().GetPatientNameMethod());
        }

        public IActionResult PatientLogout()
        {
            System.IO.File.WriteAllText("Data/CurrentPatient.json", "{ }");
            return RedirectToAction("PatientLogin");
        }

        public IActionResult PatientRequest()
        {
            return View();
        }

        public IActionResult PatientRequestSend(string PatientRequest)
        {
            new PatientRequestReady().SaveAndSendPatientRequest(PatientRequest);
            return RedirectToAction("PatientIndex");
        }
    }
}
