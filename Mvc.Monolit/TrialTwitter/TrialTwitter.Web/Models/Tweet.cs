using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrialTwitter.Web.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        [MaxLength(240)]
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}