using Microsoft.AspNetCore.Mvc;

namespace _1177.Controllers
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
            => await _1177.StaffLogin.StaffLogin.ExecuteStaffLoginAsync(this, staffId, staffPW);
            
        public IActionResult StaffIndex()
        {
            return View();
        }
        public IActionResult OpenStaffRequest()
        {
            return View();
        }
    }
}
