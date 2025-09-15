namespace Productos.Models
{   
    public partial class Producto
    {
        public int IdProducto { get; set; }

        public string? Nombre { get; set; }

        public string? Categoria { get; set; }

        public string? Precios { get; set; }
    }
}
