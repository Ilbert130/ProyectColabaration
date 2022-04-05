using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectPractices.DTOs;

namespace ProyectPractices.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RootController: ControllerBase
    {
        private readonly IAuthorizationService authorizationService;

        public RootController(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }


        [HttpGet(Name = "ObtenerRoot")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DatoHATEOASDTO>>> Get()
        {
            var datosHateoas  = new List<DatoHATEOASDTO>();

            var esAdmin = await authorizationService.AuthorizeAsync(User, "esAdmin");

            datosHateoas.Add(new DatoHATEOASDTO(enlace: Url.Link("ObtenerRoot", new { }), descripcion: "self", metodo: "GET"));

            datosHateoas.Add(new DatoHATEOASDTO(enlace: Url.Link("ObtenerMaestro", new { }), descripcion: "maestro", metodo: "GET"));

            datosHateoas.Add(new DatoHATEOASDTO(enlace: Url.Link("ObtenerGrupo", new { }), descripcion: "grupo", metodo: "GET"));

            if (esAdmin.Succeeded)
            {
                datosHateoas.Add(new DatoHATEOASDTO(enlace: Url.Link("CrearMaestro", new { }), descripcion: "maestros-crear", metodo: "POST"));

                datosHateoas.Add(new DatoHATEOASDTO(enlace: Url.Link("AgregarGrupo", new { }), descripcion: "grupo-crear", metodo: "POST"));
            }

            return datosHateoas;
            
        }
    }
}
