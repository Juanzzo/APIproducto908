using Productos.Models;
namespace Productos.Services

{
    public interface IApiClient
    {
        Task<IEnumerable<Producto>> GetProductosAsync();
    }
}
