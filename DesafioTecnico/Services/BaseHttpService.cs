using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using MVC;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public delegate Task<HttpResponseMessage> HttpVerbMethod(Uri requestUri, HttpContent content);

    public abstract class BaseHttpService : IService
    {
        protected readonly IConfiguration _configuration;
        protected readonly HttpClient _httpClient;

        protected readonly ISessionHelper _sessionHelper;
        protected string _baseUri;

        public BaseHttpService(IConfiguration configuration, HttpClient httpClient, ISessionHelper sessionHelper)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _sessionHelper = sessionHelper;
        }

        protected async Task<T> GetAuthenticatedAsync<T>(string uri, params object[] param)
        {
            var accessToken = await _sessionHelper.GetAccessToken(Scope);
            _httpClient.SetBearerToken(accessToken);

            return await GetAsync<T>(uri, param);
        }

        protected async Task<T> GetAsync<T>(string uri, params object[] param)
        {
            var requestUri = string.Format(new Uri(new Uri(_baseUri), uri).ToString(), param);

            foreach (var p in param)
            {
                requestUri += string.Format($"/{p}");
            }

            var json = await _httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected async Task<T> PostAsync<T>(string uri, object content)
        {
            var httpVerbMethod = new HttpVerbMethod(_httpClient.PostAsync);
            return await PutOrPostAsync<T>(uri, content, httpVerbMethod);
        }

        protected async Task<T> PutAsync<T>(string uri, object content)
        {
            var httpVerbMethod = new HttpVerbMethod(_httpClient.PutAsync);
            return await PutOrPostAsync<T>(uri, content, httpVerbMethod);
        }

        private async Task<T> PutOrPostAsync<T>(string uri, object content, HttpVerbMethod httpVerbMethod)
        {
            var jsonIn = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(jsonIn, Encoding.UTF8, "application/json");

            var accessToken = await _sessionHelper.GetAccessToken(Scope);
            _httpClient.SetBearerToken(accessToken);

            var httpResponse = await httpVerbMethod(new Uri(new Uri(_baseUri), uri), stringContent);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var error = new { httpResponse.StatusCode, httpResponse.ReasonPhrase };
                var errorJson = JsonConvert.SerializeObject(error);

                throw new HttpRequestException(errorJson);
            }
            var jsonOut = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonOut);
        }

        public abstract string Scope { get; }
    }
}