using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectPractices.DTOs;
using ProyectPractices.Models;

namespace ProyectPractices.Controllers
{
    [ApiController]
    [Route("api/maestro/{id:int}/grupo")]
    public class GrupoController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GrupoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{idGrupo:int}",Name = "ObtenerGrupo")]
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

        [HttpGet("{idGroup:int}")]
        public async Task<ActionResult<GrupoGETMaDTO>> GetForMaestro(int id)
        {
            var exist = await context.Grupos.AnyAsync(g => g.Id == id);

            if (!exist)
            {
                return BadRequest("El grupo ingresado no existe. Por favor ingreselo.");
            }

            var grupo = await context.Grupos.Include(g => g.Maestro).FirstOrDefaultAsync(g => g.Id == id);
            return mapper.Map<GrupoGETMaDTO>(grupo);
        }

        [HttpPost]
        public async Task<ActionResult> Post(GrupoPostDTO grupoPostDTO, int id)
        {
            var cliente = await context.Grupos.AnyAsync(g => g.Id == grupoPostDTO.Id);

            if (cliente)
            {
                return BadRequest($"El grupo {grupoPostDTO.Nombre}");
            }

            var grupo = mapper.Map<Grupo>(grupoPostDTO);
            grupo.MaestroId = id;
            context.Grupos.Add(grupo);
            await context.SaveChangesAsync();

            return CreatedAtRoute("ObtenerGrupo", grupo.Id);
        }
    }
}
