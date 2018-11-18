using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Data.Contracts.Entities
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime date { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
