using ejemploData.DataBase;
using ejemploData.DataBase.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo2.Controllers
{

    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController: ControllerBase
    {
        private readonly MiDbContext _db;

        public CategoriaController(MiDbContext db) {
            _db = db;
        }


        /**
         * Listar todas las categorias
         * 
        */
        [HttpGet]
        [Route("")]
        public IActionResult ListarCategorias()
        {
            var categorias = _db.Categorias.ToList();

            return Ok(categorias);
        }

        /**
         * Obtener una categoria por su ID
         * */
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerCategoria([FromRoute]int id)
        {
            var categoria = _db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound(); // StatusCode(404);
            }

            return Ok(categoria); // StatusCode(200);
        }

        /**
         * Creado una nueva catgoria 
         */
        [HttpPost]
        [Route("")]
        public IActionResult CrearCategoria([FromBody]Categoria body)
        {
            _db.Categorias.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            //return NoContent(); //StatusCode 204
            return Ok(body);
        }


        /**
         * Actualiza una categoria
         */
        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarCategoria(
            [FromRoute] int id, 
            [FromBody] Categoria body)
        {
            // Obtengo la categoria y vaido su existencia
            var categoria = _db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound(); // StatusCode(404);
            }
            // Actualizo lo campos con los datos que recibo 
            // desde el BODY
            categoria.nombre = body.nombre;

            // Guardo los cambios en la BD
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent(); //StatusCode 204
            
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult EliminarCategoria([FromRoute] int id)
        {
            // Obtengo la categoria y vaido su existencia
            var categoria = _db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound(); // StatusCode(404);
            }
            // indico que se elimine de la tabla
            _db.Categorias.Remove(categoria);
            // Aplico los cambios a la BD
            int r = _db.SaveChanges();

            // Verifico que se hayan efectuado estos cambios
            if (r != 1)
            {
                return StatusCode(500);
            }
            return NoContent(); //StatusCode 204
        }

        [HttpGet]
        [Route("{id}/productos")]
        public IActionResult ProductoPorCategoria([FromRoute] int id)
        {
            var productos = _db.Productos.Where(
                    (Producto) => Producto.categoria_id == id
                ).ToList();
            return Ok(productos);
        }

    }
}
