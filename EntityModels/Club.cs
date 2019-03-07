using System.Collections.Generic;

namespace fans.EntityModels
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string Homepage { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Member> Members { get; set; }
    }
}