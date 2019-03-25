using System.Collections.Generic;
using fans.EntityModels;

namespace fans.Service
{
    public interface IIdol
    {
        Idol GetById(int id);
        IEnumerable<Idol> GetAll();
        IEnumerable<Idol> GetAllByClub(Club club);
        IEnumerable<Idol> GetAllByClubId(int id);
    }
}