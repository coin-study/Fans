using System.Linq;
using fans.Data;
using fans.EntityModels;
using fans.Models.Member;
using fans.Models.U;
using fans.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fans.Controllers
{
    public class UController : Controller
    {
        
        private readonly IMember _memberService;
        private readonly IClub _clubService;
        private readonly IIdol _idolService;
        private readonly IPayment _paymentService;
        private readonly ApplicationDbContext _context;
        private static UserManager<ApplicationUser> _userManager;
        public UController(
            IMember memberService, 
            IClub clubService,
            IIdol idolService,
            IPayment paymentService,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _clubService = clubService;
            _idolService = idolService;
            _paymentService = paymentService;
            _context = context;
            _memberService = memberService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var us = _userManager.Users
                .Select( u => new UViewModel 
                {
                    Id = u.Id,
                    Name = u.UserName,
                    Email = u.Email
                });

            var model = new UIndexViewModel 
            {
                Us = us
            };
            
            return View(model);
        }
    }
}