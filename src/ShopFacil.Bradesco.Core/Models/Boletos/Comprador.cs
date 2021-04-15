using FluentValidation;
using ShopFacil.Bradesco.Core.Exceptions;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos
{
    public class Comprador
    {
        /// <summary>
        /// Nome do pagador/sacado
        /// </summary>
        [JsonPropertyName("nome")]
        public string Nome { get; private set; }
        /// <summary>
        /// CPF ou CNPJ. Informar somente números
        /// </summary>
        [JsonPropertyName("documento")]
        public string Documento { get; private set; }
        /// <summary>
        /// Endereço IP do comprador
        /// </summary>
        [JsonPropertyName("ip")]
        public string Ip { get; private set; }
        /// <summary>
        /// User Agent do comprador
        /// </summary>
        [JsonPropertyName("user_agent")]
        public string UserAgent { get; private set; }
        [JsonPropertyName("endereco")]
        public Endereco Endereco { get; private set; }

        public Comprador(string nome, string documento, string ip, string userAgent, Endereco endereco)
        {
            Nome = nome;
            Documento = documento;
            Ip = ip;
            UserAgent = userAgent;
            Endereco = endereco;

            Validate();
        }

        private void Validate()
        {
            var result = new CompradorValidator().Validate(this);
            if (!result.IsValid) throw new BoletoException(string.Join(';', result.Errors.Select(p => p.ErrorMessage)));
        }
    }

    public class CompradorValidator : AbstractValidator<Comprador>
    {
        public CompradorValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().MaximumLength(40);
            RuleFor(p => p.Documento).NotEmpty().Length(11, 14);
            RuleFor(p => p.Ip).Length(16, 50);
            RuleFor(p => p.UserAgent).MaximumLength(255);
        }
    }
}