using Microsoft.AspNetCore.Mvc;

namespace ClubinhoDoBebe.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
