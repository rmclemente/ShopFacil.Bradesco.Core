using ShopFacil.Bradesco.Core.Models.Boletos.Retornos;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Responses
{
    public class Response
    {
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; }

        [JsonPropertyName("meio_pagamento")]
        public string MeioPagamento { get; set; }

        [JsonPropertyName("pedido")]
        public PedidoResponse Pedido { get; set; }

        [JsonPropertyName("boleto")]
        public BoletoResponse Boleto { get; set; }

        [JsonPropertyName("status")]
        public StatusResponse Status { get; set; }
    }
}
