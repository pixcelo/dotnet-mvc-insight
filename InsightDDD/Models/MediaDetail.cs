using System.Text.Json.Serialization;

namespace InsightDDD.Models
{
    public class MediaDetail
    {
        public  string id { get; set; }
        public string caption { get; set; }

        [JsonPropertyName("like_count")]
        public int likeCount { get; set; }

        [JsonPropertyName("media_url")]
        public string mediaUrl { get; set; }
    }
}
