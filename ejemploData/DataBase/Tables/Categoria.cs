
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemploData.DataBase.Tables
{

    [Table("categorias")]
    public class Categoria
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        // public List<Producto> productos { get; set; }
    }
}
