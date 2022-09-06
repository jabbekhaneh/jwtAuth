using jwtAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace jwtAuth.Controllers
{
    public class AccountController : ControllerBase
    {
        private List<User> users;
        JwtAuthenticationToolser _JwtToken;
        public AccountController(JwtAuthenticationToolser jwtToken)
        {
            users = new List<User>
            {
                new User { UserName = "user1" ,Password =  "123456"},
                new User { UserName = "user2" ,Password =  "123456"}
            };
            _JwtToken = jwtToken;
        }
        [HttpPost]
        public IActionResult Auth(User user)
        {
            if (users.Any(_ => _.Password == user.Password &&
                             _.UserName == user.UserName){
                string token= _JwtToken.Authentication(user.UserName);
                return Ok(token);
            }
            return BadRequest();
        }
    }
}
