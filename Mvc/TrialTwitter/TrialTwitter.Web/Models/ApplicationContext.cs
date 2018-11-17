using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrialTwitter.Web.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Tweet> Tweets { get; set; }

        public ApplicationContext() : base("TwitterDb")
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}