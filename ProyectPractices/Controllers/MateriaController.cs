using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectPractices.DTOs;
using ProyectPractices.Models;

namespace ProyectPractices.Controllers
{
    [ApiController]
    [Route("api/maestro/{id:int}/materia")]
    public class MateriaController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MateriaController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MateriaGetDTO>>> Get(int id)
        {
            var existP = await context.Maestro.AnyAsync(m => m.Id == id);

            if (!existP)
            {
                return NotFound("El id del maestro ingresado no existe");
            }

            var listMateria = await context.Materias.Include(m => m.Maestro).Where(m => m.MaestroId == id).ToListAsync();
            return mapper.Map<List<MateriaGetDTO>>(listMateria);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MateriaPostDTO materiaPostDTO, int id)
        {
            var exitM = await context.Materias.AnyAsync(m => m.Nombre == materiaPostDTO.Nombre);

            var exitP = await context.Maestro.AnyAsync(m => m.Id == id);

            if (exitM)
            {
                return BadRequest($"La materias {materiaPostDTO.Nombre} ya existe");
            }

            if (!exitP)
            {
                return NotFound("El id del maestro ingresado no existe");
            }

            var materia = mapper.Map<Materia>(materiaPostDTO);
            materia.MaestroId = id;
            context.Materias.Add(materia);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutMateria(MateriaPutDTO materiaPutDTO, int id)
        {
            var exist = await context.Materias.AnyAsync(m => m.Id == materiaPutDTO.Id);

            if (!exist)
            {
                return NotFound("El id de la materia no existe");
            }

            var materia = mapper.Map<Materia>(materiaPutDTO);
            materia.MaestroId = id;

            context.Materias.Update(materia);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("idm:int")]
        public async Task<ActionResult> DeleteMateria(int id, int idm)
        {
            var exist = await context.Materias.AnyAsync(m => m.Id == idm && m.MaestroId == id);

            if (!exist)
            {
                return NotFound("El id de la materia no existe");
            }

            context.Materias.Remove(new Materia { Id = idm, MaestroId = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
