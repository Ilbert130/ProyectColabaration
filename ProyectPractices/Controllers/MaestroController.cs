using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProyectPractices.Models;
using ProyectPractices.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ProyectPractices.Controllers
{
    [Route("api/maestro")]
    [ApiController]
    //Con este atributo restringimos el acceso de este endpoint.
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class MaestroController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
        private readonly IAuthorizationService authorizationService;

        public MaestroController(IMapper mapper, ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            this.mapper = mapper;
            this.context = context;
            this.authorizationService = authorizationService;
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<MaestroGetDTO>> Get(int id)
        //{
        //    var existe = await context.Maestro.AnyAsync(m => m.Id == id);

        //    if (!existe)
        //    {
        //        return NotFound("El valor inserto no exite");
        //    }

        //    var maestro = await context.Maestro.FirstOrDefaultAsync(m => m.Id == id);
        //    return mapper.Map<MaestroGetDTO>(maestro);
        //}

        [HttpGet("listmaestro", Name = "ObtenerListMaestro")]
        [AllowAnonymous]
        public async Task<ActionResult<ColeccionRecursoDTO<MaestroGetDTO>>> GetList([FromQuery] bool incluirHATEOAS = true)
        {
            var listMaestro = await context.Maestro.ToListAsync();
            var listMaestroDTO = mapper.Map<List<MaestroGetDTO>>(listMaestro);

            if (incluirHATEOAS)
            {

                var esAdmin = await authorizationService.AuthorizeAsync(User, "esAdmin");
                listMaestroDTO.ForEach(listMaestroDTO => GenerarEnlace(listMaestroDTO, esAdmin.Succeeded));

                var resultado = new ColeccionRecursoDTO<MaestroGetDTO> { Valores = listMaestroDTO };
                resultado.Enlaces.Add(new DatoHATEOASDTO(enlace: Url.Link("ObtenerListMaestro", new { }), descripcion: "self", metodo: "GET"));

                if (esAdmin.Succeeded)
                {
                    resultado.Enlaces.Add(new DatoHATEOASDTO(enlace: Url.Link("CrearMaestro", new { }), descripcion: "self", metodo: "POST"));
                }

                return resultado;

            }

            return Ok(listMaestroDTO);
        }

        [HttpGet("{id:int}", Name = "ObtenerMaestro")]
        [AllowAnonymous]
        public async  Task<ActionResult<MaestroGetDTO>> Get(int id)
        {
            var existe = context.Maestro.Any(m => m.Id == id);

            if (!existe)
            {
                return NotFound("El valor inserto no exite");
            }

            var maestro = context.Maestro.FirstOrDefault(m => m.Id == id);
            var getDto =  mapper.Map<MaestroGetDTO>(maestro);
            var esAdmin = await authorizationService.AuthorizeAsync(User, "esAdmin");
            GenerarEnlace(getDto, esAdmin.Succeeded);
            return getDto;
        }

        private void GenerarEnlace(MaestroGetDTO maestroGetDTO, bool esAdmin)
        {
            maestroGetDTO.Enlaces.Add(new DatoHATEOASDTO(enlace: Url.Link("ObtenerMaestro", new { id = maestroGetDTO.Id}),
                descripcion: "ObtenerMaestro", metodo: "GET"));

            if (esAdmin)
            {
                maestroGetDTO.Enlaces.Add(new DatoHATEOASDTO(enlace: Url.Link("AcutalizarMaestro", new { id = maestroGetDTO.Id }),
                descripcion: "AcutalizarMaestro", metodo: "PUT"));

                maestroGetDTO.Enlaces.Add(new DatoHATEOASDTO(enlace: Url.Link("BorrarMaestro", new { id = maestroGetDTO.Id }),
                    descripcion: "BorrarMaestro", metodo: "DELETE"));
            }

        }

        [HttpPost(Name = "CrearMaestro")]
        public async Task<ActionResult>Post(MaestroPostDTO maestroPostDTO) 
        {
            var maestrodto = mapper.Map<Maestro>(maestroPostDTO);

            context.Maestro.Add(maestrodto);
            await context.SaveChangesAsync();
            return Ok();
        }

        //[HttpPost]
        //public async Task<ActionResult> Post(MaestroPostDTO maestroPostDTO)
        //{
        //    var maestrodto = mapper.Map<Maestro>(maestroPostDTO);

        //    context.Maestro.Add(maestrodto);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpPut(Name = "AcutalizarMaestro")]
        public async Task<ActionResult> Put(MaestroPutDTO maestroPutDTO,int id)
        {
            var validar = await context.Maestro.AnyAsync(m => m.Id == id);
            if (!validar)
            {
                return NotFound("El valor buscado no existe");
            }

            var existe = await context.Maestro.AnyAsync(m => m.Id == maestroPutDTO.Id);
            if (!existe)
            {
                return NotFound("el maestro a modificar no existe");
            }

            var producto = mapper.Map<Maestro>(maestroPutDTO);
            producto.Id = id;
            context.Maestro.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete(Name = "BorrarMaestro")]
        public async Task<ActionResult> Delete(int id)
        {
            var validar = await context.Maestro.AnyAsync(m => m.Id == id);
            if (!validar)
            {
                return NotFound("El valor buscado no existe");
            }
            context.Maestro.Remove(new Maestro() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }  

}
