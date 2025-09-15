using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIproducto908.Models;

public partial class Productos908Context : DbContext
{
    public Productos908Context()
    {
    }

    public Productos908Context(DbContextOptions<Productos908Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=MEDAPRCSGFSD731;Initial Catalog=Productos908;integrated security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__09889210CF484116");

            entity.ToTable("productos");

            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precios)
                .HasMaxLength(200)
                .HasColumnName("precios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
