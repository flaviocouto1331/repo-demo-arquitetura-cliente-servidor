using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class TodoDTO : BaseDTO
    {
        [JsonPropertyOrder(2)]
        public DateTime DataCadastro { get; set; }
        [JsonPropertyOrder(3)]
        public bool StatusCadastro { get; set; }
        [JsonPropertyOrder(4)]
        public string? Nome { get; set; }
        [JsonPropertyOrder(5)]
        public decimal Valor { get; set; }
    }
}