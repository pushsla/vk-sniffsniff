using System;
using System.Text.Json.Serialization;

namespace sniff.DTO
{
    public class VkAttachmentDataBase
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("owner_id")]
        public long OwnerId { get; set; }

        [JsonPropertyName("date")]
        public long Date { get; set; }
        
    }

    public class VkAttachmentDataPhoto : VkAttachmentDataBase
    {
        [JsonPropertyName("album_id")]
        public long AlbumId { get; set; }
        
        [JsonPropertyName("has_tags")]
        public long HasTags { get; set; }
        
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        
        [JsonPropertyName("long")]
        public double Longitude { get; set; }
        
        [JsonPropertyName("post_id")]
        public long PostId { get; set; }
        
        [JsonPropertyName("sizes")]
        public VkAttachmentDataSizes[] Sizes { get; set; }
    }

    public class VkAttachmentDataDoc : VkAttachmentDataBase
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("ext")]
        public string Ext { get; set; }
        
        [JsonPropertyName("type")]
        public long Type { get; set; }
        
        [JsonPropertyName("url")]
        public Uri Url { get; set; }
        
        [JsonPropertyName("access_key")]
        public string AccessKey { get; set; }
    }
}