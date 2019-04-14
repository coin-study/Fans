using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using fans.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace fans.Controllers
{
    public class SeleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMember _memberService;

        public SeleController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IMember memberService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _memberService = memberService;
        }

        public IActionResult Index(int id)
        {
            var member = _memberService.GetById(id);

            ClubRegister.RegisterArashi(member);
            
            return View();
        }

    }

}