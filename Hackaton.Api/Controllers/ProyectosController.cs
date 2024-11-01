using Hackaton.Api.Data;
using Hackaton.Shared.Enties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Controles
{
    [ApiController]
    [Route("/api/Proyectos")]
    public class ProyectosController : ControllerBase
    {
        private readonly DataContext _context;
        public ProyectosController(DataContext context)
        {
            _context = context;
        }


        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Proyectos.ToListAsync());
        }


        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(proyecto);
            }
        }


        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Proyecto proyecto)
        {
            _context.Update(proyecto);
            await _context.SaveChangesAsync();
            return Ok(proyecto);
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Proyecto proyecto)
        {
            _context.Update(proyecto);
            await _context.SaveChangesAsync();
            return Ok(proyecto);
        }


        //  Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Proyectos
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

    }
}
