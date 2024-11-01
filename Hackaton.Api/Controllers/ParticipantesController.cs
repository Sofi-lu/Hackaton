using Hackaton.Api.Data;
using Hackaton.Shared.Enties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Controlles
{
    [ApiController]
    [Route("/api/Participantes")]

    public class ParticipantesController : ControllerBase
    {
        private readonly DataContext _context;
        public ParticipantesController(DataContext context)
        {
            _context = context;
        }


        // Get por lista
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Participantes.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {
            var participante = await _context.Participantes.FirstOrDefaultAsync(x => x.Id == id);
            if (participante == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(participante);
            }
        }

        //Post- insertar 
        [HttpPost]

        public async Task<ActionResult> Post(Participante participante)
        {
            try
            {
                _context.Add(participante);

                await _context.SaveChangesAsync();

                return Ok(participante);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        //Put- modificar
        [HttpPut]

        public async Task<ActionResult> Put(Participante participante)
        {
            _context.Update(participante);
            await _context.SaveChangesAsync();

            return Ok(participante);

        }
        // Delete 
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Participantes
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
