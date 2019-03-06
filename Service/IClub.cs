using System.Collections.Generic;
using System.Threading.Tasks;
using fans.EntityModels;

namespace fans.Service
{
    public interface IClub
    {
        Club GetById(int clubId);
        IEnumerable<Club> GetAll();
        IEnumerable<Member> GetAllMember(int clubId);

        Task Create(Club club);
        Task Delete(int cludId);
    }
}