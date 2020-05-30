using echobot.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace echobot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallbackController : ControllerBase
    {
        private readonly IConfiguration __config;
        private readonly sniff.IVkApiApp __vkApp;
        private readonly sniff.IVkApiGroup __vkGroup;

        public CallbackController(sniff.IVkApiApp vkApp, sniff.IVkApiGroup vkGroup, IConfiguration config)
        {
            __config = config;
            __vkApp = vkApp;
            __vkGroup = vkGroup;
        }

        public IActionResult Callback([FromBody] sniff.CallbackRequest request)
        {
            string responseText = "ok";
            
            if (request.Secret != Auth.CallbackSecret) return NotFound();
            switch (request.Type)
            {
                case "confirmation":
                    responseText = Auth.CallbackConfirmation;
                    break;
                case "message_new":
                    MessageHandler.HandleNewMessage(request.Object as sniff.ObjectMessage, __vkGroup);
                    break;
            }
            
            return Ok(responseText);
        }
    }
}