using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Mvc;

namespace echobot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthAppController : ControllerBase
    {
        [HttpGet]
        public IActionResult AuthApp(string id, string secure, string confirmation, string? secret, string token, ulong epoch)
        {
            if (epoch != Auth.Epoch) return BadRequest("Invalid epoch!");
            
            Auth.AppId = id;
            Auth.AppSecurityKey = secure;
            Auth.CallbackConfirmation = confirmation;
            Auth.CallbackSecret = secret;
            Auth.CallbackGroupToken = token;
            using (FileStream fs = new FileStream(Auth.Dumpfile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                AuthTransfer transfer = new AuthTransfer();
                formatter.Serialize(fs, transfer);
            }

            Console.WriteLine($"::==>:: Authentication set. Epoch: {Auth.Epoch}");
            return Ok("ok");
        }
    }
}