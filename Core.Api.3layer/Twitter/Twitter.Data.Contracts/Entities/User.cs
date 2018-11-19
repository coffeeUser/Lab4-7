using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Contracts.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
