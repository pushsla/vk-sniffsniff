using System;
using Microsoft.AspNetCore.Mvc;

namespace echobot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthappController : ControllerBase
    {
        [HttpGet]
        public IActionResult Authapp(string id, string secure)
        {
            Auth.AppId = id;
            Auth.AppSecurityKey = secure;
            
            Console.WriteLine("::==>:: AppID set");
            return Ok("ok");
        }
    }
}