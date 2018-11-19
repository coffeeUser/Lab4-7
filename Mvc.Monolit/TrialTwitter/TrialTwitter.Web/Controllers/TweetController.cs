using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrialTwitter.Web.Models;

namespace TrialTwitter.Web.Controllers
{
    public class TweetController : Controller
    {
        // GET: Tweet
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    int maxId = context.Tweets.Max(x => x.Id);
                    return View(context.Tweets.Include("Author")
                        .Where(x => x.Id >= (maxId - 20))
                        .OrderByDescending(x => x.Id).ToList());
                }
            }
            else
            {
                return RedirectToAction("Login", "Account"); 
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tweet tweet)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                tweet.AuthorId = context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id;
                context.Tweets.Add(tweet);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}