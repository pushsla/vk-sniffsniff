using System;
using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkAttachmentDataSizes
    {
        [JsonPropertyName("height")]
        public ulong Height { get; set; }
        
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("width")]
        public ulong Width { get; set; }
    }
}