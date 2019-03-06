using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public Club GetById(int clubId)
        {
            throw new System.NotImplementedException();
        }
    }
}