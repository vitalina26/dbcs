using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DBManager.WebUi.Models;
using Newtonsoft.Json;

namespace DBManager.WebUi.Services
{
    public abstract class HttpServiceBase
    {
        protected readonly HttpClient _client;
        protected abstract string _apiControllerName { get; set; }
        private string webApiUrl = "http://localhost:5110";
        /// <summary>
        /// Constructor.
        /// </summary>
        protected HttpServiceBase()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(webApiUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.Timeout = TimeSpan.FromMinutes(5);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected string Url()
        {
            return $"/api/{_apiControllerName}";
        }

        protected string Url(string action)
        {
            return $"/api/{_apiControllerName}/{action}";
        }

        protected async Task<RequestResponseViewModel> GetRequestResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return new RequestResponseViewModel { Succeeded = true };

            var content = await response.Content.ReadAsStringAsync();
            var result = string.IsNullOrEmpty(content) ? new RequestResponseViewModel() : JsonConvert.DeserializeObject<RequestResponseViewModel>(content);
            result.Succeeded = response.IsSuccessStatusCode;
            result.StatusCode = response.StatusCode.ToString();

            return result;
        }
    }
}