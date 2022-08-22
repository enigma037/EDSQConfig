using EDSQConfig.Common.Exceptions;
using EDSQConfig.UI.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EDSQConfig.UI.Infrastructure
{
    public class ApiService : IAPIService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string urlPath,
                                         string token = "",
                                         CancellationToken cancellationToken = new CancellationToken()) where T : class
        {
            var url = $"{_httpClient.BaseAddress?.AbsoluteUri}{urlPath}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var apiResponse = await _httpClient.SendAsync(request, cancellationToken);
            if (apiResponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                var responseData = await apiResponse.Content.ReadFromJsonAsync<T>();
                return responseData;
            }
            else if (apiResponse.StatusCode.Equals(HttpStatusCode.NoContent))
            {
                return default;
            }

            var message = await apiResponse.Content.ReadAsStringAsync();
            throw new BadRequestException(message);
        }

        public async Task<string> PostAsync(string urlPath, object postData, string token = "", CancellationToken cancellationToken = new CancellationToken())
        {
            var url = $"{_httpClient.BaseAddress?.AbsoluteUri}{urlPath}";
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var jsonContent = JsonSerializer.Serialize(postData);
            request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.SendAsync(request, cancellationToken);
            if (apiResponse.StatusCode.Equals(HttpStatusCode.OK))
            {
                var responseData = await apiResponse.Content.ReadAsStringAsync();
                return responseData;
            }

            var message = await apiResponse.Content.ReadAsStringAsync();
            throw new BadRequestException(message);
        }
    }
}
