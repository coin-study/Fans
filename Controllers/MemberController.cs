using System;
using System.Linq;
using System.Threading.Tasks;
using fans.EntityModels;
using fans.Models.Idol;
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
        private readonly IIdol _idolService;
        private static UserManager<ApplicationUser> _userManager;
        public MemberController(
            IMember memberService, 
            IClub clubService,
            IIdol idolService,
            UserManager<ApplicationUser> userManager)
        {
            _clubService = clubService;
            _idolService = idolService;
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
                    FavouriteId = m.Favourite.Id,
                    FavouriteName = m.Favourite.Name,
                    Phone = m.Phone,
                    Wechat = m.Wechat,
                    MailingAddress = m.MailingAddress,
                    SharedAddress = m.SharedAddress,
                    RegisterLink = m.RegisterLink
                });

            var model = new MemberIndexViewModel
            {
                Members = members
            };

            return View(model);
        }
        public IActionResult Detail(int id) // member's id
        {
            var member = _memberService.GetById(id);
            var idolList = _idolService.GetAllByClub(member.Club)
                .Select( idol => new IdolViewModel 
                {
                    Id = idol.Id,
                    Name = idol.Name,
                    EnglishName = idol.EnglishName,
                    ClubId = idol.ClubId
                });

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
                FavouriteId = member.Favourite.Id,
                Favourite = member.Favourite,
                Phone = member.Phone,
                Wechat = member.Wechat,
                MailingAddress = member.MailingAddress,
                SharedAddress = member.SharedAddress,
                IdolList = idolList
            };

            return View(model);
        }

        public IActionResult Register(int id) // club's id
        {
            var club = _clubService.GetById(id);
            var idolList = _idolService.GetAllByClub(club)
                .Select( idol => new IdolViewModel 
                {
                    Id = idol.Id,
                    Name = idol.Name,
                    EnglishName = idol.EnglishName,
                    ClubId = idol.ClubId
                });

            var model = new RegisterMemberModel
            {
                ClubId = club.Id,
                ClubName = club.Name,
                UserName = User.Identity.Name,
                IdolList = idolList
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
           // return RedirectToAction("Detail", "Member", new { id = member.Id } );
            return RedirectToAction("Index", "Member");

        }

        public IActionResult RegisterLink(int id) // member's id
        {
            var member = _memberService.GetById(id);

            var model = new RegisterLinkModel
            {
                ClubId = member.Club.Id,
                ClubName = member.Club.ChineseName,
                MemberId = member.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRegisterLink(RegisterLinkModel model)
        {
            await _memberService.UpdateRegisterLink(model.MemberId, model.RegisterLink);

            return RedirectToAction("Index", "Member");
        }
        public async Task<IActionResult> RegisterStepOne(int id)
        {
            var member = _memberService.GetById(id);

            if (member.Club.Id == 1) 
            {
                await ClubRegister.RegisterArashi_One(member);
            }
            else if (member.Club.Id == 2)
            {

            }
            else if (member.Club.Id == 3)
            {
                await ClubRegister.RegisterBTS_One(member);
            }
            

            return RedirectToAction("Index", "Member");
        }

        public async Task<IActionResult> RegisterStepTwo(int id)
        {
            var member = _memberService.GetById(id);

            await ClubRegister.RegisterArashi_Two(member);

            return RedirectToAction("Index", "Member");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember(int id, RegisterMemberModel model)
        {
            var userId = model.UserId;
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
                Favourite = _idolService.GetById(model.FavouriteId),
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