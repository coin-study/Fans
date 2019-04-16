namespace fans.Models.Member
{
    public class RegisterLinkModel
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public int MemberId { get; set; }

        public string RegisterLink { get; set; }
    }
}