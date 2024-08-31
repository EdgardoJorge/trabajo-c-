using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploData.DataBase.Tables
{
 

    [Table("personas")]
    public class Persona
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string apellidos { get; set; }


        [Required]
        [StringLength(50)]
        public string tipo_documento { get; set; }


        [Required]
        [StringLength(50)]
        public string nombre_document { get; set; }


        [Required]
        [StringLength(15)]
        public string telefono { get; set; }


        [Required]
        public DateTime fecha_nacimiento { get; set; }

        // public List<Producto> productos { get; set; }
    }
}
