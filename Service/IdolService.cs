using System.Collections.Generic;
using System.Linq;
using fans.Data;
using fans.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace fans.Service
{
    public class IdolService : IIdol
    {
        private readonly ApplicationDbContext _context;
        public IdolService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Idol> GetAll()
        {
            return _context.Idols
                .Include( i => i.Club);
        }

        public IEnumerable<Idol> GetAllByClub(Club club)
        {
            return GetAll()
                .Where( i => i.Club == club);
        }

        public IEnumerable<Idol> GetAllByClubId(int id)
        {
            return GetAll()
                .Where( i => i.ClubId == id);
        }

        public Idol GetById(int id)
        {
            return _context.Idols
                .Where( i => i.Id == id)
                .Include( i => i.Club)
                .FirstOrDefault();
        }
    }
}