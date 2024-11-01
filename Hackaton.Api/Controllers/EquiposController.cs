
using Hackaton.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Hackaton.Shared.Enties;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Controles
{

    [ApiController]
    [Route("/api/Equipos")]

    public class EquiposController : ControllerBase
    {
        private readonly DataContext _context;
        public EquiposController(DataContext context)
        {
            _context = context;
        }

        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Equipos.ToListAsync());
        }

        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var equipo = await _context.Equipos.FirstOrDefaultAsync(x => x.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(equipo);
            }
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Equipo equipo)
        {
            _context.Update(equipo);
            await _context.SaveChangesAsync();
            return Ok(equipo);
        }

        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Equipo equipo)
        {
         
            _context.Update(equipo);
            await _context.SaveChangesAsync();
            return Ok(equipo);
        }

        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Equipos
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
