using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkCallback
    {
        [JsonPropertyName(("type"))]
        public string Type { get; set; }
        [JsonPropertyName("group_id")]
        public ulong GroupId { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
        [JsonPropertyName("object")]
        public VkObject Object { get; set; }
    }
}