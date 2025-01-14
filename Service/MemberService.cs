using System;
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
        public async Task Update(int id, Member member)
        {
            var memberToUpdate = GetById(id);

            memberToUpdate.ChineseLastName = member.ChineseLastName;
            memberToUpdate.ChineseFirstName = member.ChineseFirstName;
            memberToUpdate.EnglishLastName = member.EnglishLastName;
            memberToUpdate.EnglishFirstName = member.EnglishFirstName;
            memberToUpdate.Gender = member.Gender;
            memberToUpdate.BirthDate = member.BirthDate;
            memberToUpdate.Favourite = member.Favourite;
            memberToUpdate.Phone = member.Phone;
            memberToUpdate.Wechat = member.Wechat;
            memberToUpdate.MailingAddress = member.MailingAddress;
            memberToUpdate.SharedAddress = member.SharedAddress;
            memberToUpdate.User = member.User;
            memberToUpdate.Club = member.Club;

            _context.Update(memberToUpdate);
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
                .Include( member => member.User)
                .Include( member => member.Payment)
                .Include( member => member.Favourite);
        }

        public Member GetById(int memberId)
        {
            return _context.Members.Where( member => member.Id == memberId)
                .Include( member => member.Club)
                .Include( member => member.User)
                .Include( member => member.Payment)
                .Include( member => member.Favourite)
                .FirstOrDefault();
        }

        public IEnumerable<Member> GetAllByUser(ApplicationUser user)
        {
            return _context.Members.Where( member => member.User == user)
                .Include( member => member.Club)
                .Include( member => member.User)
                .Include( member => member.Payment)
                .Include( member => member.Favourite);
        }

        public Member GetByUserAndClub(ApplicationUser user, Club club)
        {
            return _context.Members
                .Where( member => member.User == user )
                .Where( member => member.Club == club )
                    .Include( member => member.Club)
                    .Include( member => member.User)
                    .Include( member => member.Payment)
                    .Include( member => member.Favourite)
                    .FirstOrDefault();
        }
        public async Task UpdateRegisterLink(int id, string url)
        {
            var member = GetById(id);

            if (member.RegisterLink == null)
            {
                member.RegisterLink = url;

                _context.Update(member);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task UpdateKatakanaFirstName(int id, string name)
        {
            var member = GetById(id);

            member.KatakanaFirstName = name;

            _context.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKatakanaLastName(int id, string name)
        {
            var member = GetById(id);

            member.KatakanaLastName = name;

            _context.Update(member);
            await _context.SaveChangesAsync();
        }
    }
}