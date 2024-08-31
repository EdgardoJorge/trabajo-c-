using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploData.DataBase.Tables
{


    [Table("ofertas")]
    public class Oferta
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string titulo { get; set; }

        [Required]
        public DateTime fecha_inicio { get; set; }

        [Required]
        public DateTime fecha_fin { get; set; }

        [Required]
        [StringLength(50)]
        public string banner_url { get; set; }
        // public List<Producto> productos { get; set; }
    }
}
