using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Net.Http;
using Microsoft.Extensions.Http;

namespace SMIAPP2026.Shared
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("APIClient");
        }

        public async Task<List<Region>> GetRegionsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Region>>("/regions");
            return result ?? throw new InvalidOperationException("Failed to retrieve regions.");
        }




        public async Task<List<Station>> GetStationsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Station>>("/stations");
            return result ?? throw new InvalidOperationException("Failed to retrieve stations. The response was null.");
        }

        public async Task<List<Photo>> GetPhotosAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Photo>>("/photos");
            return result ?? throw new InvalidOperationException("Failed to retrieve photos. The response was null.");
        }

        public async Task<bool> SavePhotoAsync(Photo photo)
        {
            var response = await _httpClient.PostAsJsonAsync("/photos", photo);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePhotoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/photos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
