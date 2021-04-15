using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ShopFacil.Bradesco.Core.Extensions
{
    public static class HttpClientExtension
    {
        public static HttpClient SetBaseAddress(this HttpClient httpClient, string baseAddress)
        {
            httpClient.BaseAddress = new Uri(baseAddress);
            return httpClient;
        }

        public static HttpClient WithAcceptHeader(this HttpClient httpClient, MediaTypeWithQualityHeaderValue mediaType)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(mediaType);
            return httpClient;
        }
        
        public static HttpClient WithBasicAuthorizationHeader(this HttpClient httpClient, string identifier, string key)
        {
            var token = GenerateBasicAuthToken(identifier, key);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            return httpClient;
        }

        private static string GenerateBasicAuthToken(string identifier, string key)
        {
            var strigValue = $"{identifier}:{key}";
            var byteValue = Encoding.ASCII.GetBytes(strigValue);
            return Convert.ToBase64String(byteValue);
        }
    }
}
