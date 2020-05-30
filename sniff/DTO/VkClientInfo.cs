using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkClientInfo
    {
        [JsonPropertyName("button_actions")]
        public string[] ButtonActions { get; set; }

        [JsonPropertyName("keyboard")]
        public bool Keyboard { get; set; }

        [JsonPropertyName("lang_id")]
        public long LangId { get; set; }
    }
}