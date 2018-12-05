using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Domain.Contracts.ViewModels
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime date { get; set; }
        public int AuthorId { get; set; }
        public UserViewModel Author { get; set; }
    }
}
