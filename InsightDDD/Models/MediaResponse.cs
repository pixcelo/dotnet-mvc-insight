using System.Text.Json.Serialization;

namespace InsightDDD.Models
{
    public class MediaResponse
    {
        [JsonPropertyName("data")]
        public List<Data> dataList { get; set; }
        public Paging paging { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
    }

    public class Cursors
    {
        public string before { get; set; }
        public string after { get; set; }
    }
}
