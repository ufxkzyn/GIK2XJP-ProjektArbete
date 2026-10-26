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
            => await _1177.PatientLogin.PatientLogin.ExecutePatientLoginAsync(this, patientId, patientPW);

        public IActionResult PatientIndex()
        {
            return View();
        }
        public IActionResult SaveAndSendPatientRequest()
        {
            return View();
        }
    }
}
