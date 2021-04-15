using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ShopFacil.Bradesco.Core.Exceptions;
using ShopFacil.Bradesco.Core.Extensions;
using ShopFacil.Bradesco.Core.Models.Boletos;
using ShopFacil.Bradesco.Core.Responses;
using ShopFacil.Bradesco.Core.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ShopFacil.Bradesco.Core.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly ShopFacilSettings _settings;
        private readonly HttpClient _httpClient;

        public BoletoService(IOptions<ShopFacilSettings> settings, HttpClient httpClient)
        {
            _settings = settings.Value;
            _httpClient = httpClient.SetBaseAddress(_settings.BaseAddress);
        }

        private async Task<string> GetAccessToken(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient
                .WithBasicAuthorizationHeader(_settings.Email, _settings.SecurityKey)
                .GetFromJsonAsync<TokenResponse>($"SPSConsulta/Authentication/{_settings.MerchantId}", cancellationToken)
                .ConfigureAwait(false);

            if (response.Status.Codigo != 0)
                throw new BoletoException(response.Status.Mensagem);

            return response.AccessToken.Token;
        }

        public async Task<Response> GerarBoleto(Remessa remessa, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient
                .WithBasicAuthorizationHeader(_settings.MerchantId, _settings.SecurityKey)
                .PostAsJsonAsync("/apiboleto/transacao", remessa, cancellationToken)
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<Response>(await response.Content.ReadAsStringAsync(cancellationToken));
        }

        public async Task<List<PedidoResponse>> GetOrderListPayment(DateTime dataInicial, DateTime dataFinal, int? status = null, int offset = 1, int limit = 100, CancellationToken cancellationToken = default)
        {
            var accessToken = await GetAccessToken(cancellationToken);
            var parameters = new Dictionary<string, string>
            {
                ["token"] = accessToken,
                ["dataInicial"] = dataInicial.ToString("yyyy/MM/dd HH:mm"),
                ["dataFinal"] = dataFinal.ToString("yyyy/MM/dd HH:mm"),
                ["status"] = status.ToString(),
                ["offset"] = offset.ToString(),
                ["limit"] = limit.ToString()
            };

            var url = AddQueryStringParametersToUrl($"SPSConsulta/GetOrderListPayment/{_settings.MerchantId}/Boleto", parameters);
            var response = await _httpClient
                .WithAcceptHeader(new MediaTypeWithQualityHeaderValue("application/json"))
                .WithBasicAuthorizationHeader(_settings.Email, _settings.SecurityKey)
                .GetFromJsonAsync<TokenResponse>(url, cancellationToken)
                .ConfigureAwait(false);

            if (response.Status.Codigo != 0)
                throw new BoletoException(response.Status.Mensagem);

            return response.Pedidos;
        }

        public async Task<List<PedidoResponse>> GetOrderById(string orderId, CancellationToken cancellationToken = default)
        {
            var accessToken = await GetAccessToken(cancellationToken);
            var parameters = new Dictionary<string, string>
            {
                ["token"] = accessToken,
                ["orderId"] = orderId
            };

            var url = AddQueryStringParametersToUrl($"SPSConsulta/GetOrderById/{_settings.MerchantId}", parameters);
            var response = await _httpClient
                .WithAcceptHeader(new MediaTypeWithQualityHeaderValue("application/json"))
                .WithBasicAuthorizationHeader(_settings.Email, _settings.SecurityKey)
                .GetFromJsonAsync<TokenResponse>(url, cancellationToken)
                .ConfigureAwait(false);

            if (response.Status.Codigo != 0)
                throw new BoletoException(response.Status.Mensagem);

            return response.Pedidos;
        }

        private static string AddQueryStringParametersToUrl(string url, Dictionary<string, string> parameters)
        {
            var queryStrings = new QueryString();
            foreach (var param in parameters)
                if (!string.IsNullOrWhiteSpace(param.Value))
                    queryStrings = queryStrings.Add(param.Key, param.Value);
            if (!queryStrings.HasValue) return url;
            return $"{url}{queryStrings}";
        }
    }
}
