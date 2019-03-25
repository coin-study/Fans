using Microsoft.AspNetCore.Mvc;

namespace fans.Controllers
{
    public class IdolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}