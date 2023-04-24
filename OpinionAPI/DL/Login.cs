using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using OpinionAPI.Authorization;
using OpinionAPI.Interface;
using OpinionAPI.Model;
using System.Net;
using System.Net.Http;

namespace OpinionAPI.DL
{
    public class Login : IUser
    {
        private readonly OpinionDbContext _dbcontext;
        private readonly Auth _auth;
        public Login(OpinionDbContext context,Auth auth)
        {
            _dbcontext = context;
            _auth = auth;
        }
        public async Task<ActionResult> createAccount(string name, string username, string password)
        {
            var user = _dbcontext.Users.FirstOrDefault(x => x.UserName == username);

            if (user != null)
            {
                return new ObjectResult(new { message = "Username Already exist!" })
                {
                    StatusCode = StatusCodes.Status409Conflict
                };
            }

            Users users = new Users()
            {
                Name = name,
                UserName = username,
                Password = password,
                IsAdmin = false,
                Created = DateTime.Now,
            };

            await _dbcontext.Users.AddRangeAsync(users);
            await _dbcontext.SaveChangesAsync();

            return new ObjectResult(new { message = "Account Created!" })
            {
                StatusCode = StatusCodes.Status200OK
            };

        }

        public ActionResult login(string username, string password)
        {

            var user = _dbcontext.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return new ObjectResult(new { message = "Username doest not exist!" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            if (user.Password != password)
            {
                return new ObjectResult(new { message = "Username or Password is incorrect!" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            var token = _auth.GenerateJwtToken(username,user.UserId.ToString());

            return new ObjectResult(new { message = "Logged In", userId = user.UserId, admin = user.IsAdmin, token = token })
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }
    }
}
