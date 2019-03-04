﻿using System;
using System.Collections.Generic;
using System.Text;
using fans.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace fans.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<JoinClub> JoinClubs { get; set; }
    }
}
