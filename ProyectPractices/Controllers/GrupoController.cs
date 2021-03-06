using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectPractices.DTOs;
using ProyectPractices.Models;
using System.Net;

namespace ProyectPractices.Controllers
{
    [ApiController]
    [Route("api/grupo")]
    //Con este atributo restringimos el acceso de este endpoint.
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GrupoController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GrupoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}",Name = "ObtenerGrupo")]
        //AllowAnonymous]
        public async Task<ActionResult<GrupoGetDTO>> Get(int id)
        {
            var exist = await context.Grupos.AnyAsync(g => g.Id == id);

            if (!exist)
            {
                return BadRequest("El grupo ingresado no existe. Por favor ingreselo.");
            }

            var grupo = await context.Grupos.FirstOrDefaultAsync(g => g.Id == id);
            return mapper.Map<GrupoGetDTO>(grupo);
        }

        [HttpPost(Name = "AgregarGrupo")]
        public async Task<ActionResult> Post(GrupoPostDTO grupoPostDTO, int id)
        {
            var exist = await context.Grupos.AnyAsync(g => g.Nombre == grupoPostDTO.Nombre);

            var maestro = await context.Maestro.AnyAsync(m => m.Id == id);

            if (exist)
            {
                return BadRequest($"El grupo {grupoPostDTO.Nombre}");
            }

            var grupo = mapper.Map<Grupo>(grupoPostDTO);
            grupo.MaestroId = id;
            context.Grupos.Add(grupo);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut(Name = "ActualizarGrupo")]
        public async Task<ActionResult> Put(GrupoPutDTO grupoPutDTO)
        {
            var existg = await context.Grupos.AnyAsync(g => g.Id == grupoPutDTO.Id);

            var existm = await context.Maestro.AnyAsync(m => m.Id == grupoPutDTO.MaestroId);

            if (!existg)
            {
                return NotFound("El grupo a actualizar no existe");
            }

            if (!existm)
            {
                return NotFound("El Maestro ingresado no existe");
            }

            var grupo = mapper.Map<Grupo>(grupoPutDTO);
            context.Grupos.Update(grupo);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerGrupo", grupo.Id);
        }

        [HttpDelete("idd:int", Name = "DeleteGrupo")]
        public async Task<ActionResult> Delete(int idd)
        {
            var exist = await context.Grupos.AnyAsync(g => g.Id == idd);

            if (!exist)
            {
                return NotFound("El grupo a eliminar no existe");
            }

            context.Grupos.Remove(new Grupo { Id = idd });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
