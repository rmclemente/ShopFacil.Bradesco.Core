using FluentValidation;
using ShopFacil.Bradesco.Core.Exceptions;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos.Remessas
{
    /// <summary>
    /// Caso não seja enviada nenhuma instrução serão utilizados os itens configurados no Gerenciador do Lojista
    /// </summary>
    public class Instrucoes
    {
        [JsonPropertyName("instrucao_linha_1")]
        public string InstrucaoLinha1 { get; private set; }

        [JsonPropertyName("instrucao_linha_2")]
        public string InstrucaoLinha2 { get; private set; }

        [JsonPropertyName("instrucao_linha_3")]
        public string InstrucaoLinha3 { get; private set; }

        [JsonPropertyName("instrucao_linha_4")]
        public string InstrucaoLinha4 { get; private set; }

        [JsonPropertyName("instrucao_linha_5")]
        public string InstrucaoLinha5 { get; private set; }

        [JsonPropertyName("instrucao_linha_6")]
        public string InstrucaoLinha6 { get; private set; }

        [JsonPropertyName("instrucao_linha_7")]
        public string InstrucaoLinha7 { get; private set; }

        [JsonPropertyName("instrucao_linha_8")]
        public string InstrucaoLinha8 { get; private set; }

        [JsonPropertyName("instrucao_linha_9")]
        public string InstrucaoLinha9 { get; private set; }

        [JsonPropertyName("instrucao_linha_10")]
        public string InstrucaoLinha10 { get; private set; }

        [JsonPropertyName("instrucao_linha_11")]
        public string InstrucaoLinha11 { get; private set; }

        [JsonPropertyName("instrucao_linha_12")]
        public string InstrucaoLinha12 { get; private set; }

        public Instrucoes(string instrucaoLinha1, string instrucaoLinha2, string instrucaoLinha3, 
            string instrucaoLinha4, string instrucaoLinha5, string instrucaoLinha6, 
            string instrucaoLinha7, string instrucaoLinha8, string instrucaoLinha9, 
            string instrucaoLinha10, string instrucaoLinha11, string instrucaoLinha12)
        {
            InstrucaoLinha1 = instrucaoLinha1;
            InstrucaoLinha2 = instrucaoLinha2;
            InstrucaoLinha3 = instrucaoLinha3;
            InstrucaoLinha4 = instrucaoLinha4;
            InstrucaoLinha5 = instrucaoLinha5;
            InstrucaoLinha6 = instrucaoLinha6;
            InstrucaoLinha7 = instrucaoLinha7;
            InstrucaoLinha8 = instrucaoLinha8;
            InstrucaoLinha9 = instrucaoLinha9;
            InstrucaoLinha10 = instrucaoLinha10;
            InstrucaoLinha11 = instrucaoLinha11;
            InstrucaoLinha12 = instrucaoLinha12;

            Validate();
        }

        private void Validate()
        {
            var result = new InstrucoesValidator().Validate(this);
            if (!result.IsValid) throw new BoletoException(string.Join(';', result.Errors.Select(p => p.ErrorMessage)));
        }
    }

    public class InstrucoesValidator : AbstractValidator<Instrucoes>
    {
        public InstrucoesValidator()
        {
            RuleFor(p => p.InstrucaoLinha1).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha2).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha3).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha4).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha5).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha6).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha7).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha8).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha9).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha10).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha11).MaximumLength(60);
            RuleFor(p => p.InstrucaoLinha12).MaximumLength(60);
        }
    }
}