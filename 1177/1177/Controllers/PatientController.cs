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
            => await _1337.PatientLogin.PatientLogin.ExecutePatientLoginAsync(this, patientId, patientPW);

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
