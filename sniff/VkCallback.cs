using System.Text.Json.Serialization;
using VkNet.Model.Attachments;

namespace sniff
{
    public class CallbackRequest
    {
        [JsonPropertyName(("type"))]
        public string Type { get; set; }
        [JsonPropertyName("group_id")]
        public ulong GroupId { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
        [JsonPropertyName("object")]
        public Object Object { get; set; }
    }

    public class Object
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; }
        [JsonPropertyName("client_info")]
        public ClientInfo ClientInfo { get; set; }
    }
    public class ClientInfo{
    [JsonPropertyName("button_actions")]
    public string[] ButtonActions { get; set; }

    [JsonPropertyName("keyboard")]
    public bool Keyboard { get; set; }

    [JsonPropertyName("lang_id")]
    public long LangId { get; set; }
    }
    public class Message
    {
        [JsonPropertyName("date")]
        public long Date { get; set; }

        [JsonPropertyName("from_id")]
        public long FromId { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("out")]
        public long Out { get; set; }

        [JsonPropertyName("peer_id")]
        public long PeerId { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("conversation_message_id")]
        public long ConversationMessageId { get; set; }

        [JsonPropertyName("fwd_messages")]
        public object[] FwdMessages { get; set; }

        [JsonPropertyName("important")]
        public bool Important { get; set; }

        [JsonPropertyName("random_id")]
        public long RandomId { get; set; }

        [JsonPropertyName("attachments")]
        public Attachment[] Attachments { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }
    }
    
}