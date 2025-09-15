using APIproducto908.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIproducto908.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly Productos908Context _context;

        public ProductosController(Productos908Context context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetProducto")]

        public ActionResult<IEnumerable<Producto>> GetAll()
        {
            return _context.Productos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var product = _context.Productos.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = producto.IdProducto}, producto);
        }

        [HttpPut("{id}")]

        public ActionResult Update(int id,Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }
            _context.Entry(producto).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return producto;
        }
    }
}
