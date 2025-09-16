using Microsoft.AspNetCore.Mvc;
using Productos.Services;
using Productos.Models;

namespace Productos.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IApiClient _apiClient;

        public ProductosController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // Mostrar lista de productos
        public async Task<IActionResult> Index()
        {
            var productos = await _apiClient.GetProductosAsync();
            return View(productos);
        }

        // Ver detalles de un producto
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _apiClient.GetProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Mostrar formulario para crear un nuevo producto
        public IActionResult Create()
        {
            return View();
        }

        // POST: Crear un nuevo producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _apiClient.CreateProductoAsync(producto);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Error al crear el producto.");
            }
            return View(producto);
        }

        // GET: Editar producto
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _apiClient.GetProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Editar producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                bool result = await _apiClient.UpdateProductoAsync(producto);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar el producto.");
                }
            }
            return View(producto);
        }

        // GET: Confirmar eliminar producto
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _apiClient.GetProductoAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Eliminar producto
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool result = await _apiClient.DeleteProductoAsync(id);
            if (!result)
            {
                return BadRequest("No se pudo eliminar el producto.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
