using System.Linq;
using fans.Models.Idol;
using fans.Service;
using Microsoft.AspNetCore.Mvc;

namespace fans.Controllers
{
    public class IdolController : Controller
    {
        private readonly IIdol _idolService;
        public IdolController(IIdol idolService)
        {
            _idolService = idolService;

        }
        public IActionResult Index()
        {
            var idols = _idolService.GetAll()
                .Select( idol => new IdolViewModel 
                {
                    Id = idol.Id,
                    Name = idol.Name,
                    EnglishName = idol.EnglishName,
                    ClubId = idol.ClubId
                });

            var model = new IdolIndexViewModel
            {
                IdolList = idols
            };

            return View(model);
        }

        public IActionResult Club(int id)
        {
            var idols = _idolService.GetAllByClubId(id)
            
                .Select( idol => new IdolViewModel 
                {
                    Id = idol.Id,
                    Name = idol.Name,
                    EnglishName = idol.EnglishName,
                    ClubId = idol.ClubId
                });

            var model = new IdolIndexViewModel
            {
                IdolList = idols
            };

            return View(model);
        }
    }
}