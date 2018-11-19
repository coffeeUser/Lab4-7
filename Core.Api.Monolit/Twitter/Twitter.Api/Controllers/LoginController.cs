using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Twitter.Api.Models;
using Twitter.Api.ViewModels;

namespace Twitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // POST api/login
        [HttpPost]
        public async Task<StatusCodeResult> PostAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // GET api/login
        [HttpGet]
        public IQueryable<User> Get()
        {
            return userManager.Users;
        }
    }
}