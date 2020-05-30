using System.Text.Json.Serialization;

namespace sniff
{
    public class VkAuthPost
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("expires_in")]
        public ulong ExpiresInt { get; set; }
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
    }
}