using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Contracts.Entities;

namespace Twitter.Data.Repositories.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Tweet> Tweets { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
