using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class BaseDTO
    {
        [JsonPropertyOrder(1)]
        public Guid GuidId { get; set; }
    }
}