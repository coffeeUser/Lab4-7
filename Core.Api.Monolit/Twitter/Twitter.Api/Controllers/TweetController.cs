using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twitter.Api.Models;
using Twitter.Api.Models.Context;

namespace Twitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public TweetController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        // GET api/tweets
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tweets/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/tweets
        [HttpPost]
        public void Post(Tweet model)
        {
            model.AuthorId = userManager.Users.Where(x => x.UserName == signInManager.Context.User.Identity.Name).FirstOrDefault().Id; //TODO some shit!
            model.Author = userManager.Users.Where(x => x.UserName == signInManager.Context.User.Identity.Name).FirstOrDefault();
            model.Date = DateTime.Now;
            context.Tweets.Add(model);
        }

        // PUT api/tweets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/tweets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}