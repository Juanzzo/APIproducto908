using Productos.Models;

namespace Productos.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        public ApiClient(HttpClient httpClient) 
            {
                _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            }
        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Producto>>("productos");
            return response ?? Enumerable.Empty<Producto>();
        }
    }
}
