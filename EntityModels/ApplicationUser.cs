using System;
using Microsoft.AspNetCore.Identity;

namespace fans.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime MemberSince { get; set; }
    }
}