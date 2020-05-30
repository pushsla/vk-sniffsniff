using System;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace echobot.Handlers
{
    public static class MessageHandler
    {
        public static void HandleNewMessage(sniff.Object objectMessage, IVkApi vkApi)
        {
            vkApi.Messages.SetActivity(vkApi.UserId.ToString(), MessageActivityType.Typing, objectMessage.Message.PeerId);
            Thread.Sleep(1000);
            vkApi.Messages.Send(new MessagesSendParams{ 
                RandomId = new DateTime().Millisecond,
                PeerId = objectMessage.Message.PeerId,
                Message = objectMessage.Message.Text
            });
        }
    }
}