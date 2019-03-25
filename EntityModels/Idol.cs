namespace fans.EntityModels
{
    public class Idol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string ImageUrl { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}