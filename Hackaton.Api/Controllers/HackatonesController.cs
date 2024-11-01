using Hackaton.Api.Data;
using Hackaton.Shared.Enties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Controlles
{

    [ApiController]
    [Route("/api/Hackatones")]

    public class HackatonesController : ControllerBase
    {
        private readonly DataContext _context;

        public HackatonesController(DataContext context)
        {
            _context = context;
        }

        //Get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Hackatones.ToListAsync());
        }

        //Get por parametro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var hackatonn = await _context.Hackatones.FirstOrDefaultAsync(x => x.Id == id);
            if (hackatonn == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(hackatonn);
            }
        }

        //put modificar 
        [HttpPut]
        public async Task<ActionResult> Put(Hackatonn hackatonn)
        {
            _context.Update(hackatonn);
            await _context.SaveChangesAsync();
            return Ok(hackatonn);
        }

        //post modificar 
        [HttpPost]
        public async Task<ActionResult> Post(Hackatonn hackatonn)
        {
            _context.Update(hackatonn);
            await _context.SaveChangesAsync();
            return Ok(hackatonn);
        }


        //Delete - borrar un registro
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Hackatones
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();//204
            }
        }
    }
}
