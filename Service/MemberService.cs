using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fans.Data;
using fans.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace fans.Service
{
    public class MemberService : IMember
    {
        private readonly ApplicationDbContext _context;
        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Member member)
        {
            _context.Add(member);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int memberId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members
                .Include( member => member.Club)
                .Include( member => member.User);
        }

        public Member GetById(int memberId)
        {
            return _context.Members.Where( member => member.Id == memberId)
                .Include( member => member.Club)
                .Include( member => member.User)
                .First();

        }
    }
}