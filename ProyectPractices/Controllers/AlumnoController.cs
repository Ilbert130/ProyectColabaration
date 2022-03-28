using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectPractices.DTOs;
using ProyectPractices.Models;

namespace ProyectPractices.Controllers
{
    [ApiController]
    [Route("api/grupo/{id:int}/aulumnos")]
    public class AlumnoController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AlumnoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Obteniendo alumno con su grupo y profesor
        [HttpGet("idA:int")]
        public async Task<ActionResult<AlumnoGetDTO>> Get(int idA)
        {
            var exist = await context.Alumnos.AnyAsync(a => a.Id == idA);

            if (!exist)
            {
                return NotFound("El alumno ingresado no existe");
            }

            var alumno = await context.Alumnos.Include(a=>a.Grupo).ThenInclude(g => g.Maestro).FirstOrDefaultAsync(a => a.Id == idA);
            return mapper.Map<AlumnoGetDTO>(alumno);
        }

        //Insertando un nuevo alumno con sus materias inscritas
        [HttpPost]
        public async Task<ActionResult> Post(AlumnoPostDTO alumnoPostDTO, int id)
        {
            var existA = await context.Alumnos.AnyAsync(a => a.Nombre == alumnoPostDTO.Nombre &&
            a.Apellido == alumnoPostDTO.Apellido && a.GrupoId == id);

            if (existA)
            {
                return BadRequest("El alumno ingresado ya existe en el grupo asignado");
            }

            var alumno = mapper.Map<Alumno>(alumnoPostDTO);
            alumno.GrupoId = id;
            context.Alumnos.Add(alumno);
            await context.SaveChangesAsync();

            return Ok();
        }

        //Actualizar alumno con sus materias
        [HttpPut("idA:int")]
        public async Task<ActionResult> Put(int idA, AlumnoPostDTO alumnoPostDTO)
        {
            var alumno = await context.Alumnos.Include(a => a.MateriaAlumnos).FirstOrDefaultAsync(a => a.Id == idA);

            if(alumno == null)
            {
                return NotFound();
            }

            alumno = mapper.Map(alumnoPostDTO, alumno);
            await context.SaveChangesAsync();
            return NoContent();
        }

        //Eliminar Alumno
        [HttpDelete("idA:int")]
        public async Task<ActionResult> Delete(int idA)
        {
            var alumno = await context.Alumnos.Include(a => a.MateriaAlumnos).AnyAsync(a => a.Id == idA);

            if (!alumno)
            {
                return NotFound();
            }

            context.Alumnos.Remove(new Alumno() { Id = idA });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
