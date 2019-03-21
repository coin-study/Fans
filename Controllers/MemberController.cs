using System;
using System.Linq;
using System.Threading.Tasks;
using fans.EntityModels;
using fans.Models.Member;
using fans.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace fans.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMember _memberService;
        private readonly IClub _clubService;
        private static UserManager<ApplicationUser> _userManager;
        public MemberController(
            IMember memberService, 
            IClub clubService,
            UserManager<ApplicationUser> userManager)
        {
            _clubService = clubService;
            _memberService = memberService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var members = _memberService.GetAll()
                .Select(m => new MemberViewModel
                {
                    Id = m.Id,
                    ClubId = m.Club.Id,
                    ClubName = m.Club.Name,
                    UserName = m.User.UserName,
                    UserId = m.User.Id,
                    ChineseLastName = m.ChineseLastName,
                    ChineseFirstName = m.ChineseFirstName,
                    EnglishLastName = m.EnglishLastName,
                    EnglishFirstName = m.EnglishFirstName,
                    Gender = m.Gender,
                    BirthDate = m.BirthDate,
                    Favourite = m.Favourite,
                    Phone = m.Phone,
                    Wechat = m.Wechat,
                    MailingAddress = m.MailingAddress,
                    SharedAddress = m.SharedAddress
                });

            var model = new MemberIndexViewModel
            {
                Members = members
            };

            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var member = _memberService.GetById(id);

            var model = new RegisterMemberModel
            {
                Id = member.Id,
                ClubId = member.Club.Id,
                UserId = member.User.Id,
                ChineseLastName = member.ChineseLastName,
                ChineseFirstName = member.ChineseFirstName,
                EnglishLastName = member.EnglishLastName,
                EnglishFirstName = member.EnglishFirstName,
                Gender = member.Gender,
                BirthDate = member.BirthDate,
                Favourite = member.Favourite,
                Phone = member.Phone,
                Wechat = member.Wechat,
                MailingAddress = member.MailingAddress,
                SharedAddress = member.SharedAddress
            };

            return View(model);
        }

        public IActionResult Register(int id)
        {
            var club = _clubService.GetById(id);

            var model = new RegisterMemberModel
            {
                ClubId = club.Id,
                ClubName = club.Name,
                UserName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMember(RegisterMemberModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var member = BuildMember(model, user);

            await _memberService.Create(member);
            return RedirectToAction("Detail", "Member", new { id = member.Id } );
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember(int id, RegisterMemberModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var member = BuildMember(model, user);

            await _memberService.Update(id, member);
            return RedirectToAction("Index", "Member");
        }
        private Member BuildMember(RegisterMemberModel model, ApplicationUser user)
        {
            return new Member
            {
                ChineseLastName = model.ChineseLastName,
                ChineseFirstName = model.ChineseFirstName,
                EnglishLastName = model.EnglishLastName,
                EnglishFirstName = model.EnglishFirstName,
                Gender = model.Gender,
                BirthDate = model.BirthDate,
                Favourite = model.Favourite,
                Phone = model.Phone,
                Wechat = model.Wechat,
                MailingAddress = model.MailingAddress,
                SharedAddress = model.SharedAddress,
                User = user,
                Club = _clubService.GetById(model.ClubId)
            };
        }
    }
}