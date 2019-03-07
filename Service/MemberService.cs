using System.Collections.Generic;
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
        public Task Create(Member member)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}