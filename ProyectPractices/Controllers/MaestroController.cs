using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ProyectPractices.Models;
using ProyectPractices.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ProyectPractices.Controllers
{
    [Route("api/[controller]")]
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
            var existe = await context.Maestro.AnyAsync()
        }

    }
}
