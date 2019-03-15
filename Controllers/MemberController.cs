using System;
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

        public IActionResult Index(int id)
        {
            var member = _memberService.GetById(id);

            var model = new MemberViewModel
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
            return RedirectToAction("Index", "Member", member.Id);
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