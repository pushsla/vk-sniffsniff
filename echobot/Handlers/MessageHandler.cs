using System;
using VkNet.Abstractions;
using VkNet.Model.RequestParams;

namespace echobot.Handlers
{
    public static class MessageHandler
    {
        public static void HandleNewMessage(sniff.Object objectMessage, IVkApi vkApi)
        {
            vkApi.Messages.Send(new MessagesSendParams{ 
                RandomId = new DateTime().Millisecond,
                PeerId = objectMessage.Message.PeerId,
                Message = objectMessage.Message.Text
            });
        }
    }
}