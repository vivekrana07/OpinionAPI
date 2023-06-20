using Microsoft.AspNetCore.Mvc;
using OpinionAPI.Context;
using OpinionAPI.Interface;
using OpinionAPI.Model;

namespace OpinionAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController : Controller
    {
        private readonly IUser _user;
        public LoginController(IUser user) 
        {
            _user = user;
        }
      
        [HttpPost("CreateAccount")]
        public async Task<ActionResult> CreateAccount([FromBody] LoginContext user)
        {
            var result = await _user.createAccount(user.Name, user.UserName, user.Password);
            return result;
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginContext user)
        {
            var result =  _user.login(user.UserName, user.Password);
            return result;
        }

        [HttpPost("SaveInfo")]
        public Task<ActionResult> SaveInfo([FromBody] LoginContext user)
        {
            var result = _user.SaveInfo(user.UserName, user.Name);
            return result;
        }
    }
}
