using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Mvc;

namespace echobot.Controllers
{
    [ApiController]
    [Route("control/[controller]")]
    public class AuthAppController : ControllerBase
    {
        [HttpGet]
        public IActionResult AuthApp(string id, string secure, string confirmation, string secret, string token, long epoch)
        {
            if (epoch != Auth.Epoch) return BadRequest("Invalid epoch!");
            
            Auth.AppId = id;
            Auth.Epoch = Auth.Random.Next();
            Auth.AppSecurityKey = secure;
            Auth.CallbackConfirmation = confirmation;
            Auth.CallbackSecret = secret;
            Auth.CallbackGroupToken = token;

            Console.WriteLine($"::==>:: Authentication set.");
            return Ok("ok");
        }
    }
}