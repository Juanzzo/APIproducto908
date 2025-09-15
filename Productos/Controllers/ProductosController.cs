using Microsoft.AspNetCore.Mvc;
using Productos.Services;

namespace Productos.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IApiClient _apiClient;
        public ProductosController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var productos= await _apiClient.GetProductosAsync();
            return View(productos);
        }

    }
}
