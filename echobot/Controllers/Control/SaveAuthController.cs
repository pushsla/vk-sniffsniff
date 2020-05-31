using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Mvc;

namespace echobot.Controllers
{
    [ApiController]
    [Route("control/[controller]")]
    public class SaveAuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult SaveAuth(long epoch)
        {
            if (epoch != Auth.Epoch) return BadRequest("Invalid epoch!");
            
            using (FileStream fs = new FileStream(Auth.Dumpfile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                AuthTransfer transfer = new AuthTransfer();
                formatter.Serialize(fs, transfer);
            }

            return Ok("ok");
        }
    }
}