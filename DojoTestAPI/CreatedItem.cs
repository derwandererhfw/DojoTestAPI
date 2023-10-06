using System.Text.Json.Serialization;

namespace DojoTestAPI
{
    public class CreatedItem
    {
        public string? SubscriptionId { get; set; }
        public int NotificationId { get; set; }
        public string? Id { get; set; }
        public string? EventType { get; set; }
        public string? PublisherId { get; set; }
        public Message Message { get; set; }
        public DetailedMessage DetailedMessage { get; set; }
        public Resource resource { get; set; }


    }
    public class Message
    {
        public string? Text { get; set; }
        public string? Markdown { get; set; }
    }
    public class DetailedMessage
    {
        public string? Text { get; set; }
        public string? Markdown { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public int rev { get; set; }
        public Fields fields { get; set; }
    }


    public class Fields
    {
        [JsonPropertyName("System.WorkItemType")]
        public string? WorkItemType { get; set; }

        [JsonPropertyName("System.Title")]
        public string? SystemTitle { get; set; }

        [JsonPropertyName("System.State")]
        public string? SystemState { get; set; }

        [JsonPropertyName("System.CreatedDate")]
        public string? SystemCreatedDate { get; set; }

        [JsonPropertyName("System.CreatedBy")]
        public string? SystemCreatedBy { get; set; }

        [JsonPropertyName("System.ChangedDate")]
        public string? SystemChangedDate { get; set; }

        [JsonPropertyName("System.ChangedBy")]
        public string? SystemChangedBy { get; set; }
    }
}

