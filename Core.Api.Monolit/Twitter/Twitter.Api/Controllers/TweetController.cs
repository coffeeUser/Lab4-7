using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public ActionResult<IEnumerable<Tweet>> Get()
        {
            return context.Tweets;
        }

        // GET api/tweets/5
        [HttpGet("{id}")]
        public Tweet Get(int id)
        {
            return context.Tweets.FirstOrDefault(x => x.Id == id);
        }

        // POST api/tweets
        [HttpPost]
        public async Task PostAsync(Tweet model)
        {
            var isLogged = User.Identity.IsAuthenticated;
            User user = await userManager.GetUserAsync(HttpContext.User);

            model.AuthorId = context.Users.FirstOrDefault(x => x.Email == user.Email).Id; //TODO some shit!
            model.Author = context.Users.FirstOrDefault(x => x.Email == user.Email);
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