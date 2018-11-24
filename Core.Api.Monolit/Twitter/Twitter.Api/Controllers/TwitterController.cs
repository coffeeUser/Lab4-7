using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twitter.Api.Models;
using Twitter.Api.Models.Context;

namespace Twitter.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public TwitterController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        // GET api/twitter
        [HttpGet]
        public ActionResult<IEnumerable<Tweet>> Get()
        {
            return context.Tweets;
        }

        // GET api/twitter/5
        [HttpGet("{id}")]
        public Tweet Get(int id)
        {
            return context.Tweets.FirstOrDefault(x => x.Id == id);
        }

        // POST api/twitter
        [Authorize]
        [HttpPost]
        public async Task PostAsync()
        {
            var identity = signInManager.Context.User;
            Tweet tweet = new Tweet();
            tweet.Content = Request.Form["content"];

            //tweet.AuthorId = userManager.Users.FirstOrDefault(x => x.Email == identity).;  //TODO some shit!
            //tweet.Author = userManager.Users.FirstOrDefault(x => x.Email == identity.Name);
            tweet.Date = DateTime.Now;
            context.Tweets.Add(tweet);
        }

        // PUT api/twitter/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/twitter/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}