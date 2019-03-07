using System.Linq;
using fans.Models.Club;
using fans.Service;
using Microsoft.AspNetCore.Mvc;

namespace fans.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClub _clubService;
        public ClubController(IClub clubService)
        {
            _clubService = clubService;
        }

        public IActionResult Index()
        {
            var clubs = _clubService.GetAll()
                            .Select( club => new ClubViewModel {
                                Id = club.Id,
                                Name = club.Name,
                                ChineseName = club.ChineseName,
                                Homepage = club.Homepage,
                                ImageUrl = club.ImageUrl
                            });
            
            var model = new ClubIndexViewModel {
                ClubList = clubs
            };

            return View(model);
        }
    }
}