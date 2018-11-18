using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Contracts.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
