using System;
using VkNet.Abstractions;
using VkNet.Model.RequestParams;

namespace echobot.Handlers
{
    public static class MessageHandler
    {
        public static bool HandleNewMessage(sniff.ObjectMessage objectMessage, IVkApi vkApi)
        {
            vkApi.Messages.Send(new MessagesSendParams{ 
                RandomId = new DateTime().Millisecond,
                PeerId = objectMessage.Message.PeerId,
                Message = objectMessage.Message.Text
            });
            return true;
        }
    }
}