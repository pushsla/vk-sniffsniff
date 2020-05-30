using System;
using echobot.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VkNet.Model.RequestParams;

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

            __vkGroup.Messages.SendStickerAsync(new MessagesSendStickerParams
            {
                Domain = __config["Config:Registration:GroupDomain"],
                PeerId = long.Parse(__config["Config:Administration:GodId"]),
                RandomId = new DateTime().Millisecond,
                StickerId = 17616
            });
        }
    
        [HttpPost]
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
                    MessageHandler.HandleNewMessage(request.Object, __vkGroup);
                    break;
            }
            
            return Ok(responseText);
        }
    }
}