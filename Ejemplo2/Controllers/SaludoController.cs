using Microsoft.AspNetCore.Mvc;

namespace Ejemplo2.Controllers
{
    [ApiController]
    [Route("/hola")]
    public class SaludoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public string Saludar()
        {
            return "Hola, mi nombre es Arturo";
        }

        [HttpGet]
        [Route("{nombre}")]
        public string SaludarNombre([FromRoute]string nombre)
        {
            return $"Hola {nombre}, yo soy Arturo.";
        }

        [HttpPost]
        [Route("")]
        public string SaludarNombrePost([FromBody] Persona persona)
        {
            return $"Hola {persona.nombre} {persona.apellido}," +
                $" yo soy Arturo.";
        }




    }
}
