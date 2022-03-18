using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectPractices.DTOs;

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

        [HttpGet("idGrupo:int")]
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

        
    }
}
