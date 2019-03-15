using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace fans.Service
{
    public class ClubService : IClub
    {
        private readonly ApplicationDbContext _context;
        public ClubService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Create(Club club)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int cludId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Club> GetAll()
        {
            return _context.Clubs
                .Include(club => club.Members);
        }

        public IEnumerable<Member> GetAllMember(int clubId)
        {
            return _context.Members.Where( member => member.Club.Id == clubId);
        }

        public Club GetById(int clubId)
        {
            return _context.Clubs.Where( club => club.Id == clubId)
                .Include(club => club.Members)
                .First();
        }
    }
}