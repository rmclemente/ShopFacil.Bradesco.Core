using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos.Retornos
{
    public class StatusResponse
    {
        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }

        [JsonPropertyName("detalhes")]
        public object Detalhes { get; set; }
    }
}