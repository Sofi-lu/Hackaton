using Hackaton.Api.Data;
using Hackaton.Shared.Enties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Controllers
{
    [ApiController]
    [Route("/api/Evaluaciones")]

    public class EvaluacionesController : ControllerBase
    {
        private readonly DataContext _context;
        public EvaluacionesController(DataContext context)
        {
            _context = context;
        }


        // Get por lista
        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Evaluaciones.ToListAsync());
        }

        // Get por parametro
        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {
            var evaluacion = await _context.Evaluaciones.FirstOrDefaultAsync(x => x.Id == id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(evaluacion);
            }
        }

        //Post- insertar 
        [HttpPost]

        public async Task<ActionResult> Post(Evaluacion evaluacion)
        {
            _context.Add(evaluacion);
            await _context.SaveChangesAsync();

            return Ok(evaluacion);

        }

        //Put- modificar
        [HttpPut]

        public async Task<ActionResult> Put(Evaluacion evaluacion)
        {
            _context.Update(evaluacion);
            await _context.SaveChangesAsync();

            return Ok(evaluacion);

        }
        // Delete 
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Evaluaciones
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
