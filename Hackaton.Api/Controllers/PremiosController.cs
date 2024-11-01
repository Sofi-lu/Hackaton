using Hackaton.Api.Data;
using Hackaton.Shared.Enties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Controllers
{
    [ApiController]
    [Route("/api/Premios")]
    public class PremiosController : ControllerBase
    {
        private readonly DataContext _context;
        public PremiosController(DataContext context)
        {
            _context = context;
        }


        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Premios.ToListAsync());
        }


        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var premio = await _context.Premios.FirstOrDefaultAsync(x => x.Id == id);
            if (premio == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(premio);
            }
        }


        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Premio premio)
        {
            _context.Update(premio);
            await _context.SaveChangesAsync();
            return Ok(premio);
        }


        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Premio premio)
        {
            _context.Update(premio);
            await _context.SaveChangesAsync();
            return Ok(premio);
        }


        //  Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Premios
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
