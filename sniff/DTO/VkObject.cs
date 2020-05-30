using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkObject
    {
        [JsonPropertyName("message")]
        public VkMessage Message { get; set; }
        [JsonPropertyName("client_info")]
        public VkClientInfo ClientInfo { get; set; }
    }
}