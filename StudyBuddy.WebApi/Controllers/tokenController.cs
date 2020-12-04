using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Infrastructure.Data.Helper;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.WebApi.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private readonly UserRepo _userRepo;
        private readonly IAuthenticationHelper _authenticationHelper;

        public TokenController(UserRepo userRepo, IAuthenticationHelper authHelper)
        {
            _userRepo = userRepo;
            _authenticationHelper = authHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginUserModel model)
        {
            var user = _userRepo.GetUser().FirstOrDefault(u => u.Name == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!_authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Name,
                token = _authenticationHelper.GenerateToken(user)
            });
        }
    }
}