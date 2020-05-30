using System;
using System.Threading;
using sniff.DTO;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace echobot.Handlers
{
    public static class MessageHandler
    {
        public static void HandleNewMessage(VkObject objectMessage, IVkApi vkApi)
        {
            string text = objectMessage.Message.Text;
            vkApi.Messages.SetActivity(vkApi.UserId.ToString(), MessageActivityType.Typing, objectMessage.Message.PeerId);
            Thread.Sleep(1000);

            if (objectMessage.Message.Attachments.Length > 0)
            {
                text += "\nА еще ты прикрепил ";
                foreach (var atch in objectMessage.Message.Attachments)
                {
                    text += $"{atch.Type}, ";
                }
            }

            vkApi.Messages.Send(new MessagesSendParams{ 
                RandomId = new DateTime().Millisecond,
                PeerId = objectMessage.Message.PeerId,
                Message = text
            });
        }
    }
}