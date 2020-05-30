using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using sniff.DTO;

namespace echobot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminTokenController : ControllerBase
    {
        private readonly IConfiguration __config;

        public AdminTokenController(IConfiguration config)
        {
            __config = config;
        }

        [HttpGet]
        public IActionResult Admintoken(string code)
        {
            var webClient = new WebClient();

            string jsonresponse = webClient.DownloadString(
                $"https://oauth.vk.com/access_token?client_id={Auth.AppId}&client_secret={Auth.AppSecurityKey}&redirect_uri={__config["Config:Registration:AdminTokenUri"]}&code={code}");
            var response = JsonSerializer.Deserialize<VkAuth>(jsonresponse);
            Auth.AdminToken = response.AccessToken;

            Console.WriteLine("::==>:: App authorized");
            return Ok("ok");
        }
    }
}