using System;
using fans.EntityModels;

namespace fans.Models.Member
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ChineseLastName { get; set; }
        public string ChineseFirstName { get; set; }
        public string EnglishLastName { get; set; }
        public string EnglishFirstName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Idol Favourite { get; set; }
        public string Phone { get; set; }
        public string Wechat { get; set; }
        public string MailingAddress { get; set; }
        public int SharedAddress { get; set; }
    }
}