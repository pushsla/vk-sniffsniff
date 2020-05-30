using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkAuth
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("expires_in")]
        public ulong ExpiresInt { get; set; }
        [JsonPropertyName("user_id")]
        public long UserId { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}