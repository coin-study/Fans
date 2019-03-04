using System;

namespace fans.EntityModels
{
    public class JoinClub
    {
        public Club Club { get; set; }
        public int MyProperty { get; set; }
        public string ChineseLastName { get; set; }
        public string ChineseFirstName { get; set; }
        public string EnglishLastName { get; set; }
        public string EnglishFirstName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Favourite { get; set; }
        public string Phone { get; set; }
        public string Wechat { get; set; }
        public string MailingAddress { get; set; }
        public int SharedAddress { get; set; }
    }
}