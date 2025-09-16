using Productos.Models;
using System.Net.Http.Json;

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

        public async Task<Producto?> GetProductoAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"productos/{id}");
        }

        public async Task<bool> CreateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PostAsJsonAsync("productos", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PutAsJsonAsync($"productos/{producto.IdProducto}", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"productos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
