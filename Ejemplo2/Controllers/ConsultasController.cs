using ejemploData.DataBase;
using ejemploData.DataBase.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo2.Controllers
{

    [ApiController]
    [Route("api/consultas")]
    public class ConsultasController: ControllerBase
    {
        private readonly MiDbContext _db;

        public ConsultasController(MiDbContext db)
        {
            _db = db;
        }


        /**
         * 
         * 
        */
        [HttpGet]
        [Route("")]
        public IActionResult CategoriaConProductos()
        {
            /*
            var categorias = _db.Categorias.ToList();
            var productos = _db.Productos.ToList();
            
            List<Object> dataFinal = new List<object>();
            categorias.ForEach( cat => {
                
                productos.Where(pro => pro.categoria_id == cat.id)
                         .ToList()
                         .ForEach(prod => {
                             Object o = new { CatId = cat.id, CatNombre = cat.nombre, 
                                              ProdId = prod.id, ProdNombre = prod.nombre };
                             dataFinal.Add(o);
                         });
            } );*/


            // var dataFinal =

            var query = _db.Categorias.Join(
                 _db.Productos,
                 (cat) => cat.id,
                 (prod) => prod.categoria_id,
                 (cat, pro) => new { categoria = cat, producto = pro }
            ).Join(
                _db.OfertaProductos,
                (catProd) => catProd.producto.id,
                (op) => op.producto_id,
                (catProd, op) => new { cat = catProd.categoria, pro = catProd.producto, op = op }
           ).Join(
               _db.Ofertas,
               (CatProOf) => CatProOf.op.oferta_id,
               (ofe) => ofe.id,
               (CatProOf, ofe) => new
               {
                   catNombre = CatProOf.cat.nombre,
                   prodNombre = CatProOf.pro.nombre,
                   proPrecio = CatProOf.op.precio_oferta,
                   ofeInicio = ofe.fecha_inicio,
                   ofeFin = ofe.fecha_fin
               }
           );
           
            
            //.ToList();
            


            return Ok(query);
        }

        [HttpGet]
        [Route("Persona")]
        public IActionResult PersonaUsuario()
        {
            var query = _db.Personas.Join(
                _db.Usuarios,
                (per) => per.id,
                (Us) => Us.persona_id,
                (per, Us) => new { Persona = per, Usuario = Us }
                ).ToList();

            return Ok(query);
        }
    }
}
