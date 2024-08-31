using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ejemploData.DataBase.Tables
{
    [Keyless]
    [Table("oferta_productos")]
    public class OfertaProducto
    {
        //[Key]
        //public int id { get; set; }
        //[Key]
        [Column(Order =1)]
        public int oferta_id { get; set; }
        //[Key]
        [Column(Order = 2)]
        public int producto_id { get; set; }

        [Required]
        [Precision(6, 2)]
        public Decimal precio_oferta { get; set; }

        // public List<Producto> productos { get; set; }
    }
}
