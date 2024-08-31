using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploData.DataBase.Tables
{

    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(512)]
        public string password { get; set; }

        [Required]
        [StringLength(128)]
        public string salt { get; set; }

        [Required]
        public int persona_id { get; set; }

        // public List<Producto> productos { get; set; }
    }
}
