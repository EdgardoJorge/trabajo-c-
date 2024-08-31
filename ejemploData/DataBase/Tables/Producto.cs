using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploData.DataBase.Tables
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [StringLength(260)]
        public string descripcion { get; set; }
        [StringLength(40)]
        public string? codigoBarras { get; set; }
        [Required]
        [Precision(6,2)]
        public decimal precio { get; set; }
        public int? stock { get; set; }
        // [ForeignKey("categorias")]
        public int categoria_id { get; set; }


        // public Categoria categoria { get; set; }

    }
}
