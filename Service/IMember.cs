using System.Collections.Generic;
using System.Threading.Tasks;
using fans.EntityModels;

namespace fans.Service
{
    public interface IMember
    {
        Member GetById(int memberId);
        IEnumerable<Member> GetAll();

        Task Create(Member member);
        Task Update(int id, Member member);
        Task Delete(int memberId);
    }
}