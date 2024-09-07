using ejemploData.DataBase.Seeds;
using ejemploData.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploData.DataBase
{
    public class MiDbContext: DbContext
    {

        public MiDbContext( DbContextOptions opts ) 
            : base(opts) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // one to one
            modelBuilder.Entity<Categoria>()
                .HasMany<Producto>()
                .WithOne()
                .HasForeignKey( p => p.categoria_id)
                .IsRequired();
            // one to many
            modelBuilder.Entity<Persona>()
                .HasOne<Usuario>()
                .WithOne()
                .HasForeignKey<Usuario>(u => u.persona_id)
                .IsRequired();

            // multiple primary key
            modelBuilder.Entity<OfertaProducto>()
                .HasKey( op => new { op.oferta_id, op.producto_id });


            //// MAny 2 many is 2 one many
            modelBuilder.Entity<Producto>()
                .HasMany<OfertaProducto>()
                .WithOne()
                .HasForeignKey(op => op.producto_id)
                .IsRequired();

            modelBuilder.Entity<Oferta>()
                .HasMany<OfertaProducto>()
                .WithOne()
                .HasForeignKey(op => op.oferta_id)
                .IsRequired();



            modelBuilder.Seed();
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<OfertaProducto> OfertaProductos { get; set; }

        public DbSet<Oferta> Ofertas { get; set; }
        
    }
}
