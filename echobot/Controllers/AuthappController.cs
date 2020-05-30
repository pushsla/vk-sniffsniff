using System;
using Microsoft.AspNetCore.Mvc;

namespace echobot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthappController : ControllerBase
    {
        [HttpGet]
        public IActionResult Authapp(string id, string secure, string confirmation, string? secret, string token)
        {
            Auth.AppId = id;
            Auth.AppSecurityKey = secure;
            Auth.CallbackConfirmation = confirmation;
            Auth.CallbackSecret = secret;
            Auth.CallbackGroupToken = token;
            
            Console.WriteLine("::==>:: Authentication set");
            return Ok("ok");
        }
    }
}