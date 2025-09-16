using Productos.Models;

namespace Productos.Services
{
    public interface IApiClient
    {
        Task<IEnumerable<Producto>> GetProductosAsync();

        Task<Producto?> GetProductoAsync(int id);

        Task<bool> CreateProductoAsync(Producto producto);

        Task<bool> UpdateProductoAsync(Producto producto);

        Task<bool> DeleteProductoAsync(int id);
    }
}
