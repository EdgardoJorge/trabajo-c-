using ejemploData.DataBase.Tables;
using ejemploData.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo2.Controllers
{

    [ApiController]
    [Route("api/Productos")]
    public class ProductoController : ControllerBase
    {
        private readonly MiDbContext _db;

        public ProductoController(MiDbContext db)
        {
            _db = db;
        }


        /**
         * Listar todas las Productos
         * 
        */
        [HttpGet]
        [Route("")]
        public IActionResult ListarProductos()
        {
            var productos = _db.Productos.ToList();

            return Ok(productos);
        }

        /**
         * Obtener una Producto por su ID
         * */
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerProducto([FromRoute] int id)
        {
            var producto = _db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound(); // StatusCode(404);
            }

            return Ok(producto); // StatusCode(200);
        }

        /**
         * Creado una nueva catgoria 
         */
        [HttpPost]
        [Route("")]
        public IActionResult CrearProducto([FromBody] Producto body)
        {
            _db.Productos.Add(body);
            int r = _db.SaveChanges();
            if (r != 1)
            {
                return StatusCode(500);
            }
            //return NoContent(); //StatusCode 204
            return Ok(body);
        }


        /**
         * Actualiza una Producto
         */
        [HttpPut]
        [Route("{id}")]
        public IActionResult ActualizarProducto(
            [FromRoute] int id,
            [FromBody] Producto body)
        {
            // Obtengo la Producto y vaido su existencia
            var producto = _db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound(); // StatusCode(404);
            }
            // Actualizo lo campos con los datos que recibo 
            // desde el BODY
            producto.nombre = body.nombre;
            producto.descripcion = body.descripcion;
            producto.precio = body.precio;
            producto.codigoBarras = body.codigoBarras;
            producto.stock = body.stock;
            producto.categoria_id = body.categoria_id;

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
        public IActionResult EliminarProducto([FromRoute] int id)
        {
            // Obtengo la Producto y vaido su existencia
            var Producto = _db.Productos.Find(id);
            if (Producto == null)
            {
                return NotFound(); // StatusCode(404);
            }
            // indico que se elimine de la tabla
            _db.Productos.Remove(Producto);
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
        [Route("buscar")]
        public IActionResult BucarProductos([FromQuery] string parametro, [FromQuery]? int categoria)
        {
            string v2 = parametro ?? "";
            var productos = _db.Productos.Where(
                producto => producto.nombre.Contains(parametro)
                && (categoria == 0 || producto.categoria_id == categoria)
                ).ToList();
            return Ok(productos);
        }

    }

}
