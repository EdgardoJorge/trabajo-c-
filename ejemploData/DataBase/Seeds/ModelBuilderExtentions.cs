using ejemploData.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploData.DataBase.Seeds
{
    public static class ModelBuilderExtentions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { id=1, nombre="Frutas" },
                new Categoria { id = 2, nombre = "Verduras" },
                new Categoria { id = 3, nombre = "Carnes" },
                new Categoria { id = 4, nombre = "Menestras" },
                new Categoria { id = 5, nombre = "Bebidas" }
                );
            modelBuilder.Entity<Producto>().HasData(
                new Producto { id = 1, 
                    nombre = "Fresa", 
                    categoria_id=1, 
                    descripcion="Es una fresa", 
                    precio=8.50m }
                );

        }
    }
}
