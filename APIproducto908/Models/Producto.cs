using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIproducto908.Models;

public partial class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(100)]
    public string? Categoria { get; set; }

    [StringLength(50)]
    public string? Precios { get; set; }
}
