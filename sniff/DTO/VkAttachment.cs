using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkAttachment
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("doc")]
        public VkAttachmentDataDoc Doc { get; set; }
        [JsonPropertyName("photo")]
        public VkAttachmentDataPhoto Photo { get; set; }
    }

    
}