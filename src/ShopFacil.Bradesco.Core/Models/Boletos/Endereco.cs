using FluentValidation;
using ShopFacil.Bradesco.Core.Exceptions;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos
{
    public class Endereco
    {
        /// <summary>
        /// Informar somente números
        /// </summary>
        [JsonPropertyName("cep")]
        public string Cep { get; private set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; private set; }
        /// <summary>
        /// Informar somente números
        /// </summary>
        [JsonPropertyName("numero")]
        public int Numero { get; private set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; private set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; private set; }

        [JsonPropertyName("cidade")]
        public string Cidade { get; private set; }

        [JsonPropertyName("uf")]
        public string Uf { get; private set; }

        public Endereco(string cep, string logradouro, int numero, string complemento,
            string bairro, string cidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;

            Validate();
        }

        private void Validate()
        {
            var result = new EnderecoValidator().Validate(this);
            if (!result.IsValid) throw new BoletoException(string.Join(';', result.Errors.Select(p => p.ErrorMessage)));
        }
    }

    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(p => p.Cep).NotEmpty().Length(8);
            RuleFor(p => p.Logradouro).NotEmpty().MaximumLength(70);
            RuleFor(p => p.Numero).NotEmpty();
            RuleFor(p => p.Complemento).MaximumLength(20);
            RuleFor(p => p.Bairro).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Cidade).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Uf).NotEmpty().Length(2);
        }
    }
}