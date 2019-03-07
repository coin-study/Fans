using Microsoft.AspNetCore.Mvc;

namespace fans.Controllers
{
    public class MemberController : Controller
    {
        public MemberController(IMember memberService)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}