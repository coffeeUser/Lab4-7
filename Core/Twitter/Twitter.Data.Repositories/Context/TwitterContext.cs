using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Repositories.Context
{
    public class TwitterContext : DbContext
    {
        public TwitterContext(DbContextOptions<TwitterContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
