using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProyectPractices.Models;
using ProyectPractices.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ProyectPractices.Controllers
{
    [Route("api/maestro")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;
       

        public MaestroController(IMapper mapper, ApplicationDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MaestroGetDTO>> Get(int id)
        {
            var existe = await context.Maestro.AnyAsync(m => m.Id == id);

            if (!existe)
            {
                return NotFound("El valor inserto no exite");
            }

            var maestro = await context.Maestro.FirstOrDefaultAsync(m => m.Id == id);
            return mapper.Map<MaestroGetDTO>(maestro);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MaestroPostDTO maestroPostDTO) 
        {
            var maestrodto = mapper.Map<Maestro>(maestroPostDTO);

            context.Maestro.Add(maestrodto);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
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

        [HttpDelete]
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
