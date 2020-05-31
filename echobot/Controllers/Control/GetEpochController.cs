using System;
using Microsoft.AspNetCore.Mvc;

namespace echobot.Controllers
{
    [ApiController]
    [Route("control/[controller]")]
    public class GetEpochController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEpoch()
        {
            Console.WriteLine($"::==>:: Epoch: {Auth.Epoch}");
            return Ok("ok");
        }
    }
}